using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Ubung1_Binarbaum_CSharp
{
    public class Node
    {
        private int value;
        private Node left = null;
        private Node right = null;
        private Node parent = null;

        // Constructor of the class "Node"
        // @param value: the value of the new node
        public Node(int value)
        {
            Contract.Ensures(value >= 0);
            this.setData(value);
        }

        // @param value: to set the value of a node
        private void setData(int value)
        {
            Contract.Requires(value >= 0);
            this.value = value;
        }

        // @param node: to set the node left of another node/a parent
        public void setLeft(Node node)
        {
            Contract.Requires(left != null);
            this.left = node;
        }

        // @param node: to set the node right of another node/a parent
        public void setRight(Node node)
        {
            Contract.Requires(right != null);
            this.right = node;
        }

        // @param node: to set the parent
        public void setParent(Node node)
        {
            Contract.Requires(parent != null);
            this.parent = node;
        }

        // @return the parent of a node
        public Node getParent()
        {
            Contract.Ensures(Contract.Result<Node>() != null);
            return parent;
        }

        // @return the value of a node
        public int getData()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return value;
        }

        // @return the left node from the parent node
        public Node getLeft()
        {
            Contract.Ensures(Contract.Result<Node>() != left);
            return left;
        }

        // @return the right node from the parent node
        public Node getRight()
        {
            Contract.Ensures(Contract.Result<Node>() != right);
            return right;
        }

        public String toString()
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return this.ToString();
        }
    }
}
