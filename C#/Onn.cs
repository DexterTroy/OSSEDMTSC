namespace MeasuresTS;

public class OneNearestNeighbor
{
    public static double Run(double[][] train, double [][] test, int a)
    {
    
        double correct = 0;
        double count = 0;
    
        for (var i = 0; i < test.Length; i++)
        {
            var min = double.MaxValue;
            var winner = double.MaxValue;
    
            var testLabel = test[i][test[i].Length - 1];
    
            var sliceTest = test[i].Take(test[i].Length - 1).ToArray();

            for (var j = 0; j < train.Length; j++)
            {
    
                var trainLabel = train[j][train[j].Length - 1];
                
                var sliceTrain = train[j].Take(train[j].Length - 1).ToArray();

                var dist = Dtw.Distance(sliceTrain, sliceTest, a);

                if (dist < min)
                {
                    min = dist;
                    winner = trainLabel;
                }
            }

            if (winner.Equals(testLabel))
            {
                correct += 1;
            }
            
            count += 1;
        }

        var errorRate = (count - correct) / count;
    
        return errorRate;
    }
}