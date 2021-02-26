using Intergraph.IPS.Germany.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

//https://docs.microsoft.com/de-de/dotnet/framework/network-programming/asynchronous-client-socket-example
namespace MyTcpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AsynchronousClient client;


        public MainWindow()
        {
            InitializeComponent();
            Ip.Text = Properties.Settings.Default.ip;
            Port.Text = Properties.Settings.Default.port;
            client = new AsynchronousClient();
            client.MessageRecived += Client_MessageRecived;
        }

        private void Client_MessageRecived(object sender, MessageEventArgs e)
        {
            GerLog.PrintInfo($">>> show message");
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                    new Action(() => log.Text += $"{e.Message}"));
            GerLog.PrintInfo($"<<< show message");
        }


        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            GerLog.PrintInfo($">>> Button Connect clicked");
            if (string.IsNullOrEmpty(output.Text))
                return;

            int.TryParse(Port.Text, out int port);
            client.StartClient(Ip.Text, port, output.Text);
            ConnectionStatus.Text = client.client.Connected == true ? "Status: Connected" : "Status: Disconnected";
            GerLog.PrintInfo($"<<< Button Connect clicked");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            log.Text = null;
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            GerLog.PrintInfo($">>> Button Disconnect clicked");
            client.Disconnect(client.client);
            ConnectionStatus.Text = client.client.Connected == true ? "Status: Connected" : "Status: Disconnected";
            GerLog.PrintInfo($"<<< Button Disconnect clicked");
        }

        private void Output_KeyDown(object sender, KeyEventArgs e)
        {
            GerLog.PrintInfo($">>> Send message");
            if (e.Key == Key.Enter)
            {
                e.Handled = true;

                if (!string.IsNullOrEmpty(output.Text))
                {
                    var msg = output.Text;
                    output.Text = null;
                    if (client.client.Connected)
                    {
                        client.Send(client.client, msg);
                        log.Text = msg;
                        GerLog.PrintInfo($">>> message: {msg}");
                    }
                }
            }
            GerLog.PrintInfo($"<<< Send message");
        }
    }

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        // The port number for the remote device.  
        //private const int port = 11000;

        // ManualResetEvent instances signal completion.  
        private ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.  
        public event EventHandler<MessageEventArgs> MessageRecived;
        IPAddress ipAddress; //ipHostInfo.AddressList[0];
        IPEndPoint remoteEP;

        // Create a TCP/IP socket.  
        public Socket client;

        public void StartClient(string ip, int port, string startParameter)
        {
            // Connect to a remote device. 
            GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
            try
            {
                GerLog.PrintInfo($"IP: {ip} | Port: {port} | Start parameter: {startParameter}");
                ipAddress = IPAddress.Parse(ip);
                remoteEP = new IPEndPoint(ipAddress, port);

                client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.  
                Send(client, startParameter);
                sendDone.WaitOne();

                // Receive the response from the remote device.  
                Receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.  
                GerLog.PrintInfo("Response received");

                //Disconnect(client);
                GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");

            }
            catch (Exception e)
            {
                GerLog.PrintError($"{e}");
            }
        }

        public void Disconnect(Socket client)
        {
            GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                GerLog.PrintInfo("ConnectCallback Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
                GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");
            }
            catch (Exception e)
            {
                GerLog.PrintError($"{e}");
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
                GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");
            }
            catch (Exception e)
            {
                GerLog.PrintError($"{e}");
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                    GerLog.PrintInfo($">>>>> in Arbeit {state.sb}");
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        OnMesseageRecived($"{state.sb}");
                        GerLog.PrintInfo($">>>>> ReceiveCallback Message: {state.sb}");
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                    GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");
                }
            }
            catch (Exception e)
            {
                GerLog.PrintError($"{e}");
            }
        }

        public virtual void OnMesseageRecived(string message)
            => MessageRecived?.Invoke(this, new MessageEventArgs() { Message = message });

        public void Send(Socket client, string data)
        {
            GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
            GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                GerLog.PrintInfo($">>> {MethodBase.GetCurrentMethod().Name}");
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                GerLog.PrintInfo($"Sent {bytesSent} bytes to server.");

                // Signal that all bytes have been sent.  
                sendDone.Set();
                GerLog.PrintInfo($"<<< {MethodBase.GetCurrentMethod().Name}");
            }
            catch (Exception e)
            {
                GerLog.PrintError($"{e}");
            }
        }

    }

    public class MessageEventArgs: EventArgs
    {
        public string Message { get; set; }
    }
}
