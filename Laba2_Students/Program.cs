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
                int n = Convert.ToInt32(sr.ReadLine());
                string line;
                while (count != n)
                {
                    line = sr.ReadLine();
                    students.Add(new Students() { name = line });
                    string[] temp = students[count].name.Split(',');
                    if (temp[6] == "TRUE")
                    {
                        students.RemoveAt(count);
                        n--;
                        continue;
                    }
                    students[count].name = temp[0];
                    for (int i = 1; i < 6; i++)
                    {
                        students[count].grade[i - 1] = Convert.ToInt32(temp[i]);
                        Console.Write(students[count].grade[i - 1] + " ");
                    }
                    count++;
                }
            }

        }
    }
}