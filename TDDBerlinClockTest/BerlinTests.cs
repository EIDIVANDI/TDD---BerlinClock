using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDBerlinClockBL;
using NUnit.Framework;

namespace TDDBerlinClockTest
{
    [TestFixture]
    public class BerlinTests
    {

        string[][] singleMinutes = new String[][] {
                new String[] {"0", "OOOO" } ,
                new String[] {"1", "YOOO" },
                new String[] {"2","YYOO" },
                new String[] {"3","YYYO" },
                new String[] {"4","YYYY" }
            };

        
        [Test]
        [Category("Second Minute Line")]
        [TestCase("0", "OOOO")]
        [TestCase("10", "OOOO")]
        [TestCase("5", "OOOO")]
        [TestCase("55", "OOOO")]
        [TestCase("34", "YYYY")]
        [TestCase("59",	"YYYY")]
        [TestCase("32","YYOO")]
        [TestCase("35", "OOOO")]
        [TestCategory("Test1")]
        public void OneRowMinute(string input,string expected)
        {
            //Given
            string[] exp = new string[] { "", "", "", "", expected };
            var min = Int32.Parse(input);
            var t = new DateTime(2017, 12, 12, 20, min, 0, 0, DateTimeKind.Utc);

            //When            
            var result = new TDDBerlinClock().GenerateBerlinTime(t);


            //Then
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exp[4], result[4]);
        }

        [Test]
        [TestCase("0", "OOOOOOOOOOO")]
        [TestCase("59", "YYRYYRYYRYY")]
        [TestCase("04", "OOOOOOOOOOO")]
        [TestCase("23", "YYRYOOOOOOO")]
        [TestCase("35", "YYRYYRYOOOO")]
        [Category("First Minute Line")]
        public void FiveRowMinute(string input, string expected)
        {
            //Given
            string[] exp = new string[] { "", "", "", expected, "" };
            var min = Int32.Parse(input);
            var t = new DateTime(2017, 12, 12, 20, min, 0, 0, DateTimeKind.Utc);

            //When            
            var result = new TDDBerlinClock().GenerateBerlinTime(t);


            //Then
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exp[3], result[3]);
        }


        [Test]
        [TestCase("0", "OOOO")]
        [TestCase("23", "RRRO")]
        [TestCase("02", "RROO")]
        [TestCase("08", "RRRO")]
        [TestCase("14", "RRRR")]
        [Category("Second Hours Line")]
        public void OneRowHour(string input, string expected)
        {
            //Given
            string[] exp = new string[] { "", "", expected, "", "" };
            var hour = Int32.Parse(input);
            var t = new DateTime(2017, 12, 12, hour, 0, 0, 0, DateTimeKind.Utc);

            //When            
            var result = new TDDBerlinClock().GenerateBerlinTime(t);


            //Then
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exp[2], result[2]);
        }

        [Test]
        [TestCase("0", "OOOO")]
        [TestCase("23", "RRRR")]
        [TestCase("02", "OOOO")]
        [TestCase("08", "ROOO")]
        [TestCase("16", "RRRO")]
        [Category("Second Hour Line")]
        public void FiveRowHour(string input, string expected)
        {
            //Given
            string[] exp = new string[] { "",expected, "", "", "" };
            var hour = Int32.Parse(input);
            var t = new DateTime(2017, 12, 12, hour, 0, 0, 0, DateTimeKind.Utc);

            //When            
            var result = new TDDBerlinClock().GenerateBerlinTime(t);


            //Then
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exp[1], result[1]);
        }
        [Test]
        [TestCase("0", "Y")]
        [TestCase("59", "O")]
        [Category("Seconds Spot")]
        public void RowSeconds(string input, string expected)
        {
            //Given
            string[] exp = new string[] { expected, "",  "", "", "" };
            var sec = Int32.Parse(input);
            var t = new DateTime(2017, 12, 12, 0, 0, sec, 0, DateTimeKind.Utc);

            //When            
            var result = new TDDBerlinClock().GenerateBerlinTime(t);


            //Then
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exp[0], result[0]);
        }

        [Test]
        [Category("Final")]
        [TestCase("00:00:00", "YOOOOOOOOOOOOOOOOOOOOOOO")]
        [TestCase("23:59:59", "ORRRRRRROYYRYYRYYRYYYYYY")]
        [TestCase("16:50:06", "YRRROROOOYYRYYRYYRYOOOOO")]
        [TestCase("11:37:01", "ORROOROOOYYRYYRYOOOOYYOO")]
        [TestCase("23:35:43", "ORRRRRRROYYRYYRYOOOOOOOO")]
        public void Berlin_Clock_Final_Test(string input, string expected)
        {
            //
            string exp = expected;
            var inp = input.Split(':');
            var hr = Int32.Parse(inp[0]);
            var mn = Int32.Parse(inp[1]);
            var sc = Int32.Parse(inp[2]);
            var t = new DateTime(2017, 12, 12, hr , mn, sc, 0, DateTimeKind.Utc);

            //When            
            var result = new TDDBerlinClock().GenerateBerlinTime(t);
            var resultMix = String.Join("", result);

            //Then
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(exp, resultMix);
        }


    }
}
