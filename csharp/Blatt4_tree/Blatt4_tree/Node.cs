using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    public class Node<T> 
        where T: IComparable
    {
        private Comparison<IComparable> comparer = Compare;

        public static int Compare( IComparable x,IComparable y ) {
            return x.CompareTo(y);
        }

        private static int CompareElements( IComparable x,IComparable y ) {
            return x.CompareTo(y);
        }

        private T value;
        private Node<T> left {get; set;}
        private Node<T> right {
            get;
            set;
        }
        private Node<T> parent {
            get;
            set;
        }


        private int balance;

        // Constructor of the class "Node"
        // @param value: the value of the new node
        public Node( T value ) {
            this.setData(value);
            this.balance = 0;
        }

        //sets the balance
        //parameter: balance
        public virtual void setBalance( int balance ) {
            this.balance = balance;
        }

        //returns the balance
        public virtual int getBalance( ) {
            return this.balance;
        }

        // @param value: to set the value of a node
        private void setData( T value ) {
            this.value = value;
        }

        // @param node: to set the node left of another node/a parent
        public virtual void setLeft( Node<T> node ) {
            this.left = node;
        }

        // @param node: to set the node right of another node/a parent
        public virtual void setRight( Node<T> node ) {
            this.right = node;
        }

        // @param node: to set the parent
        public virtual void setParent( Node<T> node ) {
            this.parent = node;
        }

        // @return the parent of a node
        public virtual Node<T> getParent( ) {
            return parent;
        }

        // @return the value of a node
        public T Data {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        // @return the left node from the parent node
        public virtual Node<T> getLeft( ) {
            return left;
        }

        // @return the right node from the parent node
        public virtual Node<T> getRight( ) {
            return right;
        }

        public String toString( ) {
            return this.ToString( );
        }

        
    }
}
