from problemSolver.DivisibleProblem import DivisibleProblem
from problemSolver.SumSolution import SumSolution
from bTree.Node import Node
'''
This class is in implementation of the SumProblem which inherits DivisibleProblem.
'''
class SumProblem(DivisibleProblem):
    
    '''
    This method creates a SumProblem.
    '''
    def __init__(self):
        self.__solution = SumSolution()
        self.__root = None
    
    '''
    This method returns the solution. The type isSumSolution.
    '''
    def getSolution(self):
        assert type(self.__solution) is SumSolution or self.__solution is None
        if type(self.__solution) is SumSolution or self.__solution is None:
            return self.__solution
    
    '''
    This method returns the boolean, whether it's directly solvable or not.
    '''
    def isDirectlySolvable(self):
        assert self.__root is not None
        if self.__root is not None:
            self.__directlySolvable = False
            if self.getBinaryTree().getRoot() is None:
                self.__directlySolvable = True
            if self.__root.getLeft() is None and self.__root.getRight() is None:
                self.__directlySolvable = True
            return self.__directlySolvable
    
    '''
    This method divides the problem and invokes the method which solves it.
    '''
    def part(self):
        assert self.__directlySolvable is not True
        if self.__directlySolvable is not True:
            node = self.__root
            self.__solution.setSum(self.getSumRecursion(node))
        
    '''
    This method solves the problem after dividing it.
    '''
    def getSumRecursion(self, node):
        assert type(node) is Node or node is None
        sum = 0
        if type(node) is Node:
            sum += node.getData() + self.getSumRecursion(node.getLeft()) + self.getSumRecursion(node.getRight())
        return sum
    
    '''
    This method solves the problem if it's directly solvable. If not it invokes the method part.
    '''
    def solve(self):
        self.__root = self.getBinaryTree().getRoot()
        assert self.__root is not None
        if self.__root is not None:
            if self.isDirectlySolvable():
                if self.getBinaryTree().getRoot() is None:
                    self.__solution.setSum(None)
                if self.__root.getLeft() is None and self.__root.getRight() is None:
                    self.__solution.setSum(self.__root.getData())
            else:
                self.part()