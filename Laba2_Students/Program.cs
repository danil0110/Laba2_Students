using System;
using System.IO;
using System.Collections.Generic;

namespace Laba2_Students
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string directory = Directory.GetCurrentDirectory() + $"\\{Console.ReadLine()}\\";
            string[] filePaths = Directory.GetFiles(directory, "*.csv");
        }
    }
}