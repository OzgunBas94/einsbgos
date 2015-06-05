#include "AVL.h"
#include <iostream>
#include <algorithm>
#include <stdio.h>
#include <assert.h>


template <class T>
AVL<T>::~AVL()
{
	delete root;
}

template <class T>
AVL<T>::AVL() {
	root = NULL;
}

template <class T>
AVL<T>::AVL(T data) {
	root = new NodeAVL<T>(data, NULL, NULL, NULL);
}

template <class T>
NodeAVL<T> * AVL<T>::getRoot() {
	return this->root;
}

template <class T>
void AVL<T>::insertRemoveAVL(NodeAVL<T> * node) {
	NodeAVL<T> * parent = node->getParent();
	while (parent != NULL) {
		if (node == parent->getLeft()) {			
			if (getBalance(parent) == 2) {
				if (getBalance(node) == -1) {
					NodeAVL<T> * newNode = node->getRight();
					parent->setLeft(newNode);
					node->setRight(newNode->getLeft());
					newNode->setLeft(node);
					node->setParent(newNode);
					newNode->setParent(parent);
					NodeAVL<T> * tmp = node;
					node = newNode;
					newNode = tmp;
				}
				if (parent == this->root) {
					this->root = node;
				}
				else {
					if (parent == parent->getParent()->getRight()) {
						parent->getParent()->setRight(node);
					}
					else {
						parent->getParent()->setLeft(node);
					}
				}
				node->setParent(parent->getParent());
				parent->setParent(node);
				parent->setLeft(node->getRight());
				if (node->getRight() != NULL) {
					node->getRight()->setParent(parent);
				}
				node->setRight(parent);
			}
		}
		else {								
			if (getBalance(parent) == -2) {
				if (getBalance(node) == 1) {
					NodeAVL<T> * newNode = node->getLeft();
					parent->setRight(newNode);
					node->setLeft(newNode->getRight());
					newNode->setRight(node);
					node->setParent(newNode);
					newNode->setParent(parent);
					NodeAVL<T> * tmp = node;
					node = newNode;
					newNode = tmp;
				}
				if (parent == this->root) {
					this->root = node;
				}
				else {
					if (parent == parent->getParent()->getRight()) {
						parent->getParent()->setRight(node);
					}
					else {
						parent->getParent()->setLeft(node);
					}
				}
				node->setParent(parent->getParent());
				parent->setParent(node);
				parent->setRight(node->getLeft());
				if (node->getLeft() != NULL) {
					node->getLeft()->setParent(parent);
				}
				node->setLeft(parent);
			}
		}
		node = parent;
		parent = n->getParent();
	}
}

template <class T>
int AVL<T>::getBalance(NodeAVL<T> * node) {
	return getHeight(0, node->getLeft()) - getHeight(0, node->getRight());
}

template <class T>
int AVL<T>::getHeight(int height, NodeAVL<T> * node) {
	if (node != NULL) {
		height = std::max(getHeight(height + 1, node->getLeft()), getHeight(height + 1, node->getRight()));
	}
	return height;
}

template <class T>
void AVL<T>::insert(T data) {
	if (this->root == NULL) {
		this->root = new NodeAVL<T>(data, NULL, NULL, NULL);
	}
	else {
		insertRecursion(this->root, data);
	}
	std::cout << data << " Its inserted" << std::endl;
}

template <class T>
void AVL<T>::insertRecursion(NodeAVL<T> * node, T data) {
	if (data < node->getData()) {
		if (node->getLeft() == NULL) {
			node->setLeft(new NodeAVL<T>(data, NULL, NULL, node));
			insertRemoveAVL(node->getLeft());
		}
		else {
			insertRecursion(node->getLeft(), data);
		}
	}
	if (data >= node->getData()) {
		if (node->getRight() == NULL) {
			node->setRight(new NodeAVL<T>(data, NULL, NULL, node));

			insertRemoveAVL(node->getRight());
		}
		else {
			insertRecursion(node->getRight(), data);
		}
	}
}

template <class T>
bool AVL<T>::search(T data) {
	return searchRecursion(this->root, data);
}

template <class T>
bool AVL<T>::searchRecursion(NodeAVL<T> * node, T data) {
	this->found = false;
	if (node != NULL && n->getData() == data) {
		this->found = true;
	}
	else {
		if (node != NULL && !(this->found)) {
			if (data < node->getData()) {
				searchRecursion(node->getLeft(), data);
			}
			else {
				searchRecursion(node->getRight(), data);
			}
		}
	}
	return found;
}

template <class T>
void AVL<T>::remove(T data) {
	while (this->root != NULL && search(data)) {
		removeRecursion(this->root, NULL, data);
	}
}

template <class T>
void AVL<T>::removeRecursion(NodeAVL<T> * node, NodeAVL<T> * parent, T data) {
	if (node != NULL && n == this->root && node->getData() == data) {
		if (node->getLeft() == NULL && node->getRight() == NULL) {
			this->root = NULL;
			delete node;
		}
		else if (node->getLeft() != NULL && node->getRight() == NULL) {
			node->getLeft()->setParent(NULL);
			this->root = node->getLeft();
			delete node;
		}
		else if (node->getLeft() == NULL && node->getRight() != NULL) {
			node->getRight()->setParent(NULL);
			this->root = node->getRight();
			delete node;
		}
		else if (node->getLeft() != NULL && node->getRight() != NULL) {
			removeWithTwoChildren(node);
		}
	}
	else if (node != NULL && node != this->root && node->getData() == data) {
		if (node->getLeft() == NULL && node->getRight() == NULL) {
			NodeAVL<T> * parent = node->getParent();
			if (node == node->getParent()->getLeft()) {
				node->getParent()->setLeft(NULL);
			}
			else {
				node->getParent()->setRight(NULL);
			}
			delete n;
			insertRemoveAVL(parent);
		}
		else if (node->getLeft() != NULL && node->getRight() == NULL) {
			NodeAVL<T> * parent = node->getParent();
			if (node == node->getParent()->getLeft()) {
				node->getParent()->setLeft(node->getLeft());
			}
			else {
				node->getParent()->setRight(node->getLeft());
			}
			node->getLeft()->setParent(node->getParent());
			delete node;
			insertRemoveAVL(parent);
		}
		else if (node->getLeft() == NULL && node->getRight() != NULL) {
			NodeAVL<T> * parent = node->getParent();
			if (node == node->getParent()->getLeft()) {
				node->getParent()->setLeft(node->getRight());
			}
			else {
				node->getParent()->setRight(node->getRight());
			}
			node->getRight()->setParent(node->getParent());
			delete node;
			insertRemoveAVL(parent);
		}
		else if (node->getLeft() != NULL && node->getRight() != NULL) {
			removeWithTwoChildren(node);
		}
	}
	else if (node != NULL && node->getData() != data) {
		if (data < node->getData()) {
			removeRecursion(node->getLeft(), node, data);
		}
		else {
			removeRecursion(node->getRight(), node, data);
		}
	}
}

template <class T>
void AVL<T>::removeWithTwoChildren(NodeAVL<T> * node) {
	NodeAVL<T> * smallest = getSmallest(node->getRight());
	node->setData(smallest->getData());
	removeRecursion(smallest, smallest->getParent(), smallest->getData());
}

template <class T>
NodeAVL<T> * AVL<T>::getSmallest(NodeAVL<T> * node) {
	while (node->getLeft() != NULL) {
		node = node->getLeft();
	}
	return node;
}

template <class T>
void AVL<T>::inOrderRecursion(NodeAVL<T> * node) {
	if (node != NULL) {
		inOrderRecursion(node->getLeft());
		std::cout << node->getData() << std::ends;
		inOrderRecursion(node->getRight());
	}
}

template <class T>
void AVL<T>::inOrderOutput() {
	if (this->root != NULL) {
		std::cout << "In-order-output:" << std::ends;
		inOrderRecursion(this->root);
		std::cout << std::endl;
	}
	else {
		std::cout << "Your tree is empty..." << std::endl;
	}
}
