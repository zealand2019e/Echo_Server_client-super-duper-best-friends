using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TCP_Server
{
    class Server
    {

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Loopback, 7777);
            tcpListener.Start();
            Console.WriteLine("Server started");




            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            while (true)
            {
                if (tcpListener.Pending())
                {
                   tcpClient = tcpListener.AcceptTcpClient();
                }

                //  Console.Clear();
                //  Console.WriteLine("Connected");



                try
                    {

                      //  Console.Write("Receiving...:");
                        System.Threading.Tasks.Task.Run(() => { TcpClient tsock = tcpClient; DoClient(tsock); });
                   
                    //  System.Threading.Thread.Sleep(5000);
                    //  DoClient(tcpClient);
                }


                    catch
                    {

                    }

                

            }



        }

        void DoClient(TcpClient tcpClient)
        {
            var stream = tcpClient.GetStream();
            StreamReader sr = new StreamReader(stream);
            StreamWriter sw = new StreamWriter(stream);
            sw.AutoFlush = true;
            string line = sr.ReadLine();
            Console.WriteLine(line);


            if (line.ToUpper().Contains("ADD"))
            {
                int sum = 0;
                string[] stringArray = line.Split(' ');
                foreach (var item in stringArray)
                {

                    try { sum += Convert.ToInt32(item); }
                    catch
                    {

                    }
                }
                sw.WriteLine((sum.ToString()));
            }


            else {
                sw.WriteLine("Message Received!");
            }
            


        }
    }
}
