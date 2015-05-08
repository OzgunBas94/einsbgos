#include "SumProblem.h"
#include <cassert>
#include <cstdlib>

using namespace std;


SumProblem::SumProblem(){
	sumS = new SumSolution();
	solution = sumS;
		
}


int SumProblem::getSumRecursion(Node*node){

	int sum = 0;
	if (node != nullptr){
		sum += node->getData() + getSumRecursion(node->getLeft()) + getSumRecursion(node->getRight());
	}
	return sum;
}

void SumProblem::checkSolvability(Node*node){
	DivisibleProblem::checkSolvability(node);
	if (node->getRight() == nullptr && node->getLeft() == nullptr){
		directlySolvalbe = false;
		
		sumS->setSum(node->getData());
	}
}

Solution* SumProblem::getSolution(){
	return solution;
}


void SumProblem:: getHighestAndSum(Node*node){
	DivisibleProblem::getHighestAndSum(node);
	sumS->setSum(this->getSumRecursion(node));
}