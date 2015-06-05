'''
Created on 02.06.2015

@author: Selina
'''
from BinaryTree.AVLtree import AVLtree


def main():
    
    tree = AVLtree(25)
    tree.insert(15)
    tree.insert(13)
    
    print(tree.getRoot().getData())
    
if __name__ == '__main__':
    res= main()