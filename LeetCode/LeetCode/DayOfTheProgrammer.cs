using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class DayOfTheProgrammer
    {
        public static string Solve(int year)
        {
            int dayoftheprogrammer = 256;
            int offset = 0;
            var theDate = new DateTime(year, 1, 1);

            if (year < 1700 || year > 2700)
                return String.Empty;

            if (year == 1918)
                offset = 13;
            else if (year < 1918 && year % 100 == 0)
                offset = -1;


            return theDate.AddDays(dayoftheprogrammer - 1 + offset).ToString("dd.MM.yyyy");

        }
    }
}
