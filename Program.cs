using System;
using System.Collections.Generic;

namespace Assi3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Server> Servers = new List<Server>();
            Queue<Request> PendingRequests = new Queue<Request>();          

            Console.WriteLine("Please enter a command.");
            string command = "";

            while(command != "quit") {
                string[] commandArgs = command.Split(":");
                Console.WriteLine();

                switch(commandArgs[0]) {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("createserver\t\tCreate a new server.");
                        Console.WriteLine("deleteserver:[id]\tDelete server #ID.");
                        Console.WriteLine("listservers\t\tList all servers.");
                        Console.WriteLine("new:[path]:[payload]\tCreate a new pending request.");
                        Console.WriteLine("dispatch\t\tSend a pending request to a server.");
                        Console.WriteLine("server:[id]\t\tHave server #ID execute its pending request and print the result.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    case "createserver":
                        Servers.Add(new Server());
                        Console.WriteLine("Created Server  " + (Servers.Count-1));

                        break;
                    case "deleteserver":
                        int serverIdToDelete = int.Parse(commandArgs[1]);
                        if (serverIdToDelete <= Servers.Count)
                        {
                            Servers.RemoveAt(serverIdToDelete );
                            Console.WriteLine($"Deleted server {serverIdToDelete}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid server ID.");
                            
                        }
                        break;
                    case "listservers":
                        if (Servers.Count == 0)
                        {
                            Console.WriteLine($"No Servers Available.");

                        }
                        for (int i = 0; i < Servers.Count; i++)
                        {
                            Console.WriteLine($"{i}         Server");
                        }
                        break;
                    case "new":
                        string route = commandArgs[1];
                        try
                        {
                            int payload = int.Parse(commandArgs[2]);
                            PendingRequests.Enqueue(new Request(route, payload));
                            Console.WriteLine($"Created request with data {payload} going to {route}.");
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid payload specified." + e.Message);
                            break;
                        }
                    case "dispatch":
                        if(PendingRequests.Count== 0)
                        {
                             Console.WriteLine("No pending requests.");
                            break;
                        }
                        Request r = PendingRequests.Dequeue();
                        ServerQuery serverQuery = new ServerQuery();
                        bool checking = false;
                        for (int i = 0; i < Servers.Count; ++i)
                        {
                            Server server = Servers[i];
                            if (server.Accept(serverQuery))
                            {
                                checking = true;
                                server.HandleRequest(r);
                                Console.WriteLine("Sent request to Server " + i + ".");
                                break;
                            }
                        }
                        if (!checking)
                        {
                            PendingRequests.Enqueue(r);
                            Console.WriteLine("No servers available (521).");
                            break;
                        }
                        break;
                    case "server":
                        int serverNumber = int.Parse(commandArgs[1]);
                        if (serverNumber >= 0 && serverNumber < Servers.Count)
                        {
                            Servers[serverNumber].RouteProcess();
                            break;
                        }
                        Console.WriteLine("Invalid ID specified.");
                        break;                      
                    default:
                        if(command != "") {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();
            }
        }
    }
}
