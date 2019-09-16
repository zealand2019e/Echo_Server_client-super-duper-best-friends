using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;



namespace TCP_Client
{
    class Client
    {

        public void Start()
        {
            while (true)
            {
                try
                {
                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect("localhost", 7777);
                    var stream = tcpClient.GetStream();




                    //    tcpClient.Connect("localhost", 7777);
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;
                    string line = Console.ReadLine();
                    sw.WriteLine(line);
                  //  Console.WriteLine(sr.ReadLine());
                   // tcpClient.Close();
                }
                catch
                {

                }

            }



        }

    }
}
