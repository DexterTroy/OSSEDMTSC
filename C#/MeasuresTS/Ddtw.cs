namespace MeasuresTS;

public class Ddtw
{
    public static double Distance(double[] s1, double[] s2, double alpha)
    {
        double[] c = new double[s1.Length];
        
        double[] d = new double[s2.Length];

        for (var i = 1; i < s1.Length - 1; i++)
        {
            c[i] = (s1[i] - s1[i-1] + (s1[i+1] - s1[i-1]) / 2) / 2;
        }
        
        for (var i = 1; i < s2.Length - 1; i++)
        {
            d[i] = (s2[i] - s2[i-1] + (s2[i+1] - s2[i-1]) / 2) / 2;
        }

        // for (var i = 1; i < s1.Length - 1; i++)
        // {
        //     c[i] = (s1[i] - s1[i-1]) + ((s1[i+1] - s1[i-1]) / 2);
        // }
        //
        // for (var i = 1; i < s2.Length - 1; i++)
        // {
        //     d[i] = (s2[i] - s2[i-1]) + ((s2[i+1] - s2[i-1]) / 2);
        // }
        
        var x = Dtw.Distance(s1, s2);
        
        var y = Dtw.Distance(c, d);

        return alpha * x + (1 - alpha) * y;
        
    }
}