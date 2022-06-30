namespace MeasuresTS;

public class Test
{
    
    private delegate double DistanceMeasure();
    
    public static void Main()
    {
        /*All that is required to add a dataset is to add the name to this list. The data set must be a CSV with the
        last value being of the class. Sourced from www.timeseriesclassification.com*/

        var dataSets = new[]
        {
            "Adiac",
            "Beef",
            "CBF",
            "FaceAll",
            "FaceFour",
            "FiftyWords",
            "Fish",
            "GunPoint",
            "Lightning2",
            "Lightning7",
            "OliveOil",
            "OSULeaf",
            "SwedishLeaf",
            "SyntheticControl",
            "Trace",
            "TwoPatterns",
            "Wafer",
            "Yoga"
        };
        
        /*Weight lists which can be used as parameters for different distance measures
         weights have been sourced from TSML and papers where the algorithm was propsed*/
        
        double[] WdtwWeights = new double[101];
        for(int i = 0; i < WdtwWeights.Length; i++) {
            WdtwWeights[i] = (double) i / 100;
        } 
        
        var TweWeights1 = new[]
        {
            0,
            0.25,
            0.5,
            0.75,
            1.0
        };
        
        var TweWeights2 = new[]
        {
            0.00001,
            0.0001,
            0.001,
            0.01,
            0.1,
            1
        };
        
        var DdwtWeights = new double[101];
        for(int i = 0; i < WdtwWeights.Length; i++) {
            DdwtWeights[i] = (double) i / 100;
        } 
        
        var MsmWeights = new[]
        {
                0.01,
                0.01375,
                0.0175,
                0.02125,
                0.025,
                0.02875,
                0.0325,
                0.03625,
                0.04,
                0.04375,
                0.0475,
                0.05125,
                0.055,
                0.05875,
                0.0625,
                0.06625,
                0.07,
                0.07375,
                0.0775,
                0.08125,
                0.085,
                0.08875,
                0.0925,
                0.09625,
                0.1,
                0.136,
                0.172,
                0.208,
                0.244,
                0.28,
                0.316,
                0.352,
                0.388,
                0.424,
                0.46,
                0.496,
                0.532,
                0.568,
                0.604,
                0.64,
                0.676,
                0.712,
                0.748,
                0.784,
                0.82,
                0.856,
                0.892,
                0.928,
                0.964,
                1,
                1.36,
                1.72,
                2.08,
                2.44,
                2.8,
                3.16,
                3.52,
                3.88,
                4.24,
                4.6,
                4.96,
                5.32,
                5.68,
                6.04,
                6.4,
                6.76,
                7.12,
                7.48,
                7.84,
                8.2,
                8.56,
                8.92,
                9.28,
                9.64,
                10,
                13.6,
                17.2,
                20.8,
                24.4,
                28,
                31.6,
                35.2,
                38.8,
                42.4,
                46,
                49.6,
                53.2,
                56.8,
                60.4,
                64,
                67.6,
                71.2,
                74.8,
                78.4,
                82,
                85.6,
                89.2,
                92.8,
                96.4,
                100
        };

        var windowSize = new[]
        {
            1,
            2,
            3,
            4,
            5
        };
        
        /*The example below is muilt-thread to make the most out of the cores on the machine. In this instance a thread
        is assigned to a different weight value as form of a very over fitting train/test split.*/

        // Parallel.For(0, windowSize.Length, i => {
        //         var train = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TRAIN.arff", dataSets[14]);
        //         var test = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TEST.arff", dataSets[14]);
        //
        //         var trainData = DataLoader.LoadCsv(train);
        //
        //         var testData = DataLoader.LoadCsv(test);
        //
        //         var watch = new System.Diagnostics.Stopwatch();
        //
        //         watch.Start();
        //         // Parallel.For(0, TweWeights2.Length, j =>
        //         // {
        //         var temp = EENN.Run(trainData, testData);
        //         Console.WriteLine($"Time taken for {dataSets[14]} = {watch.Elapsed.TotalSeconds} seconds with error rate of {temp} with alpha weight of {windowSize[i]}");
        //         // });
        //         watch.Stop();
        // });

        /*The example below is muilt-thread to make the most out of the cores on the machine. In this instance a thread
        is assigned to a data set to reduce over all run time for a data set. For a single data set it's fast to use
        the linear loop below as muilt-thread for one data set is slower*/
        
        Parallel.For(0, dataSets.Length, i => {
                
                var train = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TRAIN.arff", dataSets[i]);
                
                var test = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TEST.arff", dataSets[i]);
        
                var trainData = DataLoader.LoadCsv(train);
        
                var testData = DataLoader.LoadCsv(test);
        
                var watch = new System.Diagnostics.Stopwatch();
        
                watch.Start();

                var temp = EENN.Run(testData, testData);
        
                watch.Stop();
        
                Console.WriteLine($"Time taken for {dataSets[i]} = {watch.Elapsed.TotalSeconds} seconds with error rate of {temp}");
        });
        
        //Linear method to get the error rates and times from a collection of datasets.

        // for (var i = 0; i < dataSets.Length; i++)
        // {
        //
        //     var train = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TRAIN.arff", dataSets[i]);
        //     var test = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TEST.arff", dataSets[i]);
        //
        //     var trainData = DataLoader.LoadCsv(train);
        //
        //     var testData = DataLoader.LoadCsv(test);
        //
        //     var watch = new System.Diagnostics.Stopwatch();
        //
        //     watch.Start();
        //
        //     var temp = EENN.Run(trainData, testData);
        //
        //     watch.Stop();
        //
        //     Console.WriteLine($"Time taken for {dataSets[i]} = {watch.Elapsed.TotalSeconds} seconds with error rate of {temp}");
        //
        // }
        
        //Linear method to get the error rate from a single data set. In this example it's using the ensemble.
        
        // var train = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TRAIN.arff", dataSets[14]);
        // var test = String.Format("C:/Users/user1/RiderProjects/MeasuresTS/MeasuresTS/TestData/{0}/{0}_TEST.arff", dataSets[14]);
        //
        // var trainData = DataLoader.LoadCsv(train);
        //
        // var testData = DataLoader.LoadCsv(test);
        //
        // var watch = new System.Diagnostics.Stopwatch();
        //
        // watch.Start();
        //
        // var temp = OneNearestNeighbor.Run(trainData, testData, 0.117);
        //
        // watch.Stop();
        //
        // Console.WriteLine($"Time taken for {dataSets[14]} = {watch.Elapsed.TotalSeconds} seconds with error rate of {temp}");

    }
}