'''
Created on 18.05.2015

@author: Gamze
'''

from pars.Parser import Parser
import sys
from sys import argv


def main():
    p = Parser()
    
    del(sys.argv[0])
    
    p.parse("10+10=20=9")
    fobj = open(sys.argv[1])
    for line in fobj:
        p.parse(line.rstrip())
    fobj.close()

if __name__ == '__main__':
    res = main()