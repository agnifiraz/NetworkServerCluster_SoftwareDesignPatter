/***
 * FileName: ServerQuery.cs
 * Purpose: class which has a method from the interface. 
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/


using System;

namespace Assi3
{
    class ServerQuery : Query
    {
        public bool Visit(Server server)
        {
            return !server.IsBusy();
        }

    }
}
