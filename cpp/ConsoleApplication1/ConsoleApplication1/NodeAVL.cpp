#include "NodeAVL.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>

template <class T>
NodeAVL<T>::~NodeAVL() {
	delete left;
	delete right;
	delete parent;
}

template <class T>
NodeAVL<T>::NodeAVL(){
}

template <class T>
NodeAVL<T>::NodeAVL(T data, NodeAVL<T> * left, NodeAVL<T> * right, NodeAVL<T> * parent) {
	this->setData(data);
	this->left = left;
	this->right = right;
	this->parent = parent;
}

template <class T>
T NodeAVL<T>::getData(){
	return data;
}

template <class T>
void NodeAVL<T>::setData(T data){
	this->data = data;
}

template <class T>
NodeAVL<T>* NodeAVL<T>::getLeft(){
	return left;
}

template <class T>
void NodeAVL<T>::setLeft(NodeAVL<T>* node){
	this->left = node;
}

template <class T>
NodeAVL<T>* NodeAVL<T>::getRight(){
	return right;
}

template <class T>
void NodeAVL<T>::setRight(NodeAVL<T>* node){
	this->right = node;
}

template <class T>
NodeAVL<T>* NodeAVL<T>::getParent(){
	return parent;
}

template <class T>
void NodeAVL<T>::setParent(NodeAVL<T>* node){
	this->parent = node;
}

