using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;


namespace Client
{
    public class ClientSocket
    {
        private readonly Socket _clientSocket;


        string? user;


        public ClientSocket()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string remoteIp, int remotePort)
        {
            var ipAddress = IPAddress.Parse(remoteIp);
            var endPoint = new IPEndPoint(ipAddress, remotePort);

            try
            {
                _clientSocket.Connect(endPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting: {e.Message}");
            }
        }
        
        public void SendLoop()
        {

            while (true)
            {
                try
                {
                    Console.Write($"{user}: ");

                    //string text = Console.ReadLine() ?? "";

                    Thread thread = new Thread(new ThreadStart(ReadLine));
                    thread.Start();

                    var buffer = new byte[1024];
                    _clientSocket.Receive(buffer);

                    string message = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"\n{message}");


                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error sending: {e.Message}");
                }
            }
        }
        public void ReadLine()
        {
            
            string text = Console.ReadLine() ?? "";
            text = $"{user}: {text}";
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            _clientSocket.Send(buffer);

        }

        public void GetName()
        {
            Console.WriteLine("Enter your name");
            user = Console.ReadLine() ?? "";
            Console.WriteLine("Chat open, Enter Message: ");

        }



    }
}

