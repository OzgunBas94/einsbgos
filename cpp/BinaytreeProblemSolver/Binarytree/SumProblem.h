#ifndef SUMPROBLEM
#define SUMPROBLEM


#pragma once
#include "SumSolution.h"
#include "DivisibleProblem.h"


class SumProblem : public DivisibleProblem{

protected:
	Solution* solution;
	SumSolution* sumS;

	void checkSolvability();

	void getHighestAndSum(Node*node) ;

public:
	int getSumRecursion(Node*node);
	virtual Solution* getSolution();
	void checkSolvability(Node*node);
	SumProblem();

	~SumProblem();


};
#endif