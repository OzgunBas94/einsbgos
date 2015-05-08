#include <stdio.h>
#include <assert.h>
#include <iostream>
#include "Node.h"


Node::Node(){
	assert(this->parent == NULL && this->right == NULL && this->left == NULL & this->data == NULL);
}
//node constructor with data
Node::Node(int data){
	this->parent = nullptr;
	this->right = nullptr;
	this->left = nullptr;
	this->setData(data);
}
// setter setRight
void Node::setRight(Node* right){
	//assert(right != NULL);
	this->right = right;
}

//setter setLeft
void Node::setLeft(Node* left){
	//assert(left != NULL);
	this->left = left;
}

//setter setParent
void Node::setParent(Node* parent){
	assert(parent != NULL);
	this->parent = parent;
}

//setter setData
void Node::setData(int data){
	assert(data <= 0 || data >= 0);
	this->data = data;
}

//getter getRight returns right
Node* Node::getRight(){
	//assert(right == Node::getRight());
	return right;
}

//getter getLeft returns left
Node* Node::getLeft(){
	//assert(left == Node::getLeft());
	return left;
}
//getter getParent returns parent
Node* Node::getParent(){
	//assert(parent == Node::getParent());
	return parent;
}

//getter getData returns data
int Node::getData(){
	assert(data <= 0 || data >= 0);
	return data;
}