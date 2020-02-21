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
            List<Students> students = new List<Students>();
            int count = 0;
            foreach (string path in filePaths)
            {
                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    students.Add(new Students() { name = line });
                    count++;
                }
            }

        }
    }
}