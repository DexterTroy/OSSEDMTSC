package main

import (
	"fmt"
	"math"
)

func dynamicTimeWarping(s1, s2 []float64) float64 {
	n := len(s1) + 1
	m := len(s2) + 1
	d := make([][]float64, n)
	for i := 0; i < n; i++ {
		d[i] = make([]float64, m)
	}
	for i := 0; i < n; i++ {
		d[i][0] = math.Inf(1)
	}

	for i := 0; i < m; i++ {
		d[0][i] = math.Inf(1)
	}

	d[0][0] = 0

	for i := 1; i < n; i++ {
		for j := 1; j < m; j++ {
			d[i][j] = math.Abs(s1[i-1]-s2[j-1]) +
				math.Min(d[i-1][j-1], math.Min(d[i-1][j], d[i][j-1]))
		}
	}
	return d[n-1][m-1]
}

func main() {
	b := []float64{0.0, 0.0, 0.5, 2.0, 0.0, 1, 0.0}
	a := []float64{0.0, 2.0, 0.0, 1.0, 0.0, 0.0}
	test := dynamicTimeWarping(a, b)
	fmt.Printf("%f", test)
}
