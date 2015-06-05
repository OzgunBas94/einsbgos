using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBaum
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree<string> tree = new BinaryTree<string>();
            AVLTree<int> avl = new AVLTree<int>();

            tree.Add("martin");
            tree.Add("özgün");
            tree.Add("los");
            tree.Add("ende");
            tree.Add("anfang");

            tree.inOrderOutput();
            Console.WriteLine();
            Console.WriteLine(tree.Contains("özgün"));
            tree.Remove("özgün");
            tree.inOrderOutput();
            Console.WriteLine();
            Console.WriteLine(tree.Contains("özgün"));

     
            Console.WriteLine();
            Console.WriteLine();

            avl.Add(14);
            avl.Add(4);
            avl.Add(62);
            avl.Add(2);
            avl.Add(89);
            avl.Add(100);
        //    avl.Add(111);

            avl.inOrderOutput();
            Console.WriteLine();
            Console.WriteLine(avl.IsBanlance(avl.Root));
            Console.WriteLine();
       
          /*  Console.WriteLine(avl.ReBanlance(avl.Root));

            avl.inOrderOutput();

            Console.WriteLine(avl.IsBanlance(avl.Root));
            */
            Console.ReadLine();


        }
    }
}
