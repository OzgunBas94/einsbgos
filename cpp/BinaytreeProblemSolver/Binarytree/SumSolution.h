#ifndef SUMSOLUTION
#define SUMSOLUTION

#pragma once
#include "Solution.h"


class SumSolution : public Solution
{
protected:
	int sum;

public:	
	virtual void setSum(int sum);
	int getSum() const{
		return sum;
	}


};

#endif