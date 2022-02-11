using PowerArgs;
using System;

namespace Bitrix24RestApiTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Args.InvokeAction<ConsoleApp>(args);
        }
    }
}
