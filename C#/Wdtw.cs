namespace MeasuresTS;

public class Wdtw
{
    
    /*
    Calculates the weight every distance call this could just be saved as a part of the object. Will move to more
    object orientated programming at some point as vast improvements can be made
    */

    private static double Weight(double a, double g, double halfLength)
    {
        return 1 / (1 + Math.Exp(-g * (a - halfLength)));
    }
    
    public static double Distance(double[] s1, double[] s2, double g)
    {

        var n = s1.Length + 1;
        var m = s2.Length + 1;

        var halfLength = (n - 1) / 2;

        double[,] d = new double[n,m];

        for (var i = 0; i < n; i++)
        {
            d[i,0] = double.PositiveInfinity;
        }

        for (var i = 0; i < m; i++)
        {
            d[0,i] = double.PositiveInfinity;
        }

        d[0,0] = 0;

        for (var i = 1; i < n; i++)
        {
            for (var j = 1; j < m; j++)
            {
                var w = Weight(Math.Abs(i - j), g, halfLength);
                d[i,j] = w * Math.Abs(s1[i - 1] - s2[j - 1]) + Math.Min(d[i - 1,j - 1], Math.Min(d[i - 1,j], d[i,j - 1]));
            }
        }
        return d[n - 1,m - 1];
    }
}