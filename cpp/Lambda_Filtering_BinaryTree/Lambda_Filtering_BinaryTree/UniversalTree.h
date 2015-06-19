#pragma once
#ifndef UNIVERSALTREE_H
#define UNIVERSALTREE_H

// A abstract class the superclass
template <class T > class UniversalTree {

public:
	//abstract methods for the subclasses
	~UniversalTree();
	virtual void insert(T data) = 0;
	virtual bool remove(T data) = 0;
	virtual bool search(T data) = 0;

};
#endif