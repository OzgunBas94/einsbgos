using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatt4_tree
{
    class ReturnRandom
    {

        private Random r = new Random();

        public ReturnRandom( ) {

        }

        // This method returns a random float.
        //Parameters: min: the min value of the float
        //            max: the max value of the float
        public float randomFloat(int min, int max)
        {
            float rf = r.Next(min, max);
            rf = rf + (float)r.NextDouble( );
            return rf;
        }

        // This method returns a random string.
        //Parameters: min: the min length of the string
        //            max: the max length of the string
        public string randomString(int min, int max)
        {
            string s = "";
            for (int i = 0; i < r.Next(min, max + 1); i++)
            {
                if (r.Next(2) == 0)
                {
                    s += (char)r.Next(65, 91);
                }
                else
                {
                    s += (char)r.Next(97, 123);
                }
            }
            return s;
        }

        

    }
}
