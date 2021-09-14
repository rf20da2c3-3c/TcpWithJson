
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using ModelLib.model;

namespace PlainClient
{
    class ClientWorker
    {
        private const int SERVER_PORT = 13201;

        public ClientWorker()
        {
        }

        public void Start()
        {
            TcpClient socket = new TcpClient("localhost", SERVER_PORT);
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                Car car = new Car("EL23400","red", "Tesla");

                sw.WriteLine(car.ToString());
            }
            socket?.Close();
        }
    }
}