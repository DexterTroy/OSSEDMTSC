import numpy as np
import DTW
import ED


def run(trainData, testData):

    correct = 0
    count = 0

    for i in range(len(testData)):
        nearestN = np.inf
        tagWinner = np.inf

        s1 = testData[i][:-1]
        testLable = testData[i][-1]
        for j in range(len(trainData)):
            s2 = trainData[j][:-1]
            trainLabel = trainData[j][-1]

            dist = ED.distance(s1, s2)
            if dist < nearestN:
                nearestN = dist
                tagWinner = trainLabel

        if tagWinner == testLable:
            correct += 1

        count += 1
    print(correct)
    return (count - correct) / count
