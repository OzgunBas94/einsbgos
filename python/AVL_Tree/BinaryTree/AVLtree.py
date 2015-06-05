'''
Created on 01.06.2015

@author: Selina
'''
from BinaryTree import MyTree
from BinaryTree import Node

class AVLtree(MyTree):
    '''
    This class creates a self-balancing binary search tree
    '''


    def __init__(self, value=None):
        '''
        The root of the AVL tree will be initialized with a value or None
        '''
        super().__init__(value)
        
    def isbalanced (self):
        '''
        This method checks if the tree is balanced and returns a boolean.
        '''
        balanced = False
        heightLeft = self.getHeight(self.__root.getLeft())
        heightRight = self.getHeight(self.__root.getRight())
        
        if heightLeft - heightRight > 1 or heightLeft - heightRight < -1:
            balanced = False
        else:
            balanced = True
            
        return balanced
        
        
    def getHeight (self, node):
        '''
        This method returns the height of a tree or subtree
        '''
        return self.__getHeightRek(0, node)
        
        
    def __getHeightRec(self, actHeight, node):
        '''
        This method goes through the tree to check the height
        '''
        height = 0;
        
        if node is not None:
            height = max(self.__getHeightRec(actHeight + 1, node.getLeft()),
                          self.__getHeightRec(actHeight +1, node.getright()))
        else: height = actHeight
        return height
    
    
    def insert(self, value):
        '''
        This method inserts a value in the tree and checks for AVL conditions and rebalance the tree if necessary
        '''
        super().insert(value)
        if not self.isbalanced:
            self.__findLoc(value)
            
    def __findLoc(self, currentNode):
        '''
        This method looks for the location of a value in the tree to check which rotation fits to rebalance the tree
        '''
        if self.__root.getLeft().getLeft() is not None and self.has(self.__root.getLeft().getLeft(), currentNode):
            self.__rotateLeftChild() # left subtree of left child
        elif self.__root.getLeft().getRight() is not None and self.has(self.__root.getLeft().getRight(), currentNode):
            self.__doubleRotateLeftChild() #right subtree of left child
        elif self.__root.getRight().getLeft() is not None and self.has(self.__root.getRight().getLeft(), currentNode):
            self.__doubleRotateRightChild() #right subtree of left child
        elif self.__root.getRight().getRight() is not None and self.has(self.__root.getRight().getRight(), currentNode):
            self.__rotateRightChild() #right subtree of right child
        
        
    def __rotateLeftChild(self):
        '''
        This method rotates with the left child of the tree to rebalance it
        '''
        if self.__root.getLeft().getRight() is not None:
            tmp = self.__root.getLeft() #save left child
            self.__root.setLeft(self.__root.getLeft().getRight()) #swap right child of left child with left child
            tmp.setRight(self.__root) # 
            self.root = tmp
        else:
            self.__root.getLeft().setRight(self.__root)
            self.__root = self.__root.getLeft()
            self.__root.getRight().setLeft(None)
            
        
        
        
    def __doubleRotateLeftChild(self):
        '''
        This method double rotates the tree with the left child to rebalance it
        '''
        if self.__root.getLeft().getRight().getLeft() is not None:
            tmp = self.__root.getLeft().getRight()
            self.__root.getLeft().getRight().getRight().setLeft(self.__root.getLeft().getRight().getLeft())
            tmp.setLeft(self.__root.getLeft())
            self.__root.setLeft(tmp)
            self.__root.getLeft().setRight(None)
        else:
            self.__root.getLeft().getRight().setLeft(self.__root.getLeft())
            self.__root.setLeft(self.__root.getLeft().getRight())
            self.__root.getLeft().getLeft().setRight(None)
        self.__rotateLeftChild()
        
        
    def __doubleRotateRightChild(self):
        '''
        This method double rotates the tree with the right child to rebalance it
        '''
        if self.__root.getRight().getLeft().getRight() is not None:
            tmp = self.__root.getRight().getLeft()
            self.__root.getRight().getLeft().getLeft().setRight(self.__root.getRight().getLeft().getRight())
            tmp.setRight(self.__root.getRight())
            self.root.setRight(tmp)
        else:
            self.__root.getRight().getLeft().setRight(self.__root.getRight())
            self.__root.setRight(self.__root.getRight().getLeft())
            self.__root.getRight().getRight().setLeft(None)
        self.__rotateRightChild()
    
    
    def __rotateRightChild(self):
        '''
        This method rotates the tree with the right child to rebalance it
        '''
        if self.__root.getRight() is not None:
            
            tmp = self.__root.getRight()
            self.__root.setRight(self.__root.getRight().getLeft())
            tmp.setLeft(self.__root)
            self.root = tmp
        else:
            self.__root.getRight().setLeft(self.__root)
            self.__root = self.__root.getRight()
            self.__root.getLeft().setRight(None)
        
    
    def has(self,currentNode, value):
        '''
        This method checks if tree or subtree contains the value
        '''
        assert type(value) is int
        return self.__hasRecursion(currentNode,value)
    
    '''
    This method searches for the parameter value.
    The data type of currentNode is Node.
    The data type of value is int.
    It returns a boolean variable. It returns true when the value is in the tree or subtree.
    '''
    def __hasRecursion(self,currentNode,value):
        assert type(currentNode) is Node or currentNode is None
        has = False
        
        if currentNode is None:
            has = False
        elif currentNode.getData() is value:
            has = True #found
        elif value < currentNode.getData(): #search left
            has = self.__hasRecursion(currentNode.getLeft(), value)
        elif value > currentNode.getData(): #search right
            has = self.__hasRecursion(currentNode.getRight(), value)
            
        return has
        

    def delete(self, value):
        super().delete(value)
    
    
    
    