#ifndef DTW_H
#define DTW_H

#include<vector>
#include<limits>
#include <stdlib.h>

class DTW {
    public:

        static double distance(const std::vector<double>& s1, const std::vector<double>& s2);

};


#endif