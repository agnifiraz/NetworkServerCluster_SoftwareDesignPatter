/***
 * FileName: AbstractServer.cs
 * Purpose: Server info process 
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/

using System;

namespace Assi3
{
    interface AbstractServer
    {
        

        bool IsBusy();
        void HandleRequest(Request r);
        void RouteProcess();
        bool Accept(Query query);
    }
}
