namespace MeasuresTS;

using System;

public class Msm
{

    private static double FindCost(double newPoint, double x, double y, double cValue)
    {
        double dist = 0;

        if (((x <= newPoint) && (newPoint <= y)) || ((y <= newPoint) && (newPoint <= x)))
        {
            dist = cValue;
        }
        else
        {
            dist = cValue + Math.Min(Math.Abs(newPoint - x), Math.Abs(newPoint - y));
        }

        return dist;
    }

    public static double Distance(double[] s1, double[] s2, double cValue)
    {

        var n = s1.Length;
        var m = s2.Length;
        
        double[,] d = new double[n,m];

        d[0,0] = Math.Abs(s1[0] - s2[0]);

        for (var i = 1; i < m; i++)
        {
            d[i,0] = d[i - 1,0] + FindCost(s1[i], s1[i - 1], s2[0], cValue);
        }

        for (var i = 1; i < n; i++)
        {
            d[0,i] = d[0,i - 1] + FindCost(s2[i], s1[0], s2[i - 1], cValue);
        }

        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                d[i,j] = Math.Min(d[i - 1,j - 1] + Math.Abs(s1[i] - s2[j]), Math.Min(d[i - 1,j] + FindCost(s1[i], s1[i - 1], s2[j], cValue), d[i,j - 1] + FindCost(s2[i], s1[i], s2[j - 1], cValue)));
            }
        }

        return d[m - 1,n - 1];
    }
}
