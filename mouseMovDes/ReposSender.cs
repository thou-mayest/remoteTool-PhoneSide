using System;
using System.Collections.Generic;
using System.Text;
using mouseMovDes.repos;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using mouseMovDes;

namespace mouseMovDes
{
    class ReposSender : Irepos
    {
        private static string ipendpint;

        public void SetIp(string ip)
        {
            ipendpint = ip;
        }

        public void SenderVoid(string msg)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipendpint), 1997); // THIS SHOULD BE FIGURED OUT 


            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (!server.Connected)
            {
                try
                {
                    server.SendTimeout = 100;
                    server.Connect(ip);
                }
                catch (Exception x)
                {

                }
            }


            try
            {
                server.Send(Encoding.ASCII.GetBytes(msg));
            }
            catch (Exception x)
            {

            }
            server.Close();
            Thread.Sleep(10);
        }
    }
}
