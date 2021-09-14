using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PlainServer
{
    class ServerWorker
    {
        private const int PORT = 13201;
        public ServerWorker()
        {
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, PORT);
            listener.Start();

            while (true)
            {
                TcpClient socket = listener.AcceptTcpClient();
                Task.Run(
                    () =>
                    {
                        TcpClient tmpSocket = socket;
                        DoClient(tmpSocket);
                    }
                );
            }


        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                String carString = sr.ReadLine();

                Console.WriteLine("Received car string : " +carString);
            }
            socket?.Close();
        }
    }
}