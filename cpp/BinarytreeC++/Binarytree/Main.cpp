#include <iostream>
#include "Tree.h"

using namespace std;

int main() {
	Tree tree;

	tree.insert(5);
	tree.insert(4);
	tree.insert(2);
	tree.insert(1);
	tree.insert(44);
	tree.insert(23);
	tree.insert(78);
	tree.insert(12);
	tree.insert(2);
	tree.insert(74);

	tree.inOrder(tree.getRoot());
	
	cout << endl;


	tree.remove(2);
	tree.remove(23);

	tree.inOrder(tree.getRoot());

	cout << endl;

	tree.search(4);

	cout << endl;

	tree.search(100);

	cin.get();


	return 0;
}