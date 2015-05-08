#ifndef DIVISIBLEPROBLEM
#define DIVISIBLEPROBLEM

#pragma once
#include <iostream>
#include "Tree.h"
#include "Node.h"
#include "Problem.h"

class DivisibleProblem : public Problem{

protected:

	bool directlySolvalbe = false;

	Tree* tree = nullptr;


public:
	virtual void checkSolvability(Node* node);
	virtual void getHighestAndSum(Node* node);
	void computeSolution();

	virtual void setBinarytree(int value){
		tree = new Tree;//hier ohne value
	}
	virtual Tree*getBinarytree(){
		return tree;
	}


	//~DivisibleProblem();
};


#endif 
