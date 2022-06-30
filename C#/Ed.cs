namespace MeasuresTS;

public class Ed
{
    public static double Distance(double[] s1, double[] s2) {
        var n = s1.Length;
        var m = s2.Length;

        if (n > m)
            n = m;

        double sum = 0;

        for (var i = 0; i < n; i++)
            sum += Math.Pow(s1[i]-s2[i], 2);

        return Math.Sqrt(sum);
    }
}