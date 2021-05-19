using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ProducerConsumer
{
    class Program
    {
        static async Task Main()
        {
            for(int i = 0; i<= 10; i++)
            {
                var buffer = new BufferBlock<byte[]>();
                var consumerTask = DataflowProducerConsumer.ConsumeAsync(buffer);
                DataflowProducerConsumer.Produce(buffer);

                var bytesProcessed = await consumerTask;

                Console.WriteLine($"Processed {bytesProcessed:#,#} bytes.");
                DataflowProducerConsumer.count++;
            }
            Console.ReadLine();
        }
    }


    public static class DataflowProducerConsumer
    {
        public static int count = 0;
        public static void Produce(ITargetBlock<byte[]> target)
        {
            Console.WriteLine("Producer");
            var rand = new Random();

            for (int i = 0; i < 100; ++i)
            {
                var buffer = new byte[1024];
                rand.NextBytes(buffer);
                target.Post(buffer);
            }
            Console.WriteLine($"producer send data {count}");
            target.Complete();
        }

        public static async Task<int> ConsumeAsync(ISourceBlock<byte[]> source)
        {
            Console.WriteLine("Consumer");
            int bytesProcessed = 0;

            while (await source.OutputAvailableAsync())
            {
                byte[] data = await source.ReceiveAsync();
                bytesProcessed += data.Length;
                Thread.Sleep(20);
            }
            Console.WriteLine($"consumer {count}");
            return bytesProcessed;
        }
    }
}
