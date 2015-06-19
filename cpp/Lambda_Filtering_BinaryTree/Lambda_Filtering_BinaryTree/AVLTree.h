#ifndef AVLTree_H
#define AVLTree_H
#include "AVLNode.h"
#include "AVLNode.cpp"
#include "UniversalTree.h"
#include <algorithm>

template <class T> class AVLTree : public UniversalTree<T>{

public:
	bool found;
	// A variable root is initialized with NULL
	AVLNode<T> * root = NULL;
	// Constructor of the class AVLTree
	AVLTree();
	// Constructor of the class AVLTree with input
	AVLTree(T data);
	// Deconstructor
	~AVLTree();
	// In this method you will get the value from the smallest node
	// @return the value of the root
	AVLNode<T> * getSmallest(AVLNode<T> * node);
	// @return the root of the binarytree
	AVLNode<T> * getRoot();
	// It looks the difference of the right and the left
	int getBalance(AVLNode<T> * node);
	// In this method you will get the highest value
	// @return the data of the highest node
	int getHeight(int height, AVLNode<T> * node);
	// In this method you can insert a new node within a new value.
	// @param value: the new value
	void insert(T data);
	// In this method you can remove the desired node.
	// @param value: the value of the node you want to delete
	// @return to get in the method
	void remove(T data);
	// Here you can search the desired node 
	// @param value: the value it has to be search
	bool search(T data);
	// The output of the tree
	void inOrderOutput();
	// In this method it looks 
	void insertRemoveAVLTree(AVLNode<T> * node);
	T* filter(delegate <T> del);

private:
	/*
	the smallest Node is the lowest node on the left side of the Tree
	this method running as long the lowest node on the left side is not Null
	than return the node
	*/
	AVLNode<T>* getSmallestNode(AVLNode<T>* start);
	/*creates new nodes left an right*/
	void insertRecursion(AVLNode<T> * node, T data);
	// Int this method it compares the values with each other. 
	// If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
	// @param node: the node where it will start to compare the value of the new node and the value of the current node.
	// @param data: value of the new node
	// @param parent: the parent is a node from the current node
	// @param leftFromParent: the left node from the parent
	// @return if the deletion was successful then it will return true
	void removeRecursion(AVLNode<T> * node, AVLNode<T> * parent, T data);
	// If the tree has 2 children first it picks the smallelst number and pass on the remove method
	void removeWithTwoChildren(AVLNode<T> * node);
	// A output in recursion
	void inOrderRecursion(AVLNode<T> * node);
	// Int this method it compares the values with each other. 
	// If the value, you search is higher than the current value, so it will look on the right of the binarytree 
	// as long as it finds the desired value.
	// @param node: the current node, from where you search
	// @param value: the value you search
	// @return the node you find
	bool searchRecursion(AVLNode<T> * node, T data);
	void filterRec(AVLNode<T> node, delegate <T> del);

};

#endif