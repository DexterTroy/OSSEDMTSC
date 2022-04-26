import java.util.Arrays;

//Need a more effective way to pass in distance measures as currently it's a manual edit.

public class ONN {

    public static double run(double[][] trainData, double[][] testData) {

        double correct = 0;
        double count = 0;

        for(int i = 0; i < testData.length; i++) {

            double nearestN = Double.POSITIVE_INFINITY;
            double winner = Double.POSITIVE_INFINITY;

            double[] s1 = Arrays.copyOfRange(testData[i], 0, testData[i].length - 1);
            double testLabel = testData[i][testData[i].length - 1];

            for(int j = 0; j < trainData.length; j++) {

                double trainLabel = trainData[j][trainData[j].length - 1];

                double[] s2 = Arrays.copyOfRange(trainData[j], 0, trainData[j].length - 1);

                double dist = ED.distance(s1, s2);

                if (dist < nearestN) {
                    nearestN = dist;
                    winner = trainLabel;
                }
            }
            if (winner == testLabel) {
                correct += 1;
            }
            count += 1;
        }
        System.out.println((correct));
        return (count - correct) / count;
    }
}