#include <stdio.h>
#include <iostream>
#include "Node.h"


template <class T>
Node<T>::~Node() {
	delete left;
	delete right;
	delete parent;
}

template <class T>
Node<T>::Node(){

}

template <class T>
Node<T>::Node(T data){
	this->parent = nullptr;
	this->right = nullptr;
	this->left = nullptr;
	this->setData(data);
}

template <class T>
void Node<T>::setRight(Node<T>* right){
	this->right = right;
}

template <class T>
void Node<T>::setLeft(Node<T>* left){
	this->left = left;
}

template <class T>
void Node<T>::setParent(Node<T>* parent){
	this->parent = parent;
}

template <class T>
void Node<T>::setData(T data){
	this->data = data;
}

template <class T>
Node<T>* Node<T>::getRight(){
	return right;
}

template <class T>
Node<T>* Node<T>::getLeft(){
	return left;
}

template <class T>
Node<T>* Node<T>::getParent(){
	return parent;
}

template <class T>
T Node<T>::getData(){
	return data;
}