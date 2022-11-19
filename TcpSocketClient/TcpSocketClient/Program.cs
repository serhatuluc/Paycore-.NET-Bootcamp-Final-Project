using System;
using System.Net;

namespace TcpSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            IPAddress myIP = IPAddress.Parse("161.9.67.224");
            int port = 3000;

            Client client = new Client(myIP, port);

            client.ConnectToServer();
            Console.WriteLine("Connected to the server");
            //wait a little bit
            Thread.Sleep(1000);
            Console.Clear();

            client.serverData();

            try
            {
                string messageToServer = "";
                string messageFromServer = "";

                while (client.clientStatus)
                {
                    //the server is expecting a message from us, so lets send
                    messageToServer = Console.ReadLine();

                    if(messageToServer == "exit")
                    {
                        client.clientStatus = false;//break the loop
                        //send server the text of bye
                        client.streamWriter.WriteLine("Bye");
                        //clean the buffer
                        client.streamWriter.Flush();
                    }

                    if(messageFromServer != "exit")
                    {
                        //send message to the server from console
                        client.streamWriter.WriteLine(messageToServer);
                        client.streamWriter.Flush();

                        //now expects message from server
                        messageFromServer = client.streamReader.ReadLine();
                        //print to console
                        Console.WriteLine("Server: " + messageFromServer);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Problem during reading from server");
            }
        }
    }
}