#include "MaxProblem.h"

using namespace std;


MaxProblem::MaxProblem(){
	maxS = new MaxSolution();
	solution = maxS;
}


void MaxProblem::checkSolvability(Node*node){
	DivisibleProblem::checkSolvability(node);
	if (node->getRight() == nullptr && node->getLeft() == nullptr){
		directlySolvalbe = false;
		maxS->setMaximum(node->getData());
		
	}
}


Solution* MaxProblem::getSolution() {
	Problem::getSolution();
		return solution;
}


	void MaxProblem::getHighestAndSum(Node*node){
		DivisibleProblem::getHighestAndSum(node);
	while (node->getRight() != nullptr){
		node = node->getRight();
	}
	maxS->setMaximum(node->getData());
	
}

