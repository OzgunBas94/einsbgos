#include "AVLNode.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>

template <class T>
AVLNode<T>::~AVLNode() {
	delete left;
	delete right;
	delete parent;
}

template <class T>
AVLNode<T>::AVLNode(){
}

template <class T>
AVLNode<T>::AVLNode(T data, AVLNode<T> * left, AVLNode<T> * right, AVLNode<T> * parent) {
	this->setData(data);
	this->left = left;
	this->right = right;
	this->parent = parent;
}

template <class T>
T AVLNode<T>::getData(){
	return data;
}

template <class T>
void AVLNode<T>::setData(T data){
	this->data = data;
}

template <class T>
AVLNode<T>* AVLNode<T>::getLeft(){
	return left;
}

template <class T>
void AVLNode<T>::setLeft(AVLNode<T>* node){
	this->left = node;
}

template <class T>
AVLNode<T>* AVLNode<T>::getRight(){
	return right;
}

template <class T>
void AVLNode<T>::setRight(AVLNode<T>* node){
	this->right = node;
}

template <class T>
AVLNode<T>* AVLNode<T>::getParent(){
	return parent;
}

template <class T>
void AVLNode<T>::setParent(AVLNode<T>* node){
	this->parent = node;
}
