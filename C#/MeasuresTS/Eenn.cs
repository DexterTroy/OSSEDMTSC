namespace MeasuresTS;

//Currently only takes the weight.

public class EENN
{
    private delegate double DistanceMeasure();
    
    public static double Run(double[][] train, double [][] test)
    {
        double correct = 0;
        double count = 0;

        for (var i = 0; i < test.Length; i++)
        {
            var min = Enumerable.Repeat(double.MaxValue, 9).ToArray();
            
            var winner = Enumerable.Repeat(double.MaxValue, 9).ToArray();
    
            var testLabel = test[i][test[i].Length - 1];
    
            var sliceTest = test[i].Take(test[i].Length - 1).ToArray();

            for (var j = 0; j < train.Length; j++)
            {
                
                var distArray = Enumerable.Repeat(double.MaxValue, 9).ToArray();
                
                var trainLabel = train[j][train[j].Length - 1];
                
                var sliceTrain = train[j].Take(train[j].Length - 1).ToArray();

                //Parallel Loop for speed up
                
                List<DistanceMeasure> functionList = new List<DistanceMeasure>();
                
                functionList.Add(() => Lcss.Distance(sliceTrain, sliceTest));
                functionList.Add(() => Wdtw.Distance(sliceTrain, sliceTest, 0.07));
                functionList.Add(() => Cid.Distance(sliceTrain, sliceTest));
                functionList.Add(() => Twed.Distance(sliceTrain, sliceTest,0.25,1));
                functionList.Add(() => Ddtw.Distance(sliceTrain, sliceTest, 0.117));
                functionList.Add(() => Msm.Distance(sliceTrain, sliceTest, 0.244));
                functionList.Add(() => Ed.Distance(sliceTrain, sliceTest));
                functionList.Add(() => Dtdc.Distance(sliceTrain, sliceTest, 0.1, 0.1));
                functionList.Add(() => Dtw.Distance(sliceTrain, sliceTest));

                Parallel.For(0, distArray.Length, k =>
                {
                    distArray[k] = functionList[k].Invoke();
                    
                    //Linear method
                    
                    // distArray[0] = Lcss.Distance(sliceTrain, sliceTest);
                    // distArray[1] = Wdtw.Distance(sliceTrain, sliceTest, 0.07);
                    // distArray[2] = Dtw.Distance(sliceTrain, sliceTest);
                    // distArray[3] = Cid.Distance(sliceTrain, sliceTest);
                    // distArray[4] = Twed.Distance(sliceTrain, sliceTest,0.25,1);
                    // distArray[5] = Ddtw.Distance(sliceTrain, sliceTest, 0.117);
                    // distArray[6] = Dtdc.Distance(sliceTrain, sliceTest, 0.1, 0.1);
                    // distArray[7] = Msm.Distance(sliceTrain, sliceTest, 0.244);
                    // distArray[8] = Ed.Distance(sliceTrain, sliceTest);    
                });
                
                for (var k = 0; k < distArray.Length; k++)
                {
                    if (distArray[k] < min[k])
                    {
                        min[k] = distArray[k];
                        winner[k] = trainLabel;
                    }
                }
            }
            
            var most = (from item in winner
                    group item by item into g
                    orderby g.Count() descending
                    select g.Key).First();
            
            if (most.Equals(testLabel))
            {
                correct += 1;
            }
            
            count += 1;
        }

        var errorRate = (count - correct) / count;
    
        return errorRate;
    }
}