namespace YatzyApp.Models;

public class YatzyPointsHandler
{
    public List<YatzyPoint> DieNumbers { get; set; } = new();
    public int DieNumberSum => DieNumbers.Sum(x => x.Points ?? 0);
    public int Bonus => DieNumberSum >= 63 ? 50 : 0;
    public List<YatzyPoint> Combinations { get; set; } = new();
    public int TotalSum => DieNumberSum + Bonus + Combinations.Sum(x => x.Points ?? 0);

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

    public bool ValidatePoints(out string? erroredPoint, out int erroredValue)
    {
        erroredPoint = null;
        erroredValue = 0;
        foreach (YatzyPoint item in DieNumbers)
        {
            int nameValue = int.Parse(item.Name);
            int? pointsValue = item.Points;
            if (pointsValue is not null && (pointsValue < 0 || pointsValue > 5 * nameValue || pointsValue % nameValue != 0))
            {
                erroredPoint = item.Name;
                erroredValue = item.Points.GetValueOrDefault();
                item.Points = null;
                return false;
            }
        }
        return true;
    }
}