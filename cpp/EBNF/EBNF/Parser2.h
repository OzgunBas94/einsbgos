#pragma once
#include "Convert.h"
#include <sstream>

using namespace std;

class Parser2
{
public:
	Parser2();
	~Parser2();

	void parse(string input);

private:

	Convert parseEquation(string input);
	Convert parseExpression(string input);
	Convert parseTerm(string input);
	Convert parseFactor(string input);
	Convert parseConstant(string input);
	bool isDigit(char input);
	bool isDigitWithoutZero(char input);
	bool isError;
	bool isFirst;
};

