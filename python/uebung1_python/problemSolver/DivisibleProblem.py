from problemSolver.Problem import Problem
from bTree.BinaryTree import BinaryTree
'''
This abstract class is an implementation of a divisible problem.
'''
from abc import abstractmethod
class DivisibleProblem(Problem):
    
    '''
    This method creates the variables directlySolvable and tree.
    '''
    @abstractmethod
    def __init__(self):
        self.__directlySolvable = None
        self.__tree = None
    
    '''
    The code of this method is not implemented. It should return a boolean.
    '''
    @abstractmethod
    def isDirectlySolvable(self):
        pass
    
    '''
    The code of this method is not implemented.
    The precondition for this method is that the problem is directly solvable.
    '''
    @abstractmethod
    def part(self):
        pass
    
    '''
    The code of this method is not implemented. 
    '''
    @abstractmethod
    def solve(self):
        pass
    
    '''
    The parameter value is of the type int and will be the value of the root in the binary tree.
    '''
    def setBinaryTree(self, value):
        assert type(value) is int or value is None
        if type(value) is int or value is None:
            self.__tree = BinaryTree(value)
    
    '''
    This method returns the tree.
    '''
    def getBinaryTree(self):
        assert type(self.__tree) is BinaryTree
        return self.__tree
    