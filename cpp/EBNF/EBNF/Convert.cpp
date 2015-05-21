#include "Convert.h"
/*
This is a utility class to parse a string.
*/

/*
This is the constructor of the utility class.
*/
Convert::Convert()
{
	isTerm = false;
	result = false;
	input = "";
	number = 0;

}

/*
This is the destructor of the utility class.
*/
Convert::~Convert()
{
}

void Convert::setNumber(long number){
	this->number = number;
}

void Convert::setInput(string input){
	this->input = input;
}

long Convert::getNumber(){
	return number;
}

string Convert::getInput(){
	return input;
}
