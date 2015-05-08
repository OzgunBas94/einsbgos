from bTree.BinaryTree import BinaryTree

'''Main function'''
def main():
    
    btree = BinaryTree(25)
    btree.insert(10)
    btree.insert(30)
    btree.insert(20)
    btree.insert(25)
    btree.insert(7)
    btree.insert(4)
    btree.insert(8)
    
    
    print(btree.delete(25))
    print(btree.has(25))
    
    btree.insert(24)
    print(btree.has(24))
    
    btree.insert(24)
    
    print(btree.inOrder())
    

if __name__ == '__main__':
    res = main()