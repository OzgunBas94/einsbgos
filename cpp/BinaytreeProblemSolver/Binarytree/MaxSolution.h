#ifndef MAXSOLUTION
#define MAXSOLUTION

#pragma once
#include "Solution.h"


class MaxSolution : public Solution
{
protected:
	int max;
	
public:
	 MaxSolution();

	 void setMaximum(int max) ;
	 int getMaximum() const{
		return max; 
	}


};
#endif
