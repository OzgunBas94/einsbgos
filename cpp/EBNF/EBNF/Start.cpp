#include "Parser.h"
#include <stdio.h>
#include <fstream>

using namespace std;
/*
This is the main method. It invokes the parse method.
If the first argument is file, it parses the equations from the file in the second argument.
If the first argument is an equation, the equation gets parsed.
*/
void main(int argc, char *argv[]){

	Parser p;
	

	if (argc == 2) {
		p.parse(argv[1]);
	}
	else if (strcmp(argv[1], "file") == 0 && argc == 3) {
		ifstream file(argv[2]);
		string text;

		while(!file.eof()){
			getline(file, text);
			p.parse(text);
			printf("\n");
		}		
	}
	else {
		printf("The command-line arguments are invalid");
	}
	
	getchar();
	
}
