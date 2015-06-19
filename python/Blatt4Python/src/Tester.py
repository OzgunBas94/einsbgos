'''
Created on 17.06.2015

@author: ozgun
'''
import random, math, string

class tester():
    
    '''
    constructor of this class
    '''
    def __init__(self, binaryTree):
        self.tree = binaryTree
        
    
    '''
    this method is for  a random int
    it returns a int between 1 and 10
    '''
    def random_data(self):
        
            return random.randint(1,10)
    
    '''
    this method returns the tree
    '''
    def getTree(self):
        
        return self.tree
    
    '''
    here will created  a random  string
    '''
    def random_string(self):
        size=6 
        chars=string.ascii_uppercase
        return ''.join(random.choice(chars) for _ in range(size))
    
    
    '''
    this method is the int tester
    it saves the random data in a array ar and
    ar will be inserted
    '''
    def int_test(self,tree):
        i = 0
        ar = []
        while i < 10:    
            data = self.random_data()
            tree.insert(data)
            ar.insert(i, data)
            i = i+1
             
        for x in ar:
            print(tree.has(x))
            
    '''
     this method is the string tester
     it saves the random string in a array ar and
     ar will be inserted        
    '''
    def string_test(self,tree):
        i = 0
        ar = []
        while i < 10:    
            data = self.random_string()
            tree.insert(data)
            ar.insert(i, data)
            i = i+1
             
        for x in ar:
          
            print(tree.has(x))