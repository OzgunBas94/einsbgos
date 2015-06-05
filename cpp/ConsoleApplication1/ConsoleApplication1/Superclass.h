#pragma once
#ifndef SUPERCLASS_H
#define SUPERCLASS_H

// A abstract class the superclass
template <class T > class Superclass {

public:
	//abstract methods for the subclasses
	virtual void insert(T data) = 0;
	virtual bool remove(T data) = 0;
	virtual bool search(T data) = 0;

};
#endif
