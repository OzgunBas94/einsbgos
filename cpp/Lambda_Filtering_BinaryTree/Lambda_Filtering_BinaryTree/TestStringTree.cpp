#include "TestStringTree.h"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>


TestStringTree::TestStringTree(BinaryTree <string> t)
{
	this->t = t;
}

//This method inserts random strings to the tree.
//num: The number of strings that should be insertet to the tree
void TestStringTree::insertRandom(int num){
	

	if (num < 1){
		cout << "You have to insert minimum one string in the tree.";
	}
	else{
		for (int i = 0; i < num; i++){
			t.insert(random());
		}
	}
}

string TestStringTree::random(){
	char *s = "";
	const char alph[] =
		"0123456789"
		"abcdefghijklmnopqrstuvwxyz"
		"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	int x = std::rand();
	for (int i = 0; i = x; i++){
		s[i] = alph[rand() % (sizeof(alph) - 1)];
	}
	return s;
}

