using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace PCWihtDataFlow
{
    /// <summary>
    /// https://gaurassociates.com/TPL%20Dataflow%20custom%20block%20in%2010%20min
    /// Producer Consumer Design Pattern with DataFlow
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
           var s =  new CustomExample();
            s.start();
            s.start();
        }
    }

    /// <summary>
    /// transformet -> producer -> consumer
    /// </summary>
    public class CustomExample
    {

        /// <summary>
        /// write here your CustomBlock
        /// </summary>
        /// <returns></returns>
        public static IPropagatorBlock<int, int> SumOddNumbers()
        {
            var output = new BufferBlock<int>();
            int sum = 0;
            var target = new ActionBlock<int>(async(input) =>
            {
                if( input % 2 != 0)
                {

                    sum += input;
                    await output.SendAsync(sum);
                }
            });

           target.Completion.ContinueWith(p =>
           {
               output.Complete();
           });

            return DataflowBlock.Encapsulate<int, int>(target, output);
        }

        public void start()
        {
            var consumerBlock = Consumer("consumer");

            // 2. here you can do something with the input data, if nesseery
            var transformBlock = new TransformBlock<int, int>(input =>
            {
                return input * 3;
            });

            var procedurBlock = SumOddNumbers();

            transformBlock.LinkTo(procedurBlock, new DataflowLinkOptions() { PropagateCompletion = true });

            procedurBlock.LinkTo(consumerBlock, new DataflowLinkOptions() { PropagateCompletion = true });


            // 1. get input data 
            for (int i = 0; i < 10; i++)
            {

                if(!transformBlock.Post(i))
                {
                    Console.WriteLine("Failed Post");
                }
            }

            transformBlock.Complete();

            transformBlock.Completion.ContinueWith(p => print_status(p, "transformer"));

            consumerBlock.Completion.ContinueWith(p => print_status(p, "consumer"));

            Console.ReadLine();
        }

        private void print_status(Task p, string v)
        {
            Console.WriteLine($"{p} {v}");
        }


        /// <summary>
        /// Consumer Block
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static ActionBlock<int> Consumer(string name)
        {
            return new ActionBlock<int>(input =>
            {
                Console.WriteLine($"in {name} -- {input}");
                Thread.Sleep(input);
            });
        }
    }

}
