﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBaum
{
    class BinaryTree<T> : Tree<T>
        where T : IComparable
    {
  private Node<T> head;
        private Comparison<IComparable> comparer = CompareElements;
        private int size;

        /// <summary>
        /// Creates a new instance of a Binary Tree
        /// </summary>
        public BinaryTree()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        ///  puts out the objects of the tree in order
        ///  and goes to the in order recursion
        /// </summary>
        public void inOrderOutput()
        {
            if (this.Root != null)
            {
                Console.Write("In-order-output: ");
                inOrderRecursion(this.Root);
            }
            else
            {
                Console.WriteLine("The tree is empty.");
            }
        }


        /// <summary>
        /// puts out the objects of the tree in order
        /// </summary>
        /// <param name="node"></param>
        private void inOrderRecursion(Node<T> node)
        {
            if (node != null)
            {
                inOrderRecursion(node.LeftChild);
                Console.Write(" " + node.Value);
                inOrderRecursion(node.RightChild);
            }
        }

        /// <summary>
        /// Gets or sets the root of the tree (the top-most node)
        /// </summary>
        public Node<T> Root
        {
            get {
                return head; 
            }
            set {
                head = value; 
            }
        }

        /// <summary>
        /// Gets whether the tree is read-only
        /// </summary>
        public bool IsReadOnly
        {
            get {
                return false;
            }
        }

        /// <summary>
        /// Gets the number of elements stored in the tree
        /// </summary>
        public virtual int Count
        {
            get { return size; }
        }


        /// <summary>
        /// the method Add, adds a new element to the tree
        /// the input parameter is T value
        /// it goes to the method Add(node)
        /// </summary>
        /// <param name="value"></param>
       override
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            this.Add(node);
        }

       /// <summary>
       /// Adds a node to the tree
       /// if head is null first element will be added
       /// if the parent of the node is null then the parent is the head
       /// </summary>
       /// <param name="node"></param>
        public void Add(Node<T> node)
        {
            if (this.head == null) //first element being added
            {
                this.head = node; //set node as root of the tree
                node.Tree = this;
                size++;
            }
            else
            {
                if (node.Parent == null)
                    node.Parent = head; //start at head

                //Node is inserted on the left side if it is smaller or equal to the parent
                bool insertLeftSide = comparer((IComparable)node.Value, (IComparable)node.Parent.Value) <= 0;

                if (insertLeftSide) //insert on the left
                {
                    if (node.Parent.LeftChild == null)
                    {
                        node.Parent.LeftChild = node; //insert in left
                        size++;
                        node.Tree = this; //assign node to this binary tree
                    }
                    else
                    {
                        node.Parent = node.Parent.LeftChild; //scan down to left child
                        this.Add(node); //recursive call
                    }
                }
                else //insert on the right
                {
                    if (node.Parent.RightChild == null)
                    {
                        node.Parent.RightChild = node; //insert in right
                        size++;
                        node.Tree = this; //assign node to this binary tree
                    }
                    else
                    {
                        node.Parent = node.Parent.RightChild;
                        this.Add(node);
                    }
                }
            }
        }

        /// <summary>
        /// the method Find returns the first node in the tree with the parameter value.
        /// the input parameter is value
        /// if the value  equales the Node then the value is found this will be returned
        /// </summary>
        /// <param name="value"></param>
        public Node<T> Find(T value)
        {
            Node<T> node = this.head; //start at head
            while (node != null)
            {
                if (node.Value.Equals(value)) //parameter value found
                    return node;
                else
                {
                    //Search left if the value is smaller than the current node
                    bool searchLeft = comparer((IComparable)value, (IComparable)node.Value) < 0;

                    if (searchLeft)
                        node = node.LeftChild; //search left
                    else
                        node = node.RightChild; //search right
                }
            }

            return null; //not found
        }

        /// <summary>
        /// Returns whether a value is stored in the tree
        /// goes to the method Find(value)
        /// this method gives a bool back
        /// </summary>
        /// <param name="value"></param>
        override
        public bool Contains(T value)
        {
            return (this.Find(value) != null);
        }

        /// <summary>
        /// Removes a value from the tree and returns whether the remove was successful.
        /// looks if its equals with the found value
        /// then it goes to the methodRemove(removeNode)
        /// </summary>
        /// <param name="value"></param>
        override
        public bool Remove(T value)
        {
            Node<T> removeNode = Find(value);

            return this.Remove(removeNode);
        }

        /// this method removes a node from the tree and returns the removal was successful.
        /// first it looks if the value exists in the tree -> return false
        /// it goes through the tree and serches the value to delete it
        /// </summary>>
        ///  <param name="removeNode"></param>
        public bool Remove(Node<T> removeNode)
        {
            if (removeNode == null || removeNode.Tree != this)
                return false; //value doesn't exist or not of this tree

            //Note whether the node to be removed is the root of the tree
            bool wasHead = (removeNode == head);

            if (this.Count == 1)
            {
                this.head = null; //only element was the root
                removeNode.Tree = null;

                size--; //decrease total element count
            }
            else if (removeNode.IsLeaf) //Case 1: No Children
            {
                //Remove node from its parent
                if (removeNode.IsLeftChild)
                    removeNode.Parent.LeftChild = null;
                else
                    removeNode.Parent.RightChild = null;

                removeNode.Tree = null;
                removeNode.Parent = null;

                size--; //decrease total element count
            }
            else if (removeNode.ChildCount == 1) //Case 2: One Child
            {
                if (removeNode.HasLeftChild)
                {
                    //Put left child node in place of the node to be removed
                    removeNode.LeftChild.Parent = removeNode.Parent; //update parent

                    if (wasHead)
                        this.Root = removeNode.LeftChild; //update root reference if needed

                    if (removeNode.IsLeftChild) //update the parent's child reference
                        removeNode.Parent.LeftChild = removeNode.LeftChild;
                    else
                        removeNode.Parent.RightChild = removeNode.LeftChild;
                }
                else //Has right child
                {
                    //Put left node in place of the node to be removed
                    removeNode.RightChild.Parent = removeNode.Parent; //update parent

                    if (wasHead)
                        this.Root = removeNode.RightChild; //update root reference if needed

                    if (removeNode.IsLeftChild) //update the parent's child reference
                        removeNode.Parent.LeftChild = removeNode.RightChild;
                    else
                        removeNode.Parent.RightChild = removeNode.RightChild;
                }

                removeNode.Tree = null;
                removeNode.Parent = null;
                removeNode.LeftChild = null;
                removeNode.RightChild = null;

                size--; //decrease total element count
            }
            else //Case 3: Two Children
            {
                //Find inorder predecessor (right-most node in left subtree)
                Node<T> successorNode = removeNode.LeftChild;
                while (successorNode.RightChild != null)
                {
                    successorNode = successorNode.RightChild;
                }

                removeNode.Value = successorNode.Value; //replace value

                this.Remove(successorNode); //recursively remove the inorder predecessor
            }

            
            return true;
        }

        /// <summary>
        ///this method returns the height of the entire tree
        /// </summary>
        public int GetHeight()
        {
            return this.GetHeight(this.Root);
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter value
        /// </summary>
        /// <param name="value"></param>
        public int GetHeight(T value)
        {
            //Find the value's node in tree
            Node<T> valueNode = this.Find(value);
            if (value != null)
                return this.GetHeight(valueNode);
            else
                return 0;
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter node
        /// </summary>
        /// <param name="startNode"></param>
        public int GetHeight(Node<T> startNode)
        {
            if (startNode == null)
                return 0;
            else
                return 1 + Math.Max(GetHeight(startNode.LeftChild), GetHeight(startNode.RightChild));
        }

        /// <summary>
        /// Returns the depth of a subtree rooted at the parameter value
        /// goes to the method getDepth(startNode)
        /// </summary>
        /// <param name="value"></param>
        public int GetDepth(T value)
        {
            Node<T> node = this.Find(value);
            return this.GetDepth(node);
        }

        /// <summary>
        /// Returns the depth of a subtree rooted at the parameter node
        /// </summary>
        /// <param name="startNode"></param>
        public int GetDepth(Node<T> startNode)
        {
            int depth = 0;

            if (startNode == null)
                return depth;

            Node<T> parentNode = startNode.Parent; //start a node above
            while (parentNode != null)
            {
                depth++;
                parentNode = parentNode.Parent; //scan up towards the root
            }

            return depth;
        }

        /// <summary>
        /// Compares two elements to determine their positions within the tree.
        /// </summary>
        public static int CompareElements(IComparable x, IComparable y)
        {
            return x.CompareTo(y);
        }
    }
}
