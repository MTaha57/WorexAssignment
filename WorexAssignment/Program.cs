using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WorexAssignment
{
    //Represent as a table in DB
    public class ActiveProcessDetails
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public int DurationInSec { get; set; }
        public string TimeStamp { get; set; }

        public static List<ActiveProcessDetails> PopulateData()
        {
            return new List<ActiveProcessDetails>
            {
                new ActiveProcessDetails { Id = 1, ProcessName = "Brave", DurationInSec = 19, TimeStamp = "08-08-2022 12:23:00" },
                new ActiveProcessDetails { Id = 2, ProcessName = "Visual Studio", DurationInSec = 20, TimeStamp = "08-08-2022 12:23:00"},
                new ActiveProcessDetails { Id = 3, ProcessName = "Github Disktop", DurationInSec = 30, TimeStamp = "08-08-2022 12:23:00"},
                new ActiveProcessDetails { Id = 4, ProcessName = "Google Chrome", DurationInSec = 12, TimeStamp = "08-09-2022 12:23:00"},
                new ActiveProcessDetails { Id = 5, ProcessName = "Microsoft Edge", DurationInSec = 19, TimeStamp = "08-10-2022 12:00:00"},
                new ActiveProcessDetails { Id = 6, ProcessName = "Brave", DurationInSec = 19, TimeStamp = "08-10-2022 14:23:00"},
                new ActiveProcessDetails { Id = 7, ProcessName = "Github Desktop", DurationInSec = 18, TimeStamp = "08-12-2022 15:23:00"},
                new ActiveProcessDetails { Id = 8, ProcessName = "VSdebugger", DurationInSec = 19, TimeStamp = "08-13-2022 11:20:11"},
                new ActiveProcessDetails { Id = 9, ProcessName = "Firefox", DurationInSec = 20, TimeStamp = "08-13-2022 12:23:00"},
                new ActiveProcessDetails { Id = 10, ProcessName = "Visual Studio", DurationInSec = 19, TimeStamp = "08-13-2022 12:40:00"},
            };

        }
    }
    internal class Program
    {
        static bool SolutionOne(int[] nums, int number)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var differencePos = j - i;
                    if (nums[i] == nums[j] && differencePos <= number)
                        return true;
                }
            }

            return false;
        }
        static bool SolutionTwo(string[] strings, string[] pattern)
        {
            int patternIndex = 0;
            bool result = false;
            for (int i = 0; i <= strings.Length - 2; i++)
            {
                bool firstPart = (strings[i] == strings[i + 1] && pattern[patternIndex] != pattern[patternIndex + 1]);
                bool secondPart = (strings[i] != strings[i + 1] && pattern[patternIndex] == pattern[patternIndex + 1]);
                bool IsMatchPattern = firstPart || secondPart;

                if (!IsMatchPattern)
                {
                    result = true;
                    patternIndex++;
                }
                else
                    result = false;
            }

            return result;
        }
        static void Main(string[] args)
        {
            #region SolutionOne
            //int k = 3;
            //int[] nums = { 0, 1, 2, 3, 5, 2 };

            //Console.WriteLine(SolutionOne(nums, k));
            #endregion

            #region SolutionTwo
            //string[] strings = { "cat", "dog", "dog" };
            //string[] pattern = { "a", "b", "b" };

            //Console.WriteLine(SolutionTwo(strings, pattern));
            #endregion

            #region Database Q2
            var Browsers = new List<string> { "Google Chrome", "Microsoft Edge", "Firefox" };
            var dateFilterStart = Convert.ToDateTime("08-08-2022 12:00:00");
            var dateFilterEnd = Convert.ToDateTime("08-10-2022 12:00:00");

            var data = ActiveProcessDetails.PopulateData();

            var result = data
                 .Where(x => Browsers.Contains(x.ProcessName)
                 && Convert.ToDateTime(x.TimeStamp) >= dateFilterStart
                 && Convert.ToDateTime(x.TimeStamp) <= dateFilterEnd
                 )
                 .Sum(x => x.DurationInSec);

            Console.WriteLine(result);
            #endregion



        }
    }
}
