#pragma once
#include <string>
using namespace std;

class Convert
{
private:
	string input;
	long number;
	
public:
	bool isTerm;
	bool result;
	void setNumber(long number);
	long getNumber();
	void setInput(string input);
	string getInput();
	Convert();
	~Convert();


};

