using System;

namespace PlainClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientWorker worker = new ClientWorker();
            worker.Start();

            Console.ReadLine();
        }
    }
}
