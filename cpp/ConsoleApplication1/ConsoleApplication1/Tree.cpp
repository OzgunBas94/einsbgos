#include <stdio.h>
#include "Tree.h"
#include <iostream>
#include <algorithm>

using namespace std;

template <class T>
Tree<T>::~Tree()
{
	delete root;
}

template <class T>
Tree<T>::Tree(){
	root = NULL;
}

template <class T>
Tree<T>::Tree(T value){
	root = new Node<T>(value);
}

template <class T>
Node<T>* Tree<T>::getRoot(){
	return root;
}

template <class T>
void Tree<T>::setRoot(Node<T>* root){
	this->root = root;
}

template <class T>
T Tree<T>::getSmallest(){
	Node<T>*node = getSmallestNode(root);
	if (root != NULL){
		return node->getData();
	}
	else{
		throw new exception("Root is null !");
	}
}

template <class T>
Node<T>* Tree<T>::getSmallestNode(Node<T>* start){
	if (start != NULL){
		while (start->getLeft() != NULL){
			start = start->getLeft();
		}
		return start;
	}
	else{
		throw new exception("Root is missing");
	}
}

template <class T>
T Tree<T>::getBiggest(){
	Node<T>*start = getBiggestNode(root);
	if (root != NULL){
		return start->getData();
	}
	else{
		throw new exception("Root is missing");
	}
}

template <class T>
Node<T>* Tree<T>::getBiggestNode(Node<T>* start){
	if (start != NULL){
		while (start->getRight() != NULL){
			start = start->getRight();
		}
		return start;
	}
	else{
		throw new exception("Root is missing");
	}
}

template <class T>
int Tree<T> ::getHeight(){
	return getHeightRecursion(0, root);
}

template <class T>
int Tree<T> ::getHeightRecursion(int currentHeight, Node<T>* node){
	if (node != NULL){
		currentHeight = std::max(getHeightRecursion(currentHeight + 1, node->getLeft()), getHeightRecursion(currentHeight + 1, node->getRight()));
	}
	return currentHeight;
}

template <class T>
void Tree<T>::insert(T data){
	if (root == NULL) {
		Node<T>* root = new Node<T>(data);
	}
	else {
		insertRecursion(data, root);
	}
}

template <class T>
void Tree<T>::insertRecursion(T data, Node<T>* node){
	if (data < node->getData()) {
		if (node->getLeft() != 0) {
			insertNodeRecursion(data, node->getLeft());
		}
		else {
			Node<T>* left = new Node<T>(data);
			node->setLeft(left);
		}
	}
	else {
		if (node->getRight() != 0) {
			insertNodeRecursion(data, node->getRight());
		}
		else {
			Node<T>* right = new Node<T>(data);
			node->setRight(right);
		}
	}
}

template <class T>
bool Tree<T>::remove(T data){
	return removeRecursion(root, data, NULL, false);
}

template <class T>
bool Tree<T>::removeRecursion(Node<T>* node, T data, Node<T>* parent, bool leftFromParent){
	if (node == NULL){
		return false;
	}
	if ((data == node->getData())){
		if ((node->getLeft() == NULL) && (node->getRight() == NULL)){
			if (parent == NULL){
				root = NULL;
			}
			else{
				underParent(parent, leftFromParent, NULL);
			}
		}
		if ((node->getLeft() == NULL) && (node->getRight() != NULL)){
			if (root == NULL){
				root = node->getRight();
			}
			else{
				underParent(parent, leftFromParent, node->getRight());
				parent->setParent(node);
			}
		}
		if ((node->getLeft() != NULL) && (node->getRight() == NULL)){
			if (root == NULL){
				root = node->getLeft();
			}
			else{
				underParent(parent, leftFromParent, node->getLeft());
				parent->setParent(node);
			}
		}
		if ((node->getLeft() != NULL) && (node->getRight() != NULL)){
			Node<T>*newNode = getBiggestNode(node->getLeft());
			remove(newNode->getData());
			if (parent == NULL){
				newNode->setLeft(root->getLeft());
				newNode->setRight(root->getRight());
				root = newNode;
			}
			else{
				newNode->setLeft(node->getLeft());
				newNode->setRight(node->getRight());
				underParent(parent, leftFromParent, newNode);
				parent->setParent(newNode);
			}
		}
		removeRecursion(root, data, NULL, false);
		return true;
	}
	if ((data < node->getData())){
		if (node->getLeft() == NULL){
			return false;
		}
		return removeRecursion(node->getLeft(), data, node, true);
	}
	if (data > node->getData()){
		if (node->getRight() == NULL){
			return false;
		}
		else{
			return removeRecursion(node->getRight(), data, node, false);
		}
	}
	return false;
}

template <class T>
void Tree<T>::underParent(Node<T>* parent, bool left, Node<T>* node){
	if (left){
		parent->setLeft(node);
	}
	else{
		parent->setRight(node);
	}
}

template <class T>
bool Tree<T>::search(T data){
	if (root == NULL){
		return false;
	}
	else{
		return root->searchRec(data);
	}
}

template <class T>
bool Tree<T>::searchRec(T data){
	if (data == this->data){
		printf("true");
		return true;
	}
	else if (data < this->data){
		if (left == NULL){
			printf("false");
			return false;
		}
		else{
			return left->searchRec(data);
		}
	}
	else if (data > this->data) {
		if (right == NULL){
			printf("false");
			return false;
		}
		else{
			return right->searchRec(data);
		}
	}
	printf("false");
	return false;
}

template <class T>
void Tree<T>::inOrder(Node<T>* node) {
	if (node) {
		inOrder(node->getLeft());
		cout << node->getData() << " ";
		inOrder(node->getRight());
	}
}
