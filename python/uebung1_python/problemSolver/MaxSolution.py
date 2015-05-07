from problemSolver.Solution import Solution
'''
This class is an implementation of the maximum Solution.
'''
class MaxSolution(Solution):
    
    '''
    This method creates a MaxSolution.
    '''
    def __init__(self):
        self.__max = None
        
    '''
    The parameter value is of the type int.
    '''
    def setMax(self, value):
        assert type(value) is int
        if type(value) is int:
            self.__max = value
        assert self.__max is not None
        
    '''
    The method returns the maximum. The data type is int.
    '''
    def getMax(self):
        assert type(self.__max) is int or self.__max is None
        return self.__max