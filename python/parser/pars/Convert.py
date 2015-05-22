'''
Created on May 18, 2015

@author: Gamze
'''

'''
This is the constructor of the utility class.
'''
class Convert:
    
    '''
    Constructor of the class Convert
    '''
    def __init__(self):
        self.isTerm = False
        self.result = False
        self.__input =""
        self.__number = 0
     
    '''
    Here we set the result of a term
    '''      
    def setNumber(self, number):
        self.__number = number
        
    '''
    Here we set the input
    '''
    
    def setInput(self, input):
        self.__input = input
        
    '''
    In this method we get the number of the result
    ''' 
    def getNumber(self):
        return self.__number
    
    '''
    In this method we get the input.
    '''
    def getInput(self):
        return self.__input