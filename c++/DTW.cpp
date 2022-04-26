#include "DTW.h"

double DTW::distance(const std::vector<double> &s1, const std::vector<double> &s2) {
    int n = s1.size() + 1;
    int m = s2.size() + 1;
    std::vector<std::vector<double>> dtw(n, std::vector<double>(m, 0));

    for (int i = 0; i < n; ++i) {
        dtw[i][0] = std::numeric_limits<double>::max();
    }
    for (int j = 0; j < m; ++j) {
        dtw[0][j] = std::numeric_limits<double>::max();
    }

    dtw[0][0] = 0;

    for (int i = 1; i < n; ++i) {
        for (int j = 1; j < m; ++j) {

            dtw[i][j] = std::abs(s1[i - 1] - s2[j - 1]) +
                        std::min(dtw[i-1][j-1], std::min(dtw[i-1][j], dtw[i][j-1]));

        }
    }
    return dtw[n-1][m-1];
}
