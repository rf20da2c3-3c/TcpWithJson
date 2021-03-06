using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using ModelLib.model;

namespace JsonClient
{
    class ClientWorker
    {
        private const int SERVER_PORT = 13202;

        public ClientWorker()
        {
        }

        public void Start()
        {
            TcpClient socket = new TcpClient("localhost", SERVER_PORT);
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                Car car = new Car("EL23401", "Black", "Tesla");

                String json = JsonSerializer.Serialize(car);

                sw.WriteLine(json);
            }
            socket?.Close();
        }
    }
}