using CoffeeServer.FirestoreHelpers;
using CoffeeServer.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using CoffeeServer.Handlers;
class TcpServer
{
    static  void Main()
    {

        int port = 5000;
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Server listening on port {port}...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + received);
            RequestHandler handler = new RequestHandler();
            string result =  handler.HandleRequest(received).GetAwaiter().GetResult(); ;
            // Echo back
            byte[] response = Encoding.UTF8.GetBytes("Server: " + result);
            stream.Write(response, 0, response.Length);

            client.Close();
        }
    }
}
