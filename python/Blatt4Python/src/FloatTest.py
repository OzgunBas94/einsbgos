'''
Created on 17.06.2015

@author: ozgun
'''

from BinaryTree import BinaryTree
from random import uniform

class FloatTest():
    bt = BinaryTree()
    '''
        Constructor
    '''
    def __init__(self, tree):
        self.bt = tree
        
        
    '''
    This method initialize the tree with random float values
    if low border is bigger then high border it gives a Error Message
    the method returns a random floating point numbe
    '''   
    def initTree(self, low, high, size):
        if (low > high) :
            print("EXCEPTION : min border bigger than max border")
        if size < 0 :
            print("EXCEPTION : size smaller than 0")

        for i in range(size):
            self.bt.insert(uniform(low,high))
        
    '''
    This method filters the tree with lambda expressions
    it prints the values who contains the tree and all the negative values which were filtered and
    all values which are 5 or smaller
    '''
    def printTree(self):
        
        print("\n*** FLOAT-Tree Values ***\n")
        print(self.bt.getTreeAsArray(self.bt.getRoot()))
        print("-----------------------------------------------------------------------------------------------------------------------------------\n")
      
        print("NEGATIVE VALUES : ")
        negVal = list(self.bt.filter(lambda val : val < 0, self.bt.getRoot()))
        print(negVal)
        print("-----------------------------------------------------------------------------------------------------------------------------------\n")
        
        print("\nVALUES <= 5 :")
        lesVal = list(self.bt.filter(lambda val : val <= 5, self.bt.getRoot()))
        print(lesVal)
        print("-----------------------------------------------------------------------------------------------------------------------------------\n")
        
        
        print("EVEN VALUE -> %2 :")
        evenVal = list(self.bt.filter(lambda val : val % 2 == 0, self.bt.getRoot()))
        print(evenVal)
        print("-----------------------------------------------------------------------------------------------------------------------------------\n") 
        print("\n\n")