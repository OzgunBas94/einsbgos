from problemSolver.Solution import Solution
from abc import abstractmethod
'''
This abstract class is an implementation of the problem.
'''
class Problem:
    
    '''
    This method creates the variable solution.
    '''
    @abstractmethod
    def __init__(self):
        self.__solution = Solution()
    
    '''
    The code of this method is not implemented.
    '''
    @abstractmethod
    def getSolution(self):
        pass