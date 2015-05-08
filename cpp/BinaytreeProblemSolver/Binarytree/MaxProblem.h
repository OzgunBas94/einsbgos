#ifndef MAXPROBLEM
#define MAXPROBLEM

#pragma once
#include "MaxSolution.h"
#include "DivisibleProblem.h"

class MaxProblem : public DivisibleProblem{

protected:
	Solution* solution;
	MaxSolution* maxS;

public:
	MaxProblem();


	void checkSolvability(Node*node) ;

	Solution* getSolution();

	void getHighestAndSum(Node*node) ;

	~MaxProblem() ;
};
#endif
