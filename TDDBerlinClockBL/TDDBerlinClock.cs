using System;

namespace TDDBerlinClockBL
{
    public class TDDBerlinClock
    {
        public TDDBerlinClock()
        {
        }

        public string[] GenerateBerlinTime(DateTime t)
        {
            var tmp = ShowTime(t);

            return new string[] { GetSecond(tmp), GetFiveHour(tmp), GetOneHour(tmp), GetFiveMinutes(tmp), GetOneMinutes(tmp) };
        }

        private string GetFiveMinutes(string t)
        {
            int min = int.Parse(t.Split(':')[1]);
            string result = string.Empty;

            var div = min / 5;
            var singleMinutes = new String[] {
                "OOOOOOOOOOO",
                "YOOOOOOOOOO",
                "YYOOOOOOOOO",
                "YYROOOOOOOO",
                "YYRYOOOOOOO",
                "YYRYYOOOOOO",
                "YYRYYROOOOO",
                "YYRYYRYOOOO",
                "YYRYYRYYOOO",
                "YYRYYRYYROO",
                "YYRYYRYYRYO",
                "YYRYYRYYRYY",
            };

            return singleMinutes[div];
        }

        private string GetOneHour(string t)
        {
            int hour = int.Parse(t.Split(':')[0]);
            string result = string.Empty;

            var div = hour % 5;
            var singleMinutes = new String[] {
                "OOOO",
                "ROOO",
                "RROO",
                "RRRO",
                "RRRR"
            };

            return singleMinutes[div];
        }

        private string GetFiveHour(string t)
        {
            int min = int.Parse(t.Split(':')[0]);
            string result = string.Empty;

            var mod = min / 5;
            var singleMinutes = new String[] {
                "OOOO",
                "ROOO",
                "RROO",
                "RRRO",
                "RRRR"
            };

            return singleMinutes[mod];
        }

        private string GetSecond(string t)
        {
            int second = int.Parse(t.Split(':')[2]);
            string result = string.Empty;

            var mod = second % 2;
            var singleMinutes = new String[] {
                "Y",
                "O"
            };

            return singleMinutes[mod];
        }
        
        private string GetOneMinutes(string t)
        {
            int min = int.Parse(t.Split(':')[1]);
            string result = string.Empty;

            var mod = min % 5;
            var singleMinutes = new String[] {
                "OOOO",
                "YOOO",
                "YYOO",
                "YYYO",
                "YYYY"
            };

            return singleMinutes[mod];
        }
        public string ShowTime(DateTime t)
        {
            return t.ToLongTimeString();
        }
    }
}