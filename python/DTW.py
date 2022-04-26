import numpy as np


def distance(s1, s2):
    n = len(s1) + 1
    m = len(s2) + 1

    d = np.zeros((n, m))

    for i in range(n):
        d[i, 0] = np.inf
    for i in range(m):
        d[0, i] = np.inf

    d[0][0] = 0

    for i in range(1, n):
        for j in range(1, m):
            d[i][j] = abs(s1[i - 1] - s2[j - 1]) + min(d[i - 1][j - 1], d[i - 1][j], d[i][j - 1])

    return d[n - 1][m - 1]
