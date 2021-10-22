using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        string path = string.Empty;
        string xmlInputData = string.Empty;
        string xmlOutputData = string.Empty;

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
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                    new Action(() => log.Text += $"{e.Message}"));
        }


        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($">>> Button Connect clicked");
            if (string.IsNullOrEmpty(output.Text))
                return;

            int.TryParse(Port.Text, out int port);

            await client.StartClient(Ip.Text, port, output.Text);
            ConnectionStatus.Text = client.client.Connected == true ? "Status: Connected" : "Status: Disconnected";
            Console.WriteLine($"<<< Button Connect clicked");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            log.Text = null;
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($">>> Button Disconnect clicked");
            client.Disconnect(client.client);
            ConnectionStatus.Text = client.client.Connected == true ? "Status: Connected" : "Status: Disconnected";
            Console.WriteLine($"<<< Button Disconnect clicked");
        }

        private void Output_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine($">>> Send message");
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
                        Console.WriteLine($">>> message: {msg}");
                    }
                }
            }
            Console.WriteLine($"<<< Send message");
        }
    }

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 8192;
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
        int counter = 1;

        // Create a TCP/IP socket.  
        public Socket client;

        public async Task StartClient(string ip, int port, string startParameter)
        {
            // Connect to a remote device. 
            Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
            try
            {
                Console.WriteLine($"IP: {ip} | Port: {port} | Start parameter: {startParameter} ");
                ipAddress = IPAddress.Parse(ip);
                remoteEP = new IPEndPoint(ipAddress, port);
                client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                await Task.Run(() => BeginConnectionAsync());

                // Send test data to the remote device.  
                await Task.Run(() => SendAsync(startParameter));

                // Receive the response from the remote device.  
                await Task.Run(() => ReceiveAsync());

                // Write the response to the console.  
                Console.WriteLine("Response received");

                //Disconnect(client);
                Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        private void BeginConnectionAsync()
        {
            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne(2000);
            Console.WriteLine("NO SERVER FOUND");
        }

        private void SendAsync(string startParameter)
        {
            Send(client, startParameter);
            sendDone.WaitOne();
            Console.WriteLine("Start parameter sent...");
        }

        public void ReceiveAsync()
        {

            Receive(client);
            //receiveDone.WaitOne(2000);
            receiveDone.WaitOne();
            Console.WriteLine("receive...");

        }

        public void Disconnect(Socket client)
        {
            Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name}");
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("ConnectCallback Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
                Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
                Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name} | the receive buffer set to: {client.ReceiveBufferSize}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                    Console.WriteLine($">>>>>{counter}. Zwischenergebnis {state.sb}");
                    OnMesseageRecived($"{counter}. Zwischenergebnis:\n{state.sb}\n\n");
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        OnMesseageRecived($"{counter}. Endergebnis: \n{state.sb}\n");
                        Console.WriteLine($">>>>> Endergebnis: {state.sb}");
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                    Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name}");
                }
                counter++;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

        public virtual void OnMesseageRecived(string message)
            => MessageRecived?.Invoke(this, new MessageEventArgs() { Message = message });

        public void Send(Socket client, string data)
        {
            Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
            Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name}");
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine($">>> {MethodBase.GetCurrentMethod().Name}");
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine($"Sent {bytesSent} bytes to server.");

                // Signal that all bytes have been sent.  
                sendDone.Set();
                Console.WriteLine($"<<< {MethodBase.GetCurrentMethod().Name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }

    }

    public class MessageEventArgs: EventArgs
    {
        public string Message { get; set; }
    }
}
