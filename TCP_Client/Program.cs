using System;
using System.Net.Sockets;
namespace TCP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();
        }
    }
}
