﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Ubung1_Binarbaum_CSharp
{
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
}
