﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    class TestStringTree :ReturnRandom
    {

        TreeInterface<string> t;

        public TestStringTree(TreeInterface<string> t)
        {
            this.t = t;
        }

        // This method inserts a random string to the tree.
        // Parameters: min: the min length of the string
        //             max: the max length of the string
        //             num: how much strings the method should insert to the tree
        public void insertRandom(int min, int max, int num)
        {
            if( num < 1 )
            {
                System.Console.WriteLine("there are no strings to insert");
            }
            else if (min > max)
            {
                System.Console.WriteLine("min is higher than max");
            }
            else if (min < 1)
            {
                System.Console.WriteLine("min length can't be smaller than 1");
            }
            else
            {
                for( int i = 0;i < num;i++ )
                {
                    t.insert(randomString(min,max));
                }
            }
            
        }
    }
}
