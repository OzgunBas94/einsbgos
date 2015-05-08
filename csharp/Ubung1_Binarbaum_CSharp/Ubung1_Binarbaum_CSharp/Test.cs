using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Ubung1_Binarbaum_CSharp
{
    class Test
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

            BinaryTree binarytree = new BinaryTree(8);
            BinaryTree binarytreeTwo = new BinaryTree(8);
            for (int i = 0; i <= 5; i++)
            {
                binarytree.insert(i);
                binarytreeTwo.insert(i);
            }
            binarytree.insert(13);
            binarytreeTwo.insert(13);

            Contract.Assert(binarytree.getHighestValue() == 13);
            Contract.Assert(Equals(binarytree.getRoot().toString(), binarytreeTwo.getRoot().toString()));

            Console.WriteLine("Tree: " + binarytree.preOrder());
            Console.WriteLine("Second tree: " + binarytreeTwo.preOrder());

            try
            {
                binarytree.remove(3);
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            Console.WriteLine("Tree: " + binarytree.preOrder());

            try
            {
                Console.WriteLine("Search node: " + binarytree.searchNode(2).getData());
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }

            Console.ReadKey();
        }
    }
}
