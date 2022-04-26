public class ED {

    public static double distance(double[] s1, double[] s2) {
        int n = s1.length;
        int m = s2.length;

        if (n > m)
            n = m;

        double sum = 0;

        for (int i = 0; i < n; i++)
            sum += Math.pow(s1[i]-s2[i], 2);

        return sum;
    }

}
