using System.Collections.Generic;
using System.Linq;
using static YatzyApp.Extensions.HelperMethods;

namespace YatzyApp.Models
{
    public class YatzyPointsHandler
    {
        public List<YatzyPoint> DieNumbers { get; set; } = new();
        public int DieNumberSum => DieNumbers.Sum(x => ParsePoint(x.Points));
        public int Bonus => DieNumberSum >= 63 ? 50 : 0;
        public List<YatzyPoint> Combinations { get; set; } = new();
        public int TotalSum => DieNumberSum + Bonus + Combinations.Sum(x => ParsePoint(x.Points));
        public YatzyPointsHandler()
        {
            DieNumbers.Add(new YatzyPoint() { Name = "1" });
            DieNumbers.Add(new YatzyPoint() { Name = "2" });
            DieNumbers.Add(new YatzyPoint() { Name = "3" });
            DieNumbers.Add(new YatzyPoint() { Name = "4" });
            DieNumbers.Add(new YatzyPoint() { Name = "5" });
            DieNumbers.Add(new YatzyPoint() { Name = "6" });

            Combinations.Add(new YatzyPoint() { Name = "OnePair" });
            Combinations.Add(new YatzyPoint() { Name = "TwoPairs" });
            Combinations.Add(new YatzyPoint() { Name = "ThreeNumbers" });
            Combinations.Add(new YatzyPoint() { Name = "FourNumbers" });
            Combinations.Add(new YatzyPoint() { Name = "SmallFlush" });
            Combinations.Add(new YatzyPoint() { Name = "BigFlush" });
            Combinations.Add(new YatzyPoint() { Name = "FullHouse" });
            Combinations.Add(new YatzyPoint() { Name = "Random" });
            Combinations.Add(new YatzyPoint() { Name = "Yatzy" });
        }
    }
}