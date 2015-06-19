#include <iostream>
#include "BinaryTree.h"
#include "BinaryTree.cpp"
#include "AVLTree.h"
#include "AVLTree.cpp"
#include "TestStringTree.h"
#include "TestStringTree.cpp"
#include "TestFloatTree.h"
#include "TestFloatTree.cpp"

using namespace std;

int main(){

	BinaryTree <float> tree1;
	cout << "---------------------Float Tree------------------";
	cout << "Alle negativen Zahlen";
	TestFloatTree testFloat(tree1);
	testFloat.insertRandom(7);
	float* s;
	s = tree1.filter([=](int x){return x < 0; });
	cout << s;
	cout << "Alle Zahlen <= 5";
	s = tree1.filter([=](int x){return x <= 5; });
	cout << "Alle geraden Zahlen";
	s = tree1.filter([=](int x){return x % 2; });

	BinaryTree <string> tree2;
	cout << "--------------------String Tree---------------------";
	cout << "Woerter mit einer Laenge >= 3";
	TestStringTree testString(tree2);
	testString.insertRandom(11);
	string *res;
	res = tree2.filter([=](string x){return x.length >= 3; });
	cout << "Woerter, die ein 's' enthalten";
	res = tree2.filter([=](string x){return x.find('s'); });

}
