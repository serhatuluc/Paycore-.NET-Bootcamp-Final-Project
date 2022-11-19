using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TcpSocketClient
{
    public class Client
    {
        public IPAddress myIp { get; set; }
        public int port { get; set; }
        public bool clientStatus { get; set; } = true;
        private TcpClient socketForServer;
        public Socket socketForClient { get; set; }
        public NetworkStream networkStream { get; set; }
        public StreamReader streamReader { get; set; }
        public StreamWriter streamWriter { get; set; }

        public Client(IPAddress myIp, int port)
        {
            this.myIp = myIp;
            this.port = port;
        }


        public void ConnectToServer()
        {
            try
            {
                //needs to be same ip and port as the server
                socketForServer = new TcpClient(myIp.ToString(),port);
            }
            catch
            {

            }
        }

        public void serverData()
        {
            networkStream = socketForServer.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
        }

        public void disconnect()
        {
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
            socketForServer.Close();     
        }
    }
}
