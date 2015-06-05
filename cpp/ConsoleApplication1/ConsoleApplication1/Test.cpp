#include <iostream>
#include "Tree.h"
#include "Tree.cpp"
#include "AVL.h"
#include "AVL.cpp"

using namespace std;

// main Method
int main() {

	// A new object
	Tree<int> binarytree;
	// insert different values
	for (int i = 1; i <= 10; i++){
		binarytree.insert(i);
	}

	//Ouput
	binarytree.inOrder(binarytree.getRoot());
	cout << endl;
	// Remove the number 11
	binarytree.remove(11);
	cout << endl;
	// Search the number 2. It returns a boolean value
	binarytree.search(2);
	cout << endl;
	// Returns the height
	cout << "Height " << binarytree.getHeight() << endl;
	cout << endl;

	// A new Object
	AVL<int> avlTree = AVL<int>(11);
	// Insert values in the AVL tree
	avlTree.insert(9);
	avlTree.insert(8);
	avlTree.insert(4);
	// Output
	avlTree.inOrderOutput();
	// Remove the number 8
	avlTree.remove(8);
	// Output
	avlTree.inOrderOutput();
	// balances the tree
	std::cout << avlTree.getBalance(avlTree.getRoot()) << std::endl;

	cin.get();

	return 0;
}



