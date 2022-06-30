namespace MeasuresTS;	

public class Dtw
{
    public static double Distance(double [] s1, double [] s2) {
		
        var n = s1.Length + 1;
        var m = s2.Length + 1;

        double[,] d = new double[n,m];
		
        for (var i = 0; i < n; i++) {
            d[i,0] = double.MaxValue;
        }
		
        for (var i = 0; i < m; i++) {
            d[0,i] = double.MaxValue;
        }
        
        d[0,0] = 0;

        for (var i = 1; i < n; i++) {
            
            for (var j = 1; j < m; j++) {
                d[i,j] = Math.Abs(s1[i-1] - s2[j-1]) +
                         Math.Min(d[i-1,j-1], Math.Min(d[i-1, j], d[i, j-1]));

            }
        }
		
        return d[n-1, m-1];
    }
    
    public static double Distance(double [] s1, double [] s2, int window) {
        
        var n = s1.Length + 1;
        var m = s2.Length + 1;

        var w = Math.Max(window, Math.Abs(s1.Length-s2.Length));

        double[,] d = new double[n,m];
        
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < m; j++)
            {
                d[i, j] = Double.MaxValue;
            }
        }

        d[0,0] = 0;

        for (var i = 0; i < n; i++) {
            foreach (var j in Enumerable.Range(Math.Max(0,i-w), Math.Min(s2.Length-1, i+w)+1))
            {
                d[i, j] = 0;
            }
        }

        for (var i = 1; i < n; i++) {
            foreach (var j in Enumerable.Range(Math.Max(1,i-w), Math.Min(s2.Length-2, i+w)+1))
            {
                d[i,j] = Math.Abs(s1[i-1] - s2[j-1]) +
                         Math.Min(d[i-1,j-1], Math.Min(d[i-1, j], d[i, j-1]));

            }
        }
        
        return d[n-1, m-1];
    }
}