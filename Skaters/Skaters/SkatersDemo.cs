using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Skaters
{
    class SkatersDemo
    {
        private static List<Skaters> skatersArray;
        private static int counter;
        static void Main(string[] args)
        {
            counter = 0;
            skatersArray = new List<Skaters>();
            readFile();
            //Print the file before sorting
            Console.WriteLine("The file before sorting:\n");
            string format = "{0,-20} {1,-20} {2,-20} {3,-35} {4,-35} {5,-20} {6,-20}";
            string result = string.Format(format, "First Name", "Last Name", "Country", "Technical Aspects",
                "Performance Aspects", "Final Score", "Medal");
            string underLine = string.Format(format, "----------", "---------", "-------", "-----------------",
                "-------------------", "-----------", "-----");
            Console.WriteLine(result);
            Console.WriteLine(underLine);
            foreach (Skaters skaters in skatersArray)
            {
                Console.WriteLine(skaters.ToString());
            }
            List<Skaters> skatersArraySorted = skatersArray.OrderByDescending(o => o.FinalScore).ToList();
            skatersArraySorted[0].Medal = "Gold";
            skatersArraySorted[1].Medal = "Silver";
            skatersArraySorted[2].Medal = "Bronze";
            //Print the final result after sorting
            Console.WriteLine("\n\nThe final result after sorting:\n");
            Console.WriteLine(result);
            Console.WriteLine(underLine);
            foreach (Skaters skaters in skatersArraySorted)
            {
                Console.WriteLine(skaters.ToString());
            }
        }
        public static void readFile()
        {
            string tempFirstName, tempLastName, tempCountry, temp1, temp2;
            string[] tempTechAsp;
            string[] tempPerAsp;
            double[] tempTechnicalAspects = null;
            double[] tempPerformanceAspects = null;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\mhmdm\\Desktop\\Google Drive\\Study in Canada\\JOHNABBOTT\\The study\\.NET PROGRAMMING FUNDAMENTALS\\Final Project\\Pairs.txt");

                //Read the first line of text
                string line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    tempFirstName = line;
                    tempLastName = sr.ReadLine();
                    tempCountry = sr.ReadLine();
                    temp1 = sr.ReadLine();
                    tempTechAsp = temp1.Split(' ');
                    temp2 = sr.ReadLine();
                    tempPerAsp = temp2.Split(' ');
                    tempTechnicalAspects = new double[tempTechAsp.Length];
                    tempPerformanceAspects = new double[tempPerAsp.Length];
                    for (int i = 0; i < 8; i++)
                    {
                        tempTechnicalAspects[i] = double.Parse(tempTechAsp[i]);
                        tempPerformanceAspects[i] = double.Parse(tempPerAsp[i]);
                    }

                    Skaters tempSkaters = new Skaters(tempFirstName, tempLastName, tempCountry, tempTechnicalAspects, tempPerformanceAspects);
                    skatersArray.Add(tempSkaters);
                    counter++;
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
            }
        }
    }
}
