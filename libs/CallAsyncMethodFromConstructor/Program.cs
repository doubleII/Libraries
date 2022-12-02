using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// more info 
// https://www.youtube.com/watch?v=J0mcYVxJEl0
//C:\Developement\MyCommonInfo\@Snippets\Csharp_code_snipped\async snippets\async_example_1
namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("RUN Main");

            CallAsyncMethodFromConstructor call = new CallAsyncMethodFromConstructor();

            Console.WriteLine("before Example1");
            await Example1();
            Console.WriteLine("After Example1");

            Console.WriteLine("###############");
            Console.WriteLine("Before Example2");
            var t = Example2().Result;
            Console.WriteLine(t);
            Console.WriteLine("After Example2");

            Func<Task<int>> getDataFromLambda = async () =>
            {
                //
                await Task.Delay(5000);
                var result = 42;

                return result;
            };

            // If your thread needing to return, use ConfigureAwait(fasle) take which thread is awailable, doesn't wait of mait thread.
            var r = await getDataFromLambda().ConfigureAwait(false);

            Console.WriteLine( $"getdataFromLambda: {r}" );

            try
            {
                var tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
                var re = await MethodWithCancelationToken("method with cancelation token called", token);
                Console.WriteLine($"Method with cancelation token result: {re}");
            }
            catch (OperationCanceledException)
            {

                Console.WriteLine("Canceled!");
            }

            Console.WriteLine("\n######### FINISH #########");
            Console.ReadLine();
        }


        public async static Task Example1()
        {
            Console.WriteLine("in Example 1");
            await Task.Delay(1000);
        }


        /// <summary>
        /// blocking main thread
        /// </summary>
        /// <returns></returns>
        public async static Task<string> Example2()
        {
            Console.WriteLine("in Example 2");
            await Task.Delay(1000);

            return "Example2 finished";
        }


        public async static Task<string> MethodWithCancelationToken(string text, CancellationToken token = default)
        {
            // Do something
            Console.WriteLine("Do something");
            Task processInformationTask = Task.Run(async () => await Task.Delay(2000));

            if (!processInformationTask.Wait(5000, token))
            {
                token.ThrowIfCancellationRequested();
                return "Canceled";
            }

            // do something else
            Console.WriteLine("Do something else");
            await Task.Delay(2000);

            return "Done";
        }
    }

    public class CallAsyncMethodFromConstructor
    {
        public CallAsyncMethodFromConstructor()
        {

            Console.WriteLine("before");
            Execute().SafeFireAndForget();
            Console.WriteLine("after");
        }

        public async Task Execute()
        {
            
            await Task.Delay(3000);
            Console.WriteLine("Doesn't wait of the Execute method. Just run the method");
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="continueOnCapturedContext"></param>
        /// <param name="onException"></param>
        public static async void SafeFireAndForget(this System.Threading.Tasks.Task task, bool continueOnCapturedContext = true, Action<Exception> onException = null)
        {
            try
            {

                await task.ConfigureAwait(continueOnCapturedContext);
            }
            catch (Exception ex) when (onException != null)
            {

                onException(ex);
            }
        }
    }
}
