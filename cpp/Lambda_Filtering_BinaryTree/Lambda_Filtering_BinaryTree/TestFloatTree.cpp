#include "TestFloatTree.h"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>


TestFloatTree::TestFloatTree(BinaryTree <float> t)
{
	this->t = t;
}

void TestFloatTree::insertRandom(int num){
	if (num < 1){
		cout << "You have to insert minimum one number in the tree.";
	}
	else{
		for (int i = 0; i < num; i++){
			t.insert(static_cast <float> (rand()) / static_cast <float> (RAND_MAX););
		}
	}
}


