using System;

namespace Skaters
{
    public class Skaters
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public double[] TechnicalAspects { get; set; }
        public double[] PerformanceAspects { get; set; }
        public double FinalScore { get; set; }
        public string Medal { get; set; }
        public Skaters(string FirstName, string LastName, string Country, double[] TechnicalAspects, double[] PerformanceAspects)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Country = Country;
            this.TechnicalAspects = TechnicalAspects;
            this.PerformanceAspects = PerformanceAspects;
            this.Medal = "NONE";
            calcFinalScore();
        }

        private void calcFinalScore()
        {
            double techSum = 0;
            int counter = 0;
            foreach (double score in TechnicalAspects)
            {
                techSum += score;
                counter++;
            }
            techSum = techSum / counter;

            double perSum = 0;
            counter = 0;
            foreach (double score in PerformanceAspects)
            {
                perSum += score;
                counter++;
            }
            perSum = perSum / counter;
            FinalScore = techSum + perSum;
            FinalScore = Math.Round(FinalScore, 3);
        }


        public override string ToString()
        {
            string format = "{0,-20} {1,-20} {2,-20} {3,-35} {4,-35} {5,-20} {6,-20}";
            string result = string.Format(format,
                 FirstName, LastName, Country, string.Join(" ", TechnicalAspects), string.Join(" ", PerformanceAspects), FinalScore, Medal);
            return result;
        }


    }
}
