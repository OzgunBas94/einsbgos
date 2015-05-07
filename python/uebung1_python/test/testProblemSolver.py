from problemSolver.MaxProblem import MaxProblem
from problemSolver.SumProblem import SumProblem

'''Main function'''
def main():
    
    max = MaxProblem()
    max.setBinaryTree(10)
    max.getBinaryTree().insert(12)
    max.getBinaryTree().insert(9)
    max.solve()
    print(max.getSolution().getMax())
    
    sum = SumProblem()
    sum.setBinaryTree(10)
    sum.getBinaryTree().insert(12)
    sum.getBinaryTree().insert(5)
    sum.getBinaryTree().insert(4)
    sum.solve()
    print(sum.getSolution().getSum())
    
   
    

if __name__ == '__main__':
    res = main()