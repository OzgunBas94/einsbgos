#include "Parser.h"

/*
This class parses a string. If the string is valid, it writes out the result.
*/

/*
This is the constructor of the class Parser.
*/
Parser::Parser()
{
	isError = false;
	isFirst = true;
}

/*
This is the destructor of the class Parser.
*/
Parser::~Parser()
{
}

/*
This is the method which will be invoked first.
It writes out what the result is.
The method invokes the method parseEquation.
Parameter: string input. It's the string that should be parsed.
*/
void Parser::parse(string input) {
	Convert c = parseEquation(input);
	if (!isError) {
		if (c.isTerm){

			if (c.result){
				printf("It's an equation and the result is: true");
			}
			else{
				printf("It's an equation and the result is: false");
			}
		}
		else{
			printf("It's a term and the result is: %i", c.getNumber());
		}
	}
	else {
		printf("invalid input");
	}
	isError = false;
	isFirst = true;
}


/*
This method invokes the method parseExpression.
It searches for a =-character and if it finds one, it invokes the method parseExpression again.
Parameters: string input, the string which should be parsed.
Return: a Convert object which contains the needed information.
*/
Convert Parser::parseEquation(string input){
	
	Convert c;
	if (!isError) {
		c = parseExpression(input);

		if (c.getInput() != "" && c.getInput()[0] == '='){
			long temp = c.getNumber();

			c.setInput(c.getInput().erase(0, 1));
			isFirst = true;
			for (char &tmp : c.getInput()) {
				if (tmp == '=') {
					isError = true;
				}
			}
			/*if (c.getInput() != "" && c.getInput()[0] == '+' || c.getInput()[0] == '*') {
				isError = true;
				}*/
			if (!isError) {
				c = parseExpression(c.getInput());
				c.isTerm = true;
				if (temp == c.getNumber()){
					c.result = true;
				}
			}

		}
	}
	return c;
}


/*
This method invokes the method parseTerm.
It searches for a +-character and if it finds one, it invokes the method parseTerm again.
Parameters: string input, the string which should be parsed.
Return: a Convert object which contains the needed information.
*/
Convert Parser::parseExpression(string input){
	Convert c;
	if (!isError) {
		c = parseTerm(input);

		long temp;

		while (c.getInput() != "" && c.getInput()[0] == '+'){

			c.setInput(c.getInput().erase(0, 1));
			if (c.getInput() != "" && c.getInput()[0] == '*' || c.getInput()[0] == '+') {
				isError = true;
			}
			
				temp = c.getNumber();
				c = parseTerm(c.getInput());
				c.setNumber(temp + c.getNumber());
		}
	}
	return c;
}


/*
This method invokes the method parseFactor.
It searches for a *-character and if it finds one, it invokes the method parseFactor again.
Parameters: string input, the string which should be parsed.
Return: a Convert object which contains the needed information.
*/
Convert Parser::parseTerm(string input){
	
	Convert c;

	if (!isError){
		c = parseFactor(input);

		long temp;

		while (c.getInput() != "" && c.getInput()[0] == '*'){

			c.setInput(c.getInput().erase(0, 1));

			if (c.getInput() != "" && c.getInput()[0] == '*' || c.getInput()[0] == '+') {
				isError = true;
				
			}
			temp = c.getNumber();
			c = parseFactor(c.getInput());
			c.setNumber(temp * c.getNumber());

		}
	}
	return c;
}


/*
If there's a bracket, the method invokes parseExpression, otherwise it invokes parseConstant.
Parameters: string input, the string which should be parsed.
Return: a Convert object which contains the needed information.
*/
Convert Parser::parseFactor(string input){

	Convert c;
	if (!isError) {
		if (isFirst) {
			int openingBrackets = 0, closingBrackets = 0;
			bool rightBrackets = true;
			for (char &tmp : input) {
				if (tmp == '(') {
					openingBrackets++;
				}
				else if (tmp == ')') {
					closingBrackets++;
					if (closingBrackets > openingBrackets) {
						rightBrackets = false;
					}
				}
			}
			if (closingBrackets != openingBrackets || !rightBrackets) {
				isError = true;
			}
			isFirst = false;
		}

		if (input != "" && input[0] == '('){

			input.erase(0, 1);
			c.setInput(input);

			if (c.getInput() != ""){
				c = parseExpression(c.getInput());
			}

			if (c.getInput() != "" && c.getInput()[0] == ')') {
				c.setInput(c.getInput().erase(0, 1));
			}
		}
		else{
			c = parseConstant(input);
		}
	}
	return c;

}


/*
This method creates a number by invoking the methods isDigitWithoutZero and isDigit. 
The nuber will be saved in the Convert-object.
Parameters: string input, the string which should be parsed.
Return: a Convert object which contains the needed information.
*/
Convert Parser::parseConstant(string input){
	string res = "";
	Convert c;
	if (!isError) {
		if (input != "" && isDigitWithoutZero(input[0])){
			res += input[0];
			input.erase(0, 1);
		}

		while (input != "" && isDigit(input[0])){

			res += input[0];
			input.erase(0, 1);
		}


		char *cstr = new char[res.length()];
		strcpy(cstr, res.c_str());

		c.setNumber(atol(cstr));
		c.setInput(input);
	}
	return c;
}


/*
This method finds out if the input-char is a number between 0 and 9.
Parameters: char input, the char which should be checked.
Return: a boolean. true when it's a number between 0 and 9
*/
bool Parser::isDigit(char input){
	bool res = false;
	if (isDigitWithoutZero(input) || input == '0') {
		res = true;
	}
	return res;
}


/*
This method finds out if the input-char is a number between 1 and 9.
Parameters: char input, the char which should be checked.
Return: a boolean. true when it's a number between 1 and 9
*/
bool Parser::isDigitWithoutZero(char input){
	bool res = false;
	if (input == '1' || input == '2' || input == '3'
		|| input == '4' || input == '5' || input == '6'
		|| input == '7' || input == '8' || input == '9') {
		res = true;
	}

	if (input != '1' && input != '2' && input != '3' && input != '4'
		&& input != '5' && input != '6' && input != '7' && input != '8'
		&& input != '9' && input != '0' && input != '+' && input != '*' && input != '='
		&& input != '(' && input != ')') {
		isError = true;
	}

	return res;
}