namespace MeasuresTS;
public class Cid
{
    public static double Distance(double[] s1, double[] s2)
    {
        var d = Dtw.Distance(s1, s2);

        var ca = Math.Abs(s1[0] - s1[1]);
        
        var cb = Math.Abs(s2[0] - s2[1]);

        for (var i = 1; i < s1.Length - 1; i++)
        {
            ca += Math.Abs(s1[i] - s1[i - 1]);
        }
        
        for (var i = 1; i < s2.Length - 1; i++)
        {
            cb += Math.Abs(s2[i] - s2[i - 1]);
        }

        return d * (Math.Max(ca, cb) / Math.Min(ca, cb));
    }
}