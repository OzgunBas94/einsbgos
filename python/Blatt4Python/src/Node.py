'''
Created on 17.06.2015

@author: ozgun
'''
class Node:
    
    
    '''
    This method generates a node.
    The data type of the parameter value is int. It's the value of the node.
    '''
    def __init__(self, value):
        
        self.value = None
        self.left = None
        self.right = None
        self.parent = None
        self.setData(value)
    '''
    The data type of the parameter value is int.
    '''
    def setData(self,value):
        self.value = value
        
    '''
    This method returns the value of the node.
    '''
    def getData(self):
        
        return self.value
    
    '''
    This method sets the left node.
    The data type of currentNode is Node. It will be set as the left node.
    '''
    def setLeft(self, currentNode):

        
            self.left = currentNode
        
        
    '''
    This method returns the left node.
    '''
    def getLeft(self):
       
        
            return self.left
    
    '''
    This method sets the right node.
    The data type of currentNode is Node. It will be set as the right node.
    '''
    def setRight(self, currentNode):
        

            self.right = currentNode        
    '''
    This method returns the right node.
    '''
    def getRight(self):
        
        
            return self.right
    
    '''
    This method sets the parent node.
    The data type of currentNode is Node. It will be set as the parent node.
    '''
    def setParent(self, currentNode):
       
        
            self.parent = currentNode
       
        
    '''
    This method returns the parent node.
    '''
    def getParent(self):
        
        if type(self.parent) is Node or self.parent is None:
            return self.parent