from problemSolver.Solution import Solution
'''
This class is an implementation of the SumSolution. It inherits Solution.
'''
class SumSolution(Solution):

    '''
    This method creates SumSolution.
    '''
    def __init__(self):
        self.__sum = None
        
    '''
    The data type of the parameter value is int.
    '''
    def setSum(self, value):
        assert type(value) is int or value is None
        if type(value) is int or value is None:
            self.__sum = value
    
    '''
    The method returns the sum.
    '''
    def getSum(self):
        return self.__sum
    