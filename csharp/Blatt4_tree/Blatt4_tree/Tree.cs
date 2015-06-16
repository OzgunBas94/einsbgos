using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    abstract class Tree<T>
        where T: IComparable
    {

        public abstract void insert( T value );
        public abstract bool has( T value );
        public abstract bool remove( T value );
    }
}
