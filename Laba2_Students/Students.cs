using System;

namespace Laba2_Students
{
    public class Students
    {
        public string name;
        public int[] grade = new int[5];
        public double average;

        public double AverageCount(int[] grade)
        {
            double sum = 0;
            foreach (var mark in grade)
                sum += mark;
            return Math.Round(Convert.ToDouble(sum / 5), 3);
        }
    }
}