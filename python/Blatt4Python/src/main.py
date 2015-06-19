'''
Created on 17.06.2015

@author: ozgun
'''
from BinaryTree import BinaryTree
from FloatTest import FloatTest
from StringTest import StringTest

class main():
    
    '''
    creating a float Tree
    10 random floats will be added between -100 and 100
    after the tree will be printed
   
    '''
    floatValue = BinaryTree()
    floatValue.insert(2.0)
    testFloat = FloatTest(floatValue)
    testFloat.initTree(-100, 100, 10)
    testFloat.printTree()
    
    
    '''
    creating a sting tree
    10 random strings will be added between 1 and 30 character 
    after the tree will be printed
    '''    
    stringValue = BinaryTree()
    
    testString = StringTest(stringValue)
    testString.initTree(1, 30, 10)
    testString.printTree()
    
