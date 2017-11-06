using System;
using System.Collections.Generic;
using System.Linq;

namespace DataInfrastructure.Infrastructure
{
    static public class Extension
    {
        static public String DefaultIfNull(this String src)
        {
           return src != null ? src.ToString() : String.Empty;
            
        }

        public static TimeSpan AsTimeSpanFormat(this string InputTime)
        {
            TimeSpan time = new TimeSpan();
            int hour=0;
            int minutes = 0;
            int seconds =0;
            try
            {
                time = TimeSpan.Parse(InputTime);
            }
            catch
            {
                string [] word = InputTime.Split(':');
                
                if (word.Length == 2)
                {
                    string[] meridian = word[1].Split(' ');

                    if (meridian[1] == "AM")
                        hour = Convert.ToInt16(word[0]);
                    else
                        hour = Convert.ToInt16(word[0]) + 12;

                    minutes = Convert.ToInt16(meridian[0]);
                }

                if (word.Length == 3)
                {
                    string[] meridian = word[2].Split(' ');

                    if (meridian[1] == "AM")
                        hour = Convert.ToInt16(word[0]);
                    else
                        hour = Convert.ToInt16(word[0]) + 12;

                    minutes = Convert.ToInt16(word[1]);
                    seconds = Convert.ToInt16(meridian[0]);
                }

                time = new TimeSpan(hour, minutes, seconds);
            }
            return time;
        }

        public static List<DateTime> Clone(this List<DateTime> listToClone)
        {
            
            return (from list in listToClone.ToList()
                       select new DateTime(list.Year,list.Month,list.Day,list.Hour,list.Minute,list.Second)).ToList();
        }


        public static int ASCII(this char character)
        {

            return System.Convert.ToInt32(character);
        }

     
    }
}
