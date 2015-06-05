#ifndef NodeAVL_H
#define NodeAVL_H

template <class T> class NodeAVL{
private:
	// A int attribute
	T data;
	// Attributes of the class NodeAVL
	NodeAVL<T> * left;
	NodeAVL<T> * right;
	NodeAVL<T> *parent;

public:
	// Constructor of the class NodeAVL
	NodeAVL();
	// Constructor of the class NodeAVL with inputs
	NodeAVL(T data, NodeAVL<T> * left, NodeAVL<T> * right, NodeAVL<T> * parent);
	// Deconstructor
	~NodeAVL();
	// @return the value of a node
	T getData();
	// @return the left node from the parent node
	NodeAVL<T> * getLeft();
	// @return the right node from the parent node
	NodeAVL<T> * getRight();
	// @return the parent of a node
	NodeAVL<T> * getParent();
	// @param node: to set the node left of another node/a parent
	void setLeft(NodeAVL<T> * node);
	// @param value: to set the value of a node
	void setData(T data);
	// @param node: to set the node right of another node/a parent
	void setRight(NodeAVL<T> * node);
	// @param node: to set the parent
	void setParent(NodeAVL<T> * npde);

};
#endif

