using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    abstract class ReturnRandom
    {

        private Random r = new Random( );

        //abstract method to return a random value
        public abstract Object random( int min,int max );

        //returns random
        public Random getRandom( ) {
            return r;
        }
        

        

    }
}
