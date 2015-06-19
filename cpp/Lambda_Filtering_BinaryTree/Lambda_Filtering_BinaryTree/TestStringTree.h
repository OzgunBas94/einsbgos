#pragma once
#include "UniversalTree.h";
#include "UniversalTree.cpp";
#include "BinaryTree.h";
#include "BinaryTree.cpp";
#include <stdlib.h>

class TestStringTree
{
private:
	BinaryTree <string> t;
	
public:
	TestStringTree(BinaryTree<string> t);
	void insertRandom(int num);
	string random();


};

