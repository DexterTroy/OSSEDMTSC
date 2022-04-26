#include <iostream>
#include "DTW.h"

int main() {

    std::vector<double> a = {0.0,2.0,0.0,1.0,0.0,0.0};
    std::vector<double> b = {0.0,0.0,0.5,2.0,0.0,1,0.0};

    double test = DTW::distance(a,b);

    std::cout << test << std::endl;

    return 0;
}
