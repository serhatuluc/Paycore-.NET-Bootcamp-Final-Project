using System;
using System.Net;

namespace TCPSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            IPAddress myIP = IPAddress.Parse("161.9.67.224");
            int port = 3000;
            Server server = new Server(myIP, port);

            server.startListening();
            Console.WriteLine("Server Started");

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Waiting for the connection");

            //if somebody wants to connect accept it
            server.acceptClient();
            Console.WriteLine("Client connected");

            string messageFromClient = "";
            string messageToClient = "";

            try
            {
                server.clientData();

                while (server.serverStatus)
                {
                    //only when a client is connected
                    if (server.socketForClient.Connected)
                    {
                        //We are expecting a message from a client
                        messageFromClient = server.streamReader.ReadLine();
                        //print the message that the client send to server
                        Console.WriteLine("Client: " + messageFromClient);

                        //if the client says goodbye
                        if (messageFromClient == "exit")
                        {
                            server.serverStatus = false;//break the loop
                                                        //stop reading and writing from client
                            server.streamReader.Close();
                            server.streamWriter.Close();
                            server.networkStream.Close();
                            return;
                        }

                        //okay the client already said something, its my turn now
                        Console.Write("Server : ");
                        //read from my console
                        messageToClient = Console.ReadLine();
                        //and sent to client
                        server.streamWriter.WriteLine(messageToClient);

                        //cleans the buffer, when data is exchanged between processes the buffer stores that data temporarily
                        //so everytime we need to clear the buffer
                        server.streamWriter.Flush();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}