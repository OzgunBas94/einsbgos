#pragma once
#include "UniversalTree.h";
#include "UniversalTree.cpp";
#include "BinaryTree.h";
#include "BinaryTree.cpp";
#include <stdlib.h>

class TestFloatTree
{
private:
	BinaryTree <float> t;

public:
	TestFloatTree(BinaryTree <float> t);
	void insertRandom(int num);
};

