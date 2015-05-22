'''
Created on May 18, 2015

@author: Gamze
'''
from pars.Convert import Convert

'''
This class is an implementation of a Parser.
'''
class Parser:
    
    '''
    This is the constructor of the method class Parser
    '''
    def __init__(self):
        self.__isError = False
        self.__isFirst = True

    '''
    This is the method which will be passed on first. It writes out what the result is.
    The method invokes the method parseEquation.
    Parameter: input String.
    '''
    def parse(self, input):
        c = self.__parseEquation(input)
        if not self.__isError:
            if c.isTerm:
                if c.result:
                    print("equation: true")
                else:
                    print("equation: false")
            else:
                s = "Result: "
                s += str(c.getNumber())
                print(s)
        else:
            print("invalid input")
            self.__isError = False
            self.__isFirst = True
            
    '''
    This method invokes the method parseExpression.
    Parameters: String input.
    Return: a Convert object which contains the needed information. 
    '''              
    def __parseEquation(self, input):
        if not self.__isError:
            c = self.__parseExpression(input)
            if(c.getInput() is not "" and c.getInput()[0] == "="):
                temp = c.getNumber()
                c.setInput(c.getInput()[1:])
                self.__isFirst = True
                for tmp in c.getInput():
                    if tmp is "=":
                        self.__isError = True
                if not self.__isError:
                    c = self.__parseExpression(c.getInput())
                    c.isTerm = True
                    if temp is c.getNumber():
                        c.result = True
        return c
    
    '''
    This method invokes the method parseTerm.
    It searches for a + expression and if it finds one, it pass on the method parseTerm again.
    Parameters: string input.
    Return: a Convert object which contains the needed information.
    '''
    def __parseExpression(self, input):
        c = Convert()
        if not self.__isError:
            c = self.__parseTerm(input)
            temp = 0
            while c.getInput() is not "" and c.getInput()[0] is "+":
                c.setInput(c.getInput()[1:])
                if c.getInput() is not "" and c.getInput()[0] is "*" or c.getInput()[0] is "+":
                    self.__isError = True
                temp = c.getNumber()
                c = self.__parseTerm(c.getInput())
                c.setNumber(temp + c.getNumber())
        return c
    
    '''
    This method pass on the method parseFactor.
    It searches for a * expression and if it finds one, it pass on the method parseFactor again.
    Parameters: string input
    Return: a Convert object which contains the needed information.
    '''
    def __parseTerm(self, input):
        if not self.__isError:
            c = self.__parseFactor(input)
            temp = 0
            while c.getInput() is not "" and c.getInput()[0] is "*":
                c.setInput(c.getInput()[1:])
                if c.getInput() is not "" and c.getInput()[0] is "*" or c.getInput()[0] is "+":
                    self.__isError = True
                temp = c.getNumber()
                c = self.__parseFactor(c.getInput())
                c.setNumber(temp * c.getNumber())
        return c
    
    '''
    If there's a bracket, the method pass on the method parseExpression, otherwise it pass on the method parseConstant.
    Parameters: string input.
    Return: a Convert object which contains the needed information.
    '''
    def __parseFactor(self, input):
        c = Convert()
        if not self.__isError:
            if self.__isFirst:
                openingBrackets = 0
                closingBrackets = 0
                rightBrackets = True
                for tmp in input:
                    if tmp is "(":
                        openingBrackets = openingBrackets+1
                    elif tmp is ")":
                        closingBrackets = closingBrackets+1
                        if closingBrackets > openingBrackets:
                            rightBrackets = False
                if closingBrackets != openingBrackets or not rightBrackets:
                    self.__isError = True
                self.__isFirst = False
            if input is not "" and input[0] is "(":
                input = input[1:]
                c.setInput(input)
                if c.getInput() is not "":
                    c = self.__parseExpression(c.getInput())
                if c.getInput() is not "" and c.getInput()[0] is ")":
                    c.setInput(c.getInput()[1:])
            else:
                c = self.__parseConstant(input)
        return c
    
    '''
    This method creates a number by passing on the methods isDigitWithoutZero and isDigit. 
    The number will be saved in the Convert-object.
    Parameters: string input.
    Return: a Convert object which contains the needed information.
    '''
    def __parseConstant(self, input):
        res = ""
        c = Convert()
        if not self.__isError:
            if input is not "" and self.__isDigitWithoutZero(input[0]):
                res += input[0]
                input = input[1:]
            while input is not "" and self.__isDigit(input[0]):
                res+= input[0]
                input = input[1:]
            num = int(res)
            c.setNumber(num)
            c.setInput(input)
        return c
    
    '''
    This method finds out if the input expression is a number between 0 and 9.
    Parameters: char input.
    Return: a boolean.
    '''
    def __isDigit(self, input):
        res = False
        if self.__isDigitWithoutZero(input) or input is "0":
            res = True
        return res
    
    '''
    This method finds out if the input expression is a number between 1 and 9.
    Parameters: char input.
    Return: a boolean. true when it's a number between 1 and 9
    '''
    def __isDigitWithoutZero(self, input):
        res = False
        if input is "1" or input is "2" or input is "3" or input is "4" or input is "5" or input is "6" or input is "7" or input is "8" or input is "9":
            res = True
        if input is not "1" and input is not "2" and input is not "3" and input is not "4" and input is not "5" and input is not "6" and input is not "7" and input is not "8" and input is not "9" and input is not "0" and input is not "+" and input is not "*" and input is not "=" and input is not "(" and input is not ")":
            self.__isError = True
        return res
