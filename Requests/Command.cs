/***
 * FileName: Command.cs
 * Purpose: it is a interface that take Route and return a int 
 * Author: Agnita Paul
 * Creation Date: 29 March, 2023
 ***/
using System;

namespace Assi3
{
    interface Command
    {
        int Execute(Route route);
    }
}
