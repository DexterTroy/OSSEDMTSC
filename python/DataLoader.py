import numpy as np

def load(filePath):
    file = open(filePath)
    return np.loadtxt(file, delimiter=",")