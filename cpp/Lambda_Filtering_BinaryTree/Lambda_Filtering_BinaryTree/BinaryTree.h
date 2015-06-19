#ifndef BINARYTREE_H
#define BINARYTREE_H
#include "Node.h"
#include "Node.cpp"
#include <algorithm>
#include "UniversalTree.h"
#include <vector>

//This class inherits the methods of the superclass 'UniversalTree' and it's also a generic class
template <class T> class BinaryTree : public UniversalTree<T> {

private:
	//A variable declaration 
	Node<T>* root;
	vector <T> results;
	/*
	the smallest Node is the lowest node on the left side of the Tree
	this method running as long the lowest node on the left side is not Null
	than return the node
	*/
	Node<T>* getSmallestNode(Node<T>* start);
	/*
	the biggest Node is the lowest node on the right side of the Tree
	this method running as long the lowest node on the right side is not Null
	than return the node
	*/
	Node<T>* getBiggestNode(Node<T>* start);
	/*creates new nodes left an right*/
	void insertRecursion(T data, Node<T>* NewNode);
	// In this method you look whether it is right from the parent or left. If left is true then it will set the node left from the parent.
	// @param parent: the parent from the node
	// @param left: a boolean whether it is left or right
	// @param node: the current node
	void underParent(Node<T>* parent, bool left, Node<T>* node);
	// Int this method it compares the values with each other. 
	// If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
	// @param node: the node where it will start to compare the value of the new node and the value of the current node.
	// @param data: value of the new node
	// @param parent: the parent is a node from the current node
	// @param leftFromParent: the left node from the parent
	// @return if the deletion was successful then it will return true
	bool removeRecursion(Node<T>* node, T data, Node<T>* parent, bool leftFromParent);
	// In this method you wil get the highest node
	// @param node: the node where it begins to search the highest node
	int getHeightRecursion(int currentHeight, Node<T> * node);
	// the search recursion for the method search
	bool searchRec(T data);
	//filter rec
	void filterRec(Node<T> node, delegate <T> del);


public:
	//Constructor for the class BinaryTree
	BinaryTree();
	//Constructor for the class BinaryTree with value T
	BinaryTree(T value);
	//Deconstructor
	~BinaryTree();
	// @return the root of the binarytree
	Node<T>* getRoot();
	// In this method you will get the value from the smallest node
	// @return the value of the root
	T getSmallest();
	// Here you will get the biggest Node
	T getBiggest();
	// In this method you will get the highest value
	// @return the data of the highest node
	int getHeight();
	// In this method you can remove the desired node.
	// @param value: the value of the node you want to delete
	// @return to get in the method
	bool remove(T data);
	// Here you can search the desired node 
	// @param value: the value it has to be search
	bool search(T data);
	// a setter for the variable root
	void setRoot(Node<T>* root);
	// In this method you can insert a new node within a new value.
	// @param value: the new value
	void insert(T data);
	// This shows the output from the binarytree
	// @return to get in the other method and return the values
	void inOrder(Node<T>* node);
	//This method filters
	T* filter(delegate <T> del);
	
};
#endif