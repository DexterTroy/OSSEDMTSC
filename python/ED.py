import math

def distance(s1, s2):
    n = len(s1)
    m = len(s2)

    if n > m:
        n = m

    sum = 0

    for i in range(n - 1):
        sum += (s1[i] - s2[i]) ** 2

    return math.sqrt(sum)