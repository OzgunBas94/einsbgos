'''
Created on 17.06.2015

@author: ozgun
'''
from BinaryTree import BinaryTree
from random import choice
from random import randint
import string


class StringTest(object):
    
    bt = BinaryTree()
    '''
        Constructor
    '''
    def __init__(self, tree):
        self.bt = tree
        
        
    '''
    This method initialize the tree with random strings
    '''   
    def initTree(self, low, high, size):
        if (low > high) :
            print("EXCEPTION: min border is bigger than max border")
        if size < 0 :
            print("EXCEPTION : size smaller than 0")

        for i in range(size):
            randomString = ""
            for j in range(0,randint(low,high)):
                randomString = randomString + choice(string.ascii_letters)
            self.bt.insert(randomString)
    
    '''
    This method filtered tree with lambda Expressions
    it prints the strings who contains the StringTree and all strings 
    where are a 's' or 'S'  which were filtered and
    all strings which are 3 or bigger
    '''
    def printTree(self):
        print("*** STRING-Tree Values ***\n")
        print(self.bt.getTreeAsArray(self.bt.getRoot()))
        print("-----------------------------------------------------------------------------------------------------------------------------------\n")

      
        print("\nLENGTH >= 3")
        negVal = list(self.bt.filter(lambda val : len(val) >= 3, self.bt.getRoot())) 
        print(negVal)
        print("-----------------------------------------------------------------------------------------------------------------------------------\n")
       
        
        print("\nCONTAINS 's' or 'S' :")
        lesVal = list(self.bt.filter(lambda val : val.find("s") is not -1 or val.find("S") is not -1, self.bt.getRoot()))
        print(lesVal)
        print("-----------------------------------------------------------------------------------------------------------------------------------\n")