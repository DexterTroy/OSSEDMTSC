namespace MeasuresTS;

using System;

public class Lcss
{

    public static double Distance(double[] s1, double[] s2)
    {
        var n = s1.Length;
        var m = s2.Length;

        double[,] d = new double[n,m];
        
        for (var i = 0; i < n; ++i)
        {
            d[i,0] = 0;
        }
        for (var j = 0; j < m; ++j)
        {
            d[0,j] = 0;
        }
        d[0,0] = 0;

        for (var i = 1; i < n; ++i)
        {
            for (var j = 1; j < m; ++j)
            {
                d[i,j] = Math.Max(d[i - 1,j], d[i,j - 1]);
                if (s1[i - 1] == s2[j - 1])
                {
                    d[i,j] = Math.Max(d[i,j], d[i - 1,j - 1] + 1);
                }
            }
        }
        return (1 - d[n - 1,m - 1]) / m;
    }
}