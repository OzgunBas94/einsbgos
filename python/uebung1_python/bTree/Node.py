'''
This class is an implementation of a node.
'''
class Node:
    
    
    '''
    This method generates a node.
    The data type of the parameter value is int. It's the value of the node.
    '''
    def __init__(self, value):
        assert type(value) is int
        if type(value) is int:
            self.__value = None
            self.__left = None
            self.__right = None
            self.__parent = None
            self.__setData(value)
    
    '''
    The data type of the parameter value is int.
    '''
    def __setData(self,value):
        assert type(value) is int
        if type(value) is int:
            self.__value = value
        
    '''
    This method returns the value of the node.
    '''
    def getData(self):
        assert type(self.__value) is int or self.__value is None
        if type(self.__value) is int or self.__value is None:
            return self.__value
    
    '''
    This method sets the left node.
    The data type of currentNode is Node. It will be set as the left node.
    '''
    def setLeft(self, currentNode):
        assert type(currentNode) is Node or currentNode is None
        if type(currentNode) is Node or currentNode is None:
            self.__left = currentNode
        assert type(self.__left) is Node or self.__left is None
        
    '''
    This method returns the left node.
    '''
    def getLeft(self):
        assert type(self.__left) is Node or self.__left is None
        if type(self.__left) is Node or self.__left is None:
            return self.__left
    
    '''
    This method sets the right node.
    The data type of currentNode is Node. It will be set as the right node.
    '''
    def setRight(self, currentNode):
        assert type(currentNode) is Node or currentNode is None
        if type(currentNode) is Node or currentNode is None: 
            self.__right = currentNode
        assert type(self.__right) is Node or self.__right is None
        
    '''
    This method returns the right node.
    '''
    def getRight(self):
        assert type(self.__right) is Node or self.__right is None
        if type(self.__right) is Node or self.__right is None:
            return self.__right
    
    '''
    This method sets the parent node.
    The data type of currentNode is Node. It will be set as the parent node.
    '''
    def setParent(self, currentNode):
        assert type(currentNode) is Node or currentNode is None
        if type(currentNode) is Node or currentNode is None:
            self.__parent = currentNode
        assert type(self.__parent) is Node or self.__parent is None
        
    '''
    This method returns the parent node.
    '''
    def getParent(self):
        assert type(self.__parent) is Node or self.__parent is None
        if type(self.__parent) is Node or self.__parent is None:
            return self.__parent