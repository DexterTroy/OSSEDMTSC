namespace MeasuresTS;

public class DataLoader
{
    public static double[][] LoadCsv(string filePath)
    {
        return File.ReadLines(filePath)
                    .Select(x => Array
                        .ConvertAll(x.Split(','), Double.Parse))
                    .ToArray();
    }
}