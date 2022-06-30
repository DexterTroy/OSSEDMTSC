namespace MeasuresTS;

public class Dtdc
{
    public static double Distance(double[] s1, double[] s2, double alpha, double beta)
    {
        double[] c = new double[s1.Length];
        
        double[] d = new double[s2.Length];

        for (var i = 1; i < s1.Length - 1; i++)
        {
            c[i] = (s1[i] - s1[i-1]) + ((s1[i+1] - s1[i-1]) / 2);
        }
        
        for (var i = 1; i < s2.Length - 1; i++)
        {
            d[i] = (s2[i] - s2[i-1]) + ((s2[i+1] - s2[i-1]) / 2);
        }
        
        double[] e = new double[s1.Length];
        
        double[] f = new double[s2.Length];
        
        for (var i = 1; i < s1.Length - 1; i++)
        {
            for (var j = 1; j < s1.Length - 1; j++)
            {
                e[i] += s1[j] * Math.Cos((Math.PI / s1.Length) * (j - (1 / 2)) * (i - 1));
            }
        }

        for (var i = 1; i < s2.Length - 1; i++)
        {
            for (var j = 1; j < s2.Length - 1; j++)
            {
                f[i] += s2[j] * Math.Cos((Math.PI / s2.Length) * (j - (1 / 2)) * (i - 1));
            }
        }
        
        var x = Dtw.Distance(s1, s2);
        
        var y = Dtw.Distance(c, d);

        var z = Dtw.Distance(e, f);

        return alpha * x + beta * y  + (1 - alpha - beta) * z;
        
    }
}