using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    class AVL<T> : Tree<T> ,  TreeInterface<T>
        where T : IComparable
    {
        private bool rebalance;
        private Node<T> root;
        private List<T> results = new List<T>( );

        public AVL() {
            rebalance = false;
        }

        public AVL( T value ) {
            rebalance = false;
            this.root = new Node<T>(value);
        }

        public Node<T> getRoot( ) {
            return this.root;
        }

        //rotates the tree if needed
        //parameters: c: describes where to rotate
        private Node<T> rotateLeft( Node<T> b ) {
            Node<T> a = b.getLeft( );
            b.setLeft(a.getRight( ));
            a.setRight(b);

            b.setBalance(0);
            a.setBalance(0);
            return a;
        }

        //rotates the tree if needed
        //parameters: c: describes where to rotate
        private Node<T> rotateRight( Node<T> b ) {
            Node<T> a = b.getRight( );
            b.setRight(a.getLeft( ));
            a.setLeft(b);

            b.setBalance(0);
            a.setBalance(0);

            return a;
        }

        //rotates the tree if needed
        //parameters: c: describes where to rotate
        private Node<T> rotateDoubleLeftRight( Node<T> c ) {
            Node<T> a = c.getLeft();
            Node<T> b = a.getRight( );
            a.setRight(b.getLeft( ));
            b.setLeft(a);
            c.setLeft(b.getRight( ));
            b.setRight(c);

            if( b.getBalance( ) == -1 )
            {
                c.setBalance(1);
            }
            else
            {
                c.setBalance(0);
            }
            if( b.getBalance( ) == 1 )
            {
                a.setBalance(-1);
            }
            else
            {
                a.setBalance(0);
            }
            b.setBalance(0);

            return b;
        }

        //rotates the tree if needed
        //parameters: c: describes where to rotate
        private Node<T> rotateDoubleRightLeft( Node<T> c ) {
            Node<T> a = c.getRight( );
            Node<T> b = a.getLeft( );
            a.setLeft(b.getRight( ));
            b.setRight(a);
            c.setRight(b.getLeft( ));
            b.setLeft(c);

            if( b.getBalance( ) == -1 )
            {
                c.setBalance(1);
            }
            else
            {
                c.setBalance(0);
            }

            if( b.getBalance( ) == 1 )
            {
                a.setBalance(-1);
            }
            else
            {
                a.setBalance(0);
            }
            b.setBalance(0);
            return b;
        }


        // In this method you can insert a new node within a new value.
        // @param value: the new value
        override
        public void insert( T value ) {
            Node<T> newNode = new Node<T>(value);
            if( root == null )
            {
                root = newNode;
            }
            else
            {
                this.insertRekursion(this.root,newNode);
            }
        }

        // Int this method it compares the values with each other. 
        // If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
        // @param node: the node where it will start to compare the value of the new node and the value of the current node.
        // @param value: of the new node
        // @param parent: the parent is a node from the current node
        private Node<T> insertRekursion( Node<T> node,Node<T> newNode ) {
            Node<T> res = null;
            if( newNode.Data.CompareTo(node.Data) > 0 )
            {
                if( node.getRight( ) == null )
                {
                    node.setRight(newNode);
                    node.setBalance(node.getBalance( ) + 1);
                    this.rebalance = ( node.getBalance( ) >= 1 );
                    res = node;
                }
                else
                {
                    node.setRight(insertRekursion(node.getRight( ),newNode));
                    if( rebalance )
                    {
                        if( node.getBalance( ) == -1 )
                        {
                            node.setBalance(0);
                            rebalance = false;
                            res = node;
                        }
                        else if( node.getBalance( ) == 0 )
                        {
                            node.setBalance(1);
                            res = node;
                        }
                        else if( node.getBalance( ) == 1 )
                        {
                            rebalance = false;
                            if( node.getRight( ).getBalance( ) == 1 )
                            {
                                res = rotateRight(node);
                            }
                            else
                            {
                                res = rotateDoubleRightLeft(node);
                            }
                        }
                    }
                    else
                    {
                        res = node;
                    }
                }
            }
            else
            {
                if( node.getLeft( ) == null )
                {
                    node.setLeft(newNode);
                    node.setBalance(node.getBalance() - 1);
                    rebalance = ( node.getBalance( ) <= -1 );
                    res = node;
                }
                else
                {
                    node.setLeft(insertRekursion(node.getLeft(),newNode));
                    if(rebalance) {
                        if (node.getBalance() == 1) {
                            node.setBalance(0);
                            rebalance = false;
                            res = node;
                        } else if (node.getBalance() ==0) {
                            node.setBalance(-1);
                            res = node;
                        }
                        else if (node.getBalance() == -1) {
                            rebalance = false;
                            if (node.getLeft().getBalance() == -1) {
                                res = rotateLeft(node);
                            }else {
                                res = rotateDoubleLeftRight(node);
                            }
                        }
                    } else {
                        res = node;
                    }
                }
            }
            return res;
        }
    
         override
        public bool remove( T value ) {
            bool has = false;
            has = this.removeRecursion(root,value,null,false);
            return has;
        }

        // Int this method it compares the values with each other. 
        // If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
        // @param node: the node where it will start to compare the value of the new node and the value of the current node.
        // @param value: value of the new node
        // @param parent: the parent is a node from the current node
        // @param leftFromParent: the left node from the parent
        // @return if the deletion was successful then it will return true
        private bool removeRecursion( Node<T> currentNode,T value,Node<T> parent,bool isLeft ) {
            bool isDeleted = false;
            if( currentNode == null )
            {
                isDeleted = false;
            }

            if( ( value.CompareTo(currentNode.Data) ) == 0 )
            {

                if( ( currentNode.getLeft( ) == null ) && ( currentNode.getRight( ) == null ) )
                {
                    if( parent == null )
                    {
                        root = null;
                        isDeleted = true;
                    }
                    else
                    {
                        this.insertUnderParent(parent,isLeft,null);
                        isDeleted = true;
                    }
                }
                else if( ( currentNode.getLeft( ) == null ) && ( currentNode.getRight( ) != null ) )
                {
                    if( parent == null )
                    {
                        root = currentNode.getRight( );
                        isDeleted = true;
                    }
                    else
                    {
                        insertUnderParent(parent,isLeft,currentNode.getRight( ));
                        parent.setParent(currentNode);
                        isDeleted = true;
                    }
                }
                else if( ( currentNode.getLeft( ) != null ) && ( currentNode.getRight( ) == null ) )
                {
                    if( parent == null )
                    {
                        root = currentNode.getLeft( );
                        isDeleted = true;
                    }
                    else
                    {
                        insertUnderParent(parent,isLeft,currentNode.getLeft( ));
                        parent.setParent(currentNode);
                        isDeleted = true;
                    }
                }

                else if( currentNode.getLeft( ) != null && currentNode.getRight( ) != null )
                {
                    Node<T> x = getMax(currentNode.getLeft( ));
                    remove(x.Data);
                    if( parent == null )
                    {
                        x.setLeft(root.getLeft( ));
                        x.setRight(root.getRight( ));
                        root = x;
                    }
                    else
                    {
                        x.setLeft(currentNode.getLeft( ));
                        x.setRight(currentNode.getRight( ));
                        insertUnderParent(parent,isLeft,x);
                        parent.setParent(x);
                    }
                }
                removeRecursion(root,value,null,false);
            }

            if( ( value.CompareTo(currentNode.Data) ) < 0 )
            {
                if( currentNode.getLeft( ) != null )
                {
                    isDeleted = removeRecursion(currentNode.getLeft( ),value,currentNode,true);
                }

            }

            if( ( value.CompareTo(currentNode.Data) ) > 0 )
            {
                if( currentNode.getRight( ) != null )
                {
                    isDeleted = removeRecursion(currentNode.getRight( ),value,currentNode,false);
                }
            }
            return isDeleted;
        }

        // In this method you look whether it is right from the parent or left. If left is true then it will set the node left from the parent.
        // @param parent: the parent from the node
        // @param left: a boolean whether it is left or right
        // @param node: the current node
        private void insertUnderParent( Node<T> parent,bool left,Node<T> node ) {
            if( left )
            {
                parent.setLeft(node);
            }
            else
            {
                parent.setRight(node);
            }
        }

        //returns the highest node.
        // parameter: start: the current node.
        private Node<T> getMax( Node<T> start ) {
            if( start != null )
            {
                while( start.getRight( ) != null )
                {
                    start = start.getRight( );
                }
            }
            return start;
        }

    //The method returns a boolean. It returns true if the parameter value is in the tree.
        override
        public bool has( T value ) {
            return this.hasRecursion(this.root,value);
        }

        //This method searches for the parameter value.
        //The data type of currentNode is Node.
        //The data type of value is int.
        //It returns a boolean variable. It returns true when the value is in the tree.

        private bool hasRecursion( Node<T> currentNode,T value ) {
            bool has = false;
            if( currentNode == null )
            {
                has = false;
            }
            else if( currentNode.Data.CompareTo(value) == 0 )
            {
                has = true;
            }
            else if( currentNode.Data.CompareTo(value) < 0 )
            {
                has = this.hasRecursion(currentNode.getLeft( ),value);
            }
            else if( currentNode.Data.CompareTo(value) > 0 )
            {
                has = this.hasRecursion(currentNode.getRight( ),value);
            }
            return has;
        }


        // This method filters the values of the tree and returns the values in an array.
        // parameter: pred: the lambda expression. describes how the values should be filtered.
        public T[ ] filter( Predicate<T> pred ) {
            results.Clear( );
            filterRec(this.root,pred);

            return results.ToArray<T>( );
        }

        //The recursion to filter all the values in the tree.
        // Parameters: node: the current node.
        //             pred: the lambda expression.
        private void filterRec( Node<T> node,Predicate<T> pred ) {
            if( node != null )
            {
                if( pred(node.Data) )
                {
                    results.Add(node.Data);
                }
                filterRec(node.getLeft( ),pred);
                filterRec(node.getRight( ),pred);
            }
        }

    }
}
