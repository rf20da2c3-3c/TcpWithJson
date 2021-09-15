using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using ModelLib.model;

namespace JsonServer
{
    class ServerWorker
    {
        private const int PORT = 13202;
        public ServerWorker()
        {
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PORT);
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

                Car car = JsonSerializer.Deserialize<Car>(carString);

                Console.WriteLine("Received car json string " + carString);
                Console.WriteLine("Received car : " + car);
            }
            socket?.Close();
        }
    }
}