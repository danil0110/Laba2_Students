using System;
using System.IO;
using System.Collections.Generic;

namespace Laba2_Students
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string directory = GetDirectory();
            string[] filePaths = GetFilePaths(directory);
            List<Students> students = new List<Students>();

            foreach (string path in filePaths)
            {
                StreamReader sr = new StreamReader(path);
                int n = Convert.ToInt32(sr.ReadLine()),
                    count = 0;
                string line;

                while (count != n)
                {
                    line = sr.ReadLine();
                    students.Add(new Students() {name = line});
                    string[] temp = students[students.Count - 1].name.Split(',');
                    if (temp[6] == "TRUE")
                    {
                        students.RemoveAt(students.Count - 1);
                        n--;
                        continue;
                    }

                    students[students.Count - 1].name = temp[0];
                    for (int i = 1; i < 6; i++)
                        students[students.Count - 1].grade[i - 1] = Convert.ToInt32(temp[i]);

                    students[students.Count - 1].average =
                        students[students.Count - 1].AverageCount(students[students.Count - 1].grade);

                    count++;
                }
            }

            Students temp_average = new Students();
            for (int i = 0; i < students.Count - 1; i++)
            for (int j = 0; j < students.Count - i - 1; j++)
                if (students[j + 1].average > students[j].average)
                {
                    temp_average = students[j + 1];
                    students[j + 1] = students[j];
                    students[j] = temp_average;
                }

            using (StreamWriter sw = new StreamWriter(directory + "rating.csv", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < students.Count * 0.4; i++)
                    sw.WriteLine($"{students[i].name}: {students[i].average}");
                sw.Write($"\nМинимальный проходной балл - {students[Convert.ToInt32(students.Count * 0.4)].average}");
            }
        }

        public static string GetDirectory()
        {
            Console.Write("Введите название директории: ");
            string directory = Directory.GetCurrentDirectory() + $"\\{Console.ReadLine()}\\";
            if (File.Exists(directory + "rating.csv"))
                File.Delete(directory + "rating.csv");
            return directory;
        }

        public static string[] GetFilePaths(string directory)
        {
            string[] filePaths = Directory.GetFiles(directory, "*.csv");
            return filePaths;
        }

    }
}