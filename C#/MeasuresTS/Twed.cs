namespace MeasuresTS;

public class Twed
{
    public static double Distance(double [] s1, double [] s2, double lambda, double v) {
		
        var n = s1.Length + 1;
        var m = s2.Length + 1;

        double[,] d = new double[n,m];

        d[0, 0] = 0;

        d[1, 0] = Math.Pow(s1[0], 2);
        d[0, 1] = Math.Pow(s2[0], 2);

        for (var i = 2; i < n; i++) {
            d[i,0] = d[i-1, 0] + Math.Pow(s1[i - 2] - s1[i - 1], 2);
        }

        for (var i = 2; i < m; i++) {
            d[0,i] = d[0, i-1] + Math.Pow(s2[i - 2] - s2[i - 1], 2);
        }

        for (var i = 1; i < n; i++) {
            
            for (var j = 1; j < m; j++)
            {

                var dist1 = 0.0;
                var dist2 = 0.0;
                var dist3 = 0.0;
                
                if (i > 1 && j > 1)
                {
                    dist1 = d[i - 1, j - 1] + v * Math.Abs(i - j) * 2 + Math.Pow(s1[i - 1] - s2[j - 1], 2) +
                                              Math.Pow(s1[i - 2] - s2[j - 2], 2);
                }
                else
                {
                    dist1 = d[i - 1, j - 1] + v * Math.Abs(i - j) + Math.Pow(s1[i - 1] - s2[j - 1], 2);
                }
                if (i > 1)
                {
                    dist2 = d[i - 1, j] + Math.Pow(s1[i - 1] - s1[i - 2], 2) + lambda + v;
                }
                else
                {
                    dist2 = d[i - 1, j] + Math.Pow(s1[i - 1], 2) + lambda;
                }
                if (j > 1)
                {
                    dist3 = d[i, j - 1] + Math.Pow(s2[j - 1] - s2[j - 2], 2) + lambda + v;
                }
                else
                {
                    dist3 = d[i, j - 1] + Math.Pow(s2[j - 1], 2) + lambda;
                }

                d[i, j] = Math.Min(dist1, Math.Min(dist2, dist3));
            }
        }

        return d[n-1, m-1];
    }
}