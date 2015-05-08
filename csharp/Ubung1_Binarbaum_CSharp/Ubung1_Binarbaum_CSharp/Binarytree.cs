using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Ubung1_Binarbaum_CSharp
{
    public class BinaryTree
    {
        private Node root = null;

        // Constructor of the class "BinaryTree"
        // @param value: the value of the root
        public BinaryTree(int value)
        {
            Contract.Invariant(root != null);
            Contract.Requires(value >= 0);
            root = new Node(value);
        }

        // @return the root of the binarytree
        public Node getRoot()
        {
            Contract.Invariant(this.root != null);
            return this.root;
        }

        // In this method you will get the value from the smallest node
        // @return the value of the root
        public int getSmallestValue()
        {
            Contract.Ensures(Contract.Result<Node>() != null);
            Node node = getSmallestNode(root);

            Contract.Requires(node == null);
            if (root != null)
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return root.getData();
            }
            else
            {
                throw new Exception("Root is null!");
            }
        }

        // Here you will get the smallest node
        // @param node: the node where it begins to search the smallest node
        // @return the smallest node
        public Node getSmallestNode(Node node)
        {
            Contract.Requires(node != null);
            Contract.Requires(node.getLeft() != null);
            if (node != null)
            {
                while (node.getLeft() != null)
                {
                    node = node.getLeft();
                }
                return node;
            }
            else
            {
                throw new Exception("Root is null!");
            }
        }

        // In this method you will get the highest value
        // @return the data of the highest node
        public int getHighestValue()
        {
            Contract.Ensures(Contract.Result<Node>() != null);
            Node node = getHighestNode(root);

            Contract.Requires(node == null);
            if (root != null)
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return node.getData();
            }
            else
            {
                throw new Exception("Root is null!");
            }
        }

        // In this method you wil get the highest node
        // @param node: the node where it begins to search the highest node
        public Node getHighestNode(Node node)
        {
            Contract.Requires(node != null);
            Contract.Requires(node.getRight() != null);
            if (node != null)
            {
                while (node.getRight() != null)
                {
                    node = node.getRight();
                }
                return node;
            }
            else
            {
                throw new Exception("Root is missing!");
            }
        }

        // In this method you can insert a new node within a new value.
        // @param value: the new value
        public void insert(int value)
        {
            Contract.Requires(value >= 0);
            if (root == null)
            {
                Contract.Invariant(root != null);
                root = new Node(value);
            }
            else
            {
                this.insertRekursion(this.root, value, null);
            }
        }

        // Int this method it compares the values with each other. 
        // If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
        // @param node: the node where it will start to compare the value of the new node and the value of the current node.
        // @param value: of the new node
        // @param parent: the parent is a node from the current node
        private void insertRekursion(Node node, int value, Node parent)
        {
            Contract.Requires(node != null);
            Contract.Requires(value >= 0);
            Contract.Ensures(Contract.Result<int>() >= 0);
            if (node == null)
            {
                Contract.Ensures(Contract.Result<Node>() != null);
                node = new Node(value);
            }
            if (this.root == null)
            {
                Contract.Ensures(Contract.Result<Node>() != null);
                this.root = node;
            }
            else
            {
                if ((value.CompareTo(node.getData())) == 0)
                {
                    Contract.Requires(node.getRight() == null);
                    if (node.getRight() == null)
                    {
                        Contract.Ensures(Contract.Result<Node>() != null);
                        Node newNode = new Node(value);
                        node.setRight(newNode);
                        newNode.setParent(node);
                    }
                    else
                    {
                        this.insertRekursion(node.getRight(), value, parent);
                    }
                }
                Contract.Requires(node.getData() < 0);
                if ((value.CompareTo(node.getData())) < 0)
                {
                    Contract.Requires(node.getLeft() != null);
                    if (node.getLeft() != null)
                    {

                        this.insertRekursion(node.getLeft(), value, node);
                    }
                    else
                    {
                        Contract.Requires(node.getLeft() == null);
                        Contract.Ensures(Contract.Result<Node>() != null);
                        Node newNode = new Node(value);
                        node.setLeft(newNode);
                        newNode.setParent(node);
                    }
                }

                if ((value.CompareTo(node.getData())) > 0)
                {
                    Contract.Requires(node.getRight() != null);
                    if (node.getRight() != null)
                    {

                        this.insertRekursion(node.getRight(), value, node);
                    }
                    else
                    {
                        Contract.Requires(node.getRight() == null);
                        Contract.Ensures(Contract.Result<Node>() != null);
                        Node newNode = new Node(value);
                        node.setRight(new Node(value));
                        newNode.setParent(node);
                    }
                }
            }
        }

        // In this method you can remove the desired node.
        // @param value: the value of the node you want to delete
        // @return to get in the method
        public void remove(int value)
        {
            Contract.Requires(value >= 0);
            this.removeRecursion(root, value, null, false);
        }

        // Int this method it compares the values with each other. 
        // If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
        // @param node: the node where it will start to compare the value of the new node and the value of the current node.
        // @param value: value of the new node
        // @param parent: the parent is a node from the current node
        // @param leftFromParent: the left node from the parent
        // @return if the deletion was successful then it will return true
        private void removeRecursion(Node node, int value, Node parent, bool leftFromParent)
        {
            Contract.Requires(node == null);
            Contract.Requires(value >= 0);
            if (node == null)
            {
                throw new Exception("Node shouldn't be null!");
            }
            Contract.Requires(node.getLeft() == null);
            Contract.Requires(node.getRight() == null);

            if ((value.CompareTo(node.getData())) == 0)
            {
                Contract.Requires(node.getLeft() == null);
                Contract.Requires(node.getRight() == null);

                if ((node.getLeft() == null) && (node.getRight() == null))
                {
                    if (parent == null)
                    {
                        Contract.Ensures(Contract.Result<Node>() == null);
                        root = null;
                    }
                    else
                    {
                        Contract.Ensures(Contract.Result<Node>() == null);
                        insertUnderParent(parent, leftFromParent, null);
                    }
                }
                if ((node.getLeft() == null) && (node.getRight() != null))
                {
                    if (root == null)
                    {
                        root = node.getRight();
                    }
                    else
                    {
                        insertUnderParent(parent, leftFromParent, node.getRight());
                        parent.setParent(node);
                    }
                }
                if ((node.getLeft() != null) && (node.getRight() == null))
                {
                    if (root == null)
                    {
                        root = node.getLeft();
                    }
                    else
                    {
                        insertUnderParent(parent, leftFromParent, node.getLeft());
                        parent.setParent(node);
                    }
                }

                if (node.getLeft() != null && node.getRight() != null)
                {
                    Node newNode = getSmallestNode(node.getRight());
                    remove(newNode.getData());
                    if (parent == null)
                    {
                        newNode.setLeft(root.getLeft());
                        newNode.setRight(root.getRight());
                        root = newNode;
                    }
                    else
                    {
                        newNode.setLeft(node.getLeft());
                        newNode.setRight(node.getRight());
                        insertUnderParent(parent, leftFromParent, newNode);
                        parent.setParent(newNode);
                    }
                }
                removeRecursion(root, value, null, false);
            }

            if ((value.CompareTo(node.getData())) < 0)
            {
                Contract.Requires(node.getLeft() == null);
                if (node.getLeft() == null)
                {
                    Contract.Ensures(Contract.Result<bool>() == false);
                    throw new Exception("Node left shouldn't be null!");
                }
                Contract.Ensures(Contract.Result<bool>() == true);
                removeRecursion(node.getLeft(), value, node, true);
            }

            if ((value.CompareTo(node.getData())) > 0)
            {
                Contract.Requires(node.getRight() == null);
                if (node.getRight() == null)
                {
                    Contract.Ensures(Contract.Result<bool>() == false);
                    throw new Exception("Node right shouldn't be null!");
                }
                else
                {
                    Contract.Ensures(Contract.Result<bool>() == false);
                    removeRecursion(node.getRight(), value, node, false);
                }
            }
        }

        // In this method you look whether it is right from the parent or left. If left is true then it will set the node left from the parent.
        // @param parent: the parent from the node
        // @param left: a boolean whether it is left or right
        // @param node: the current node
        private void insertUnderParent(Node parent, bool left, Node node)
        {
            if (left)
            {
                Contract.Ensures(Contract.Result<bool>() == true);
                parent.setLeft(node);
            }
            else
            {
                Contract.Ensures(Contract.Result<bool>() == false);
                parent.setRight(node);
            }
        }

        // Here you can search the desired node 
        // @param value: the value it has to be search
        public Node searchNode(int value)
        {
            Contract.Requires(value >= 0);
            return this.searchNodeRekursion(root, value);
        }

        // Int this method it compares the values with each other. 
        // If the value, you search is higher than the current value, so it will look on the right of the binarytree 
        // as long as it finds the desired value.
        // @param node: the current node, from where you search
        // @param value: the value you search
        // @return the node you find
        private Node searchNodeRekursion(Node node, int value)
        {
            Contract.Requires(value >= 0);
            Contract.Requires(node != null);
            Node returnNode = null;

            Contract.Requires(value >= 0);
            if (node == null)
            {
                Contract.Ensures(Contract.Result<Node>() == null);
                throw new Exception("Node shouldn't be null!");
            }
            if (value.CompareTo(node.getData()) == 0)
            {
                returnNode = node;
            }
            if (value.CompareTo(node.getData()) < 0)
            {
                if (node.getLeft() != null)
                {
                    returnNode = searchNodeRekursion(node.getLeft(), value);
                }
                else
                {
                    throw new Exception("Null");
                }
            }
            if (value.CompareTo(node.getData()) > 0)
            {
                if (node.getRight() != null)
                {
                    returnNode = searchNodeRekursion(node.getRight(), value);
                }
                else
                {
                    throw new Exception("null");
                }
            }
            return returnNode;
        }

        // This shows the output from the binarytree
        // @return to get in the other method and return the values
        public String preOrder()
        {
            Contract.Invariant(preOrderRecursion(root) != null);
            return preOrderRecursion(root);
        }

        // it outputs first of all the root, then the left side of the tree and in the end the right side of the tree
        // @param root: where it begins to look
        // @return the values in String
        private String preOrderRecursion(Node root)
        {
            String s = " ";
            Contract.Requires(root == null);
            if (root == null)
            {
                Contract.Ensures(Contract.Result<String>() == "<The BinaryTree is empty! There is nothing to order.>");
                return "The BinaryTree is empty! There is nothing to order.";
            }
            else
            {
                s += root.getData();
            }
            Contract.Requires(root.getLeft() != null);
            if (root.getLeft() != null)
            {
                s += preOrderRecursion(root.getLeft());
            }
            Contract.Requires(root.getRight() != null);
            if (root.getRight() != null)
            {
                s += preOrderRecursion(root.getRight());
            }
            return s;
        }

        // @return it outputs the data of the root
        public String toString()
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return root.toString();
        }
    }
}
