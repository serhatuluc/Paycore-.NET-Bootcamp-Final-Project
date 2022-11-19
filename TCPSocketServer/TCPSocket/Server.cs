using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocket
{
    public class Server
    {
        public IPAddress myIp { get;set; }
        public int port { get;set; }
        public bool serverStatus { get; set; } = true;
        private TcpListener tcpListener;
        public Socket socketForClient { get; set; }
        public NetworkStream networkStream { get; set; } 
        public StreamReader streamReader { get; set; }
        public StreamWriter streamWriter { get; set; }

        public Server(IPAddress myIp,int port)
        {
            this.myIp = myIp;
            this.port = port;
        }

       public void startListening()
        {
            try
            {
                tcpListener = new TcpListener(myIp,port);
                tcpListener.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Couldn't start");
            }
        }

        public void acceptClient()
        {
            try
            {
                socketForClient = tcpListener.AcceptSocket();
            }
            catch
            {
                Console.WriteLine("Couldn't accept client");
            }
        }

        //allows server to exchange data with client
        public void clientData()
        {
            //client data 
            networkStream = new NetworkStream(socketForClient);
            //allows us to read from client
            streamReader = new StreamReader(networkStream);
            //allows us to write to client
            streamWriter = new StreamWriter(networkStream); 
        }

        public void disconnect()
        {
            networkStream.Close();
            streamWriter.Close();
            streamReader.Close(); 
            socketForClient.Close();
        }

    }
}
