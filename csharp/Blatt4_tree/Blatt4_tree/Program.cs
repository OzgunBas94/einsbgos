using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    class Program
    {
        static void Main( string[ ] args ) {
           
            Console.Out.WriteLine("--------------------string test-------------------------");
            Console.Out.WriteLine("Woerter mit der Laenge >= 3:");
            AVL<String> avltree = new AVL<String>();
            TestStringTree testString = new TestStringTree(avltree);
            testString.insertRandom(4,38,120);
            string[ ] s = avltree.filter(x => x.Count( ) >= 3);
            foreach( string t in s )
            {
                Console.Out.WriteLine(t);
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine("Woerter, die ein s enthalten:");
            s = avltree.filter(x => x.Contains("s"));
            foreach( string t in s )
            {
                Console.Out.WriteLine(t);
            }
            Console.ReadKey( );
            Console.Out.WriteLine();
            Console.Out.WriteLine("--------------------float test-------------------------");
            Console.Out.WriteLine("alle negativen Zahlen:");
            Binarytree<float> btree = new Binarytree<float>( );
            TestFloatTree testFloat = new TestFloatTree(btree);
            testFloat.insertRandom(-3957,2020,157);
            float[] a = btree.filter(x => x < 0);
            foreach( float b in a )
            {
                Console.Out.WriteLine(b);
            }
            Console.Out.WriteLine();
            Console.Out.WriteLine("alle Zahlen <= 5:");
            //testFloat.insertRandom(-1580,98557,40);
            a = btree.filter(x => x <= 5);
            foreach( float b in a )
            {
                Console.Out.WriteLine(b);
            }
            Console.Out.WriteLine( );

            Console.Out.WriteLine("alle geraden Zahlen");


            testFloat.insertRandom(-2580,2580,25585);
            a = btree.filter(x => (x % 2) ==0);
            
            foreach( float b in a )
            {
                Console.Out.WriteLine(b);
            }
            Console.ReadKey( );
        }
    }
}
