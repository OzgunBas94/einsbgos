using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    class Binarytree<T>: Tree<T> , TreeInterface<T>
       where T: IComparable
    {
        private List<T> results = new List<T>( );

        private Node<T> root;

        public Binarytree( ) {
            
        }

        // Constructor of the class "BinaryTree"
        // @param value: the value of the root
        public Binarytree( T value ) {
            if( value != null )
            {
                root = new Node<T>(value);
            }

        }

        // @return the root of the binarytree
        public Node<T> getRoot( ) {
            return this.root;
        }


        // In this method you can insert a new node within a new value.
        // @param value: the new value
        override
        public void insert( T value ) {
            if( root == null )
            {
                root = new Node<T>(value);
            }
            else
            {
                this.insertRekursion(this.root,value);
            }
        }

        // Int this method it compares the values with each other. 
        // If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
        // @param node: the node where it will start to compare the value of the new node and the value of the current node.
        // @param value: of the new node
        // @param parent: the parent is a node from the current node
        private void insertRekursion( Node<T> node,T value ) {
          
            if( this.root == null )
            {
                this.root = node;
            }
            else
            {
                if( ( value.CompareTo(node.Data) ) < 0 )
                {
                    
                    if( node.getLeft( ) != null )
                    {
                        this.insertRekursion(node.getLeft( ),value);

                    }
                    else
                    {
                        Node<T> newNode = new Node<T>(value);
                        node.setLeft(newNode);
                        newNode.setParent(node);
                    }
                }
                else
                {
                    if( node.getRight( ) != null )
                    {
                        this.insertRekursion(node.getRight( ),value);
                    }
                    else
                    {
                        
                        Node<T> newNode = new Node<T>(value);
                        node.setRight(newNode);
                        newNode.setParent(node);
                    }
                }
            }
        }

        //The method returns a boolean. It returns true if the parameter value is in the tree.
        override
        public bool has( T value ) {
            bool has = false;
            return this.hasRecursion(this.root,value,has);
        }

        //This method searches for the parameter value.
        //The data type of currentNode is Node.
        //The data type of value is int.
        //It returns a boolean variable. It returns true when the value is in the tree.

        private bool hasRecursion( Node<T> currentNode,T value,bool has ) {
            if( currentNode == null )
            {
                has = false;
            }
            else if( value.CompareTo(currentNode.Data) == 0 )
            {
                has = true;
            }
            else if( value.CompareTo(currentNode.Data) < 0 )
            {
                has = this.hasRecursion(currentNode.getLeft( ),value,has);
            }
            else if( value.CompareTo(currentNode.Data) > 0 )
            {
                has = this.hasRecursion(currentNode.getRight( ),value,has);
            }

            
            return has;
        }

        // In this method you can remove the desired node.
        // @param value: the value of the node you want to delete
        // @return to get in the method
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

        // This shows the output from the binarytree
        // @return to get in the other method and return the values
        public String preOrder( ) {
            return preOrderRecursion(root);
        }

        // it outputs first of all the root, then the left side of the tree and in the end the right side of the tree
        // @param root: where it begins to look
        // @return the values in String
        private String preOrderRecursion( Node<T> root ) {
            String s = " ";
            if( root == null )
            {
                return "The BinaryTree is empty! There is nothing to order.";
            }
            else
            {
                s += root.Data;
            }
            if( root.getLeft( ) != null )
            {
                s += preOrderRecursion(root.getLeft( ));
            }
            if( root.getRight( ) != null )
            {
                s += preOrderRecursion(root.getRight( ));
            }
            return s;
        }

        // This method filters the values of the tree and returns the values in an array.
        // parameter: pred: the lambda expression. describes how the values should be filtered.

        public T[] filter( Predicate<T> pred ) {
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

        // @return it outputs the data of the root
        public String toString( ) {
            return root.toString( );
        }
    }
}
