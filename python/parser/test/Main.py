'''
Created on 18.05.2015

@author: Gamze
'''

from pars.Parser import Parser
import sys
from sys import argv

'''
This is the main. Here it checks whether in file the expressions are valid or not. 
'''
def main():
    p = Parser()
    
    del(sys.argv[0])
    
#    p.parse("(10+10)+3=20+3")
    file = open(sys.argv[1])
    for line in file:
        p.parse(line.rstrip())
    file.close()

if __name__ == '__main__':
    res = main()