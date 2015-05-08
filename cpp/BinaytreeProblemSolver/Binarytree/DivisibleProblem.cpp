#include "DivisibleProblem.h"

using namespace std;


void DivisibleProblem::computeSolution(void) {

	checkSolvability(tree->getRoot());

	if (directlySolvalbe){
		printf("directlySolvable is true!");
	}
	else{
		getHighestAndSum(tree->getRoot());
	}

}
/*DivisibleProblem::DivisibleProblem()
{
}


DivisibleProblem::~DivisibleProblem()
{
}*/
