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
            Contract.Requires(value >= 0);
            Contract.Invariant(root != null);
            root = new Node(value);
        }

        // @return the root of the binarytree
        public Node getRoot()
        {
            Contract.Ensures(Contract.Result<Node>() != null);
            return this.root;
        }

        // In this method you will get the value from the smallest node
        // @return the value of the root
        public int getSmallestValue()
        {
            Node node = getSmallestNode(root);
            if (root != null)
            {
                Contract.Ensures(Contract.Result<Node>() != null);
                return root.getData();
            }
            else
            {
                Contract.Requires(node == null);
                throw new Exception("Root is null!");
            }
        }

        // Here you will get the smallest node
        // @param node: the node where it begins to search the smallest node
        // @return the smallest node
        public Node getSmallestNode(Node node)
        {
            Contract.Requires(node != null);
            Contract.Invariant(node.getLeft() != null);
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
            Node node = getHighestNode(root);

            if (root != null)
            {
                Contract.Ensures(Contract.Result<Node>() != null);
                return node.getData();
            }
            else
            {
                Contract.Requires(node == null);
                throw new Exception("Root is null!");
            }
        }

        // In this method you wil get the highest node
        // @param node: the node where it begins to search the highest node
        public Node getHighestNode(Node node)
        {
            Contract.Requires(node != null);
            Contract.Invariant(node.getRight() != null);
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
                Contract.Requires(node == null);
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
            Contract.Ensures(Contract.Result<int>() >= 0);
            if (node == null)
            {
                node = new Node(value);
            }
            if (this.root == null)
            {
                this.root = node;
            }
            else
            {
                if ((value.CompareTo(node.getData())) == 0)
                {
                    if (node.getRight() == null)
                    {
                        Contract.Requires(node.getRight() != null);
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

                if ((value.CompareTo(node.getData())) < 0)
                {
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
        public bool remove(int value)
        {
            Contract.Requires(value >= 0);
            bool recursion = this.removeRecursion(root, value, null, false); ;

            return recursion;
        }

        // Int this method it compares the values with each other. 
        // If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
        // @param node: the node where it will start to compare the value of the new node and the value of the current node.
        // @param value: value of the new node
        // @param parent: the parent is a node from the current node
        // @param leftFromParent: the left node from the parent
        // @return if the deletion was successful then it will return true
        private bool removeRecursion(Node node, int value, Node parent, bool leftFromParent)
        {
            bool removeSuccessful = false;

            if (node == null)
            {
                Contract.Requires(node == null);
                removeSuccessful = false;
            }
            Contract.Requires(node.getLeft() == null);
            Contract.Requires(node.getRight() == null);

            if ((value.CompareTo(node.getData())) == 0)
            {
                if ((node.getLeft() == null) && (node.getRight() == null))
                {
                    if (parent == null)
                    {
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
                removeSuccessful = true;
            }

            if ((value.CompareTo(node.getData())) < 0)
            {
                Contract.Requires(node.getLeft() == null);
                if (node.getLeft() == null)
                {
                    Contract.Ensures(Contract.Result<bool>() == false);
                    return false;
                }
                Contract.Ensures(Contract.Result<bool>() == true);
                return removeRecursion(node.getLeft(), value, node, true);
            }

            if ((value.CompareTo(node.getData())) > 0)
            {
                Contract.Requires(node.getRight() == null);
                if (node.getRight() == null)
                {
                    Contract.Ensures(Contract.Result<bool>() == false);
                    return false;
                }
                else
                {
                    Contract.Ensures(Contract.Result<bool>() == true);
                    return removeRecursion(node.getRight(), value, node, false);
                }
            }
            return removeSuccessful;
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
            if (node == null)
            {
                Contract.Ensures(Contract.Result<Node>() == null);
                return null;
            }
            if (value.CompareTo(node.getData()) == 0)
            {
                return node;
            }
            if (value.CompareTo(node.getData()) < 0)
            {
                if (node.getLeft() != null)
                {
                    return searchNodeRekursion(node.getLeft(), value);
                }
                else
                {
                    return null;
                }
            }
            if (value.CompareTo(node.getData()) > 0)
            {
                if (node.getRight() != null)
                {
                    return searchNodeRekursion(node.getRight(), value);
                }
                else
                {
                    return null;
                }
            }
            return null;
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
    //------------------------------------------------Exercise 2----------------------------------------------
    public abstract class Problem<Solution>
    {
        // A abstract get-method
        // @return from the interface Solution
        public abstract Solution getSolution();
    }
    public abstract class DivisibleProblem<Solution> : Problem<Solution>
    {
        protected bool directlySolvable = false;
        protected BinaryTree tree = null;

        // @param node: the current node, from where you look
        public abstract void checkSolvability(Node node);

        // @param node: the current node, from where you search the highest value or form where you sum up the values
        protected abstract void getHighestAndSum(Node node);

        // @param value: the value for the new root
        public void setBinaryTree(int value)
        {
            Contract.Requires(value >= 0);
            tree = new BinaryTree(value);
        }

        // @return the binarytree
        public BinaryTree getBinaryTree()
        {
            Contract.Ensures(Contract.Result<BinaryTree>() != null);
            return tree;
        }

        // In this method you check first if you can solve the problem directly. If not, then it will divide the problem to reach the solution.
        public virtual void computeSolution()
        {
            Contract.Requires(tree.getRoot() != null);
            checkSolvability(tree.getRoot());
            if (!(directlySolvable))
            {
                getHighestAndSum(tree.getRoot());
            }
        }
    }
    public class SumProblem : DivisibleProblem<SumSolution>
    {
        protected SumSolution solution;

        // Constructor of the class "SumProblem"
        public SumProblem()
        {
            Contract.Requires()
            solution = new SumSolution();
        }

        // This method has been overridden. Here we can solve the problem directly.
        // @param node: at this node, you check the right node and the left node. If it is "null", then you can solve it directly.
        public override void checkSolvability(Node node)
        {
            int directSum = 0;

            if (node.getRight() == null && node.getLeft() == null)
            {
                directlySolvable = true;
                directSum = node.getData();
                solution.setSum(node.getData());
            }
        }

        // A overridden method.
        // @return the solution of the sum problem
        public override SumSolution getSolution()
        {
            return solution;
        }

        // In this mehtod you sum up the values of the binarytree.
        // @param node: at this node, you sum up the other nodes
        // @return the solution of the problem sum
        protected int getSumRecursion(Node node)
        {
            int sum = 0;
            if (node != null)
            {
                sum += node.getData() + getSumRecursion(node.getLeft()) + getSumRecursion(node.getRight());
            }
            return sum;
        }

        // Here you set the solution of the problem.
        // @param node: at this node, you sum up the other nodes
        protected override void getHighestAndSum(Node node)
        {
            solution.setSum(this.getSumRecursion(node));
        }
    }

    public class MaxProblem : DivisibleProblem<MaxSolution>
    {
        protected MaxSolution solution;

        // Constructor of the class "MaxProblem"
        public MaxProblem()
        {
            solution = new MaxSolution();
        }

        // This method has been overridden. Here we can solve the problem directly.
        // @param node: at this node, you check the right node and the left node. If it is "null", then you can solve it directly.
        public override void checkSolvability(Node node)
        {
            int directHighest = 0;

            if (node.getRight() == null && node.getLeft() == null)
            {
                directlySolvable = true;
                directHighest = node.getData();
                solution.setMaximum(directHighest);
            }
        }

        // Here you set the solution of the problem.
        // @param node: at this node, you search the highest node
        protected override void getHighestAndSum(Node node)
        {
            while (node.getRight() != null)
            {
                node = node.getRight();
            }
            solution.setMaximum(node.getData());
        }

        // A overridden method.
        // @return the solution of the highest problem
        public override MaxSolution getSolution()
        {
            return solution;
        }

    }
    public class MaxSolution
    {
        protected int max;

        // @return the highest value in the binarytree
        public int getMaximum()
        {
            return max;
        }

        // A overridden method.
        // @return the solution of the sum problem
        protected internal void setMaximum(int max)
        {
            this.max = max;
        }

    }

    public class SumSolution
    {
        protected int sum;

        // @return the solution of the sum
        public int getSum()
        {
            return sum;
        }

        // @param set the solution of the sum
        protected internal void setSum(int sum)
        {
            this.sum = sum;
        }
    }
    public class ProblemSolver
    {
        static void Main(string[] args)
        {
            MaxProblem max = new MaxProblem();
            max.setBinaryTree(10);
            max.getBinaryTree().insert(12);
            max.computeSolution();
            Console.WriteLine("MaxSolution:" + max.getSolution().getMaximum());

            SumProblem sum = new SumProblem();
            sum.setBinaryTree(4);
            sum.getBinaryTree().insert(2);
            sum.getBinaryTree().insert(3);
            sum.getBinaryTree().insert(6);

            sum.computeSolution();
            Console.WriteLine("SumSolution:" + sum.getSolution().getSum());

            BinaryTree b = new BinaryTree(8);
            BinaryTree b2 = new BinaryTree(2);
            for (int i = 0; i <= 15; i++)
            {
                b.insert(i);
            }
            Contract.Assert(b.getHighestValue() == 15);
            Contract.Assert(b.getSmallestValue() == 0);
            Contract.Assert(Equals(b.toString(), b2.toString()));

            Console.WriteLine(b.preOrder());
            b.remove(10);
            Console.WriteLine(b.preOrder());

            Console.ReadKey();
        }
    }
}