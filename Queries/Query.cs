/***
 * FileName: Query.cs
 * Purpose: Interface which accept server and return bool to check if server is busy or not
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/

using System;

namespace Assi3
{
    interface Query
    {
        bool Visit(Server server);


    }
}
