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
            //MaxProblem max = new MaxProblem();
            //max.setBinaryTree(10);
            //max.getBinaryTree().insert(12);
            //max.computeSolution();
            //Console.WriteLine("MaxSolution:" + max.getSolution().getMaximum());

            //SumProblem sum = new SumProblem();
            //sum.setBinaryTree(4);
            //sum.getBinaryTree().insert(2);
            //sum.getBinaryTree().insert(3);
            //sum.getBinaryTree().insert(6);

            //sum.computeSolution();
            //Console.WriteLine("SumSolution:" + sum.getSolution().getSum());

            BinaryTree b = new BinaryTree(8);
            BinaryTree b2 = new BinaryTree(2);
            for (int i = 0; i <= 5; i++)
            {
                b.insert(i);
            }
            b.insert(13);
            b.insert(10);
            b.insert(7);

        //    Contract.Assert(b.getHighestValue() == 15);
        //    Contract.Assert(b.getSmallestValue() == 0);
        //    Contract.Assert(Equals(b.toString(), b2.toString()));

            Console.WriteLine("Tree: " +b.preOrder());
            b.remove(5);
            Console.WriteLine("Tree: "+b.preOrder());

            Console.ReadKey();
        }
    }
}
