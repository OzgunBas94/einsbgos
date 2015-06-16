using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate bool Predicate<T>(T value);

namespace Blatt4_tree
{
    interface TreeInterface<T>
        where T : IComparable
    {

        void insert( T value );

        bool remove( T value );

        bool has( T value );

        T[] filter(Predicate<T> lambda);
    }
}
