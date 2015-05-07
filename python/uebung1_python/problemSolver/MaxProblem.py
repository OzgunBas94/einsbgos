from problemSolver.DivisibleProblem import DivisibleProblem
from problemSolver.MaxSolution import MaxSolution

'''
This class is an implementation of the maximum Problem.
'''
class MaxProblem(DivisibleProblem):
    
    '''
    This method generates the MaxProblem.
    '''
    def __init__(self):
        self.__solution = MaxSolution()
        self.__tree = None
    
    '''
    This method returns the MaxSolution. 
    '''
    def getSolution(self):
        assert type(self.__solution) is MaxSolution
        if type(self.__solution) is MaxSolution:
            return self.__solution
    
    '''
    This method returns a boolean. It's True when the problem is directly solvable.
    '''
    def isDirectlySolvable(self):
        assert self.__tree is not None
        if self.__tree is not None:
            self.__directlySolvable = False
            
            if self.getBinaryTree().getRoot() is None:
                self.__directlySolvable = True
            if self.getBinaryTree().getRoot().getLeft() is None and self.getBinaryTree().getRoot().getRight() is None:
                self.__directlySolvable = True
            return self.__directlySolvable
    
    '''
    This method divides and solves the problem.
    '''
    def part(self):
        assert self.isDirectlySolvable() is not True
        if self.isDirectlySolvable() is not True:
            node = self.getBinaryTree().getRoot()
            while node.getRight() is not None:
                node = node.getRight()
            self.__solution.setMax(node.getData())
        assert self.__solution.getMax() is not None
    
    '''
    This method solves the problem directly or invokes the method part if the problem is not directly solvable.
    '''
    def solve(self):
        self.__tree = self.getBinaryTree()
        assert self.__tree is not None
        if self.__tree is not None:
            if self.isDirectlySolvable():
                if self.getBinaryTree().getRoot() is None:
                    self.__solution.setMax(None)
                if self.getBinaryTree().getRoot().getLeft() is None and self.getBinaryTree().getRoot().getRight() is None:
                    self.__solution.setMax(self.getBinaryTree().getRoot().getData())
            else:
                self.part()
        assert self.__solution.getMax() is not None