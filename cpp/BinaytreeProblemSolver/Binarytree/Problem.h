#ifndef PROBLEM
#define PROBLEM
#include "Solution.h"


class Problem {
public:
	virtual Solution* getSolution() const = 0;
};

#endif
