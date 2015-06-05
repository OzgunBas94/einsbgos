using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBaum
{
    /// <summary>
    /// Tree data structure
    /// </summary>
    abstract class Tree<T>
        where T : IComparable
    {


        /// <summary>
        /// abstract method Add dont have a return v
        /// </summary>
        /// <param name="Value"></param>
        public abstract void Add(T Value);


        /// <summary>
        /// avtract method Contains returns a bool
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public abstract bool Contains(T Value);


        /// <summary>
        /// abstract method Remove returns a bool
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public abstract bool Remove(T Value);
    }
}
