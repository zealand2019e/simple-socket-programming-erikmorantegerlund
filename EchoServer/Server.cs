using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    public static class Server
    {
        public static void Start()
        {
            TcpListener socketServer = new TcpListener(IPAddress.Loopback, port:7777);
            
            //Start Server
            socketServer.Start();

            //accept tcp client
            TcpClient connectionSocket = socketServer.AcceptTcpClient();
            Console.WriteLine("server activated");
            
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
           
           
            string message = sr.ReadLine();
            
            //send message back to uppercase
            Console.WriteLine("received message:" + message);
            if(message !=null)
                sw.WriteLine(message.ToUpper());

            sw.AutoFlush = true; //enable automatic flushing

            
            ns.Close();
            connectionSocket.Close();
            socketServer.Stop();


        }
    }
}
