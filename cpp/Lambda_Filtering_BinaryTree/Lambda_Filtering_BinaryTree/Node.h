#ifndef NODE_H
#define NODE_H

template <class T> class Node {

private:
	// Attributes of the class NodeAVL
	Node<T>* right;
	Node<T>* left;
	Node<T>* parent;
	// A int attribute
	T data;

public:
	// Constructor of the class Node
	Node();
	// Constructor of the class Node with inputs
	Node(T data);
	// Deconstructor
	~Node();
	// @param node: to set the node right of another node/a parent
	void setRight(Node<T>* right);
	// @param node: to set the node left of another node/a parent
	void setLeft(Node<T>* left);
	// @param node: to set the parent
	void setParent(Node<T>* parent);
	// @param value: to set the value of a node
	void setData(T data);
	// @return the right node from the parent node
	Node<T>* getRight();
	// @return the left node from the parent node
	Node<T>* getLeft();
	// @return the parent of a node
	Node<T>* getParent();
	// @return the value of a node
	T getData();

};
#endif