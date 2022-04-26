public class WDTW {

    private static double weight(double a, double g, double halfLength) {
        return 1 / (1 + Math.exp(-g * (a-halfLength)));
    }

    public static double distance(double[] s1, double[] s2, double g) {

        int n = s1.length + 1;
        int m = s2.length + 1;

        int halfLength = (n-1) /2;

        double[][] d = new double[n][m];

        for (int i = 0; i < n; i++) {
            d[i][0] = Double.POSITIVE_INFINITY;
        }

        for (int i = 0; i < m; i++) {
            d[0][i] = Double.POSITIVE_INFINITY;
        }

        d[0][0] = 0;

        for (int i = 1; i < n; i++) {
            for (int j = 1; j < m; j++) {
                double w = weight(Math.abs(i-j), g, halfLength);
                d[i][j] = w * Math.abs(s1[i-1] - s2[j-1]) +
                        Math.min(d[i-1][j-1], Math.min(d[i-1][j], d[i][j-1]));
            }
        }
        return d[n-1][m-1];
    }

}
