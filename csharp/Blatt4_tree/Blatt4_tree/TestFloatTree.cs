using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    class TestFloatTree : ReturnRandom
    {

        TreeInterface<float> t;

        public TestFloatTree(TreeInterface<float> t)
        {
            this.t = t;
        }

        
        // This method inserts a random float to the tree.
        // Parameters: min: the min value of the float
        //             max: the max value of the float
        //             num: how much numbers the method should insert to the tree

        public void insertRandom(int min, int max, int num)
        {
            
            if (num < 1)
            {
                System.Console.WriteLine("there are no numbers to insert");
            }
            else if( min > max )
            {
                System.Console.WriteLine("min is higher than max");
            }
            else
            {
                for( int i = 0;i < num;i++ )
                {
                    t.insert(randomFloat(min,max));
                }
            }
        }
    }
}
