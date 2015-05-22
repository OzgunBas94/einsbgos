using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Blatt2
{
    class Parser
    {
        // Parses input or opens file and parses equations in file. 
        // Returns a String with the value of the expression or the logical value of the equation.
        public String parse(string input)
        {
            String result = null;
            try
            {
                if (input != null && input.Length != 0 && input != "")
                {
                    if (input.StartsWith("file"))
                    {                        
                        input = input.Substring(4, input.Length-4);
                        try
                        {
                            StreamReader reader = new StreamReader(input);                        
                            while (reader.ReadLine() != null && reader.ReadLine().Length != 0)
                            {
                                input = reader.ReadLine();
                                result = this.parseEquation(input);
                                System.Console.WriteLine(result);
                            } reader.Close();
                        }
                        catch (SystemException fileEx)
                        {
                            fileEx.ToString();
                        }
                    }
                    else
                    {
                        result = this.parseEquation(input);
                    }
                }
                else
                {
                    System.Console.WriteLine("Please enter a numeric equation or a file with numeric equations!");
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            return result;
        }

        // Parses an equation.
        // Returns a String with the value of the expression or the logical value of the equation.
        private String parseEquation(string equationString) 
        {
            String result = null;

            if (equationString != "")
            {
                if (equationString.Contains('=')) // --> Expression
                {
                    int index = equationString.IndexOf('=');
                    string term = null;
                    if (index != 0 && index != equationString.Length - 1)
                    {
                        string term1 = "";
                        string term2 = "";
                        term = equationString.Substring(0, index);
                        term1 = this.parseExpression(term);//geht noch weiter?
                        term = equationString.Substring(index + 1, (equationString.Length - (++index)));
                        if (term.Contains('='))
                        {
                            result = null;
                            System.Console.WriteLine("Parser can only compare two terms.");
                        }
                        else
                        {
                            term2 = this.parseExpression(term);
                            if (term1 != null && term2 != null)
                            {
                                result = term1.Equals(term2).ToString();
                            }
                            else
                            {
                                result = null;
                                System.Console.WriteLine("Invalid Input!");
                            }
                        }
                    }
                    else
                    {
                        result = null;
                        System.Console.WriteLine("Equation musn't begin or end with '='!");
                    }
                }
                else if (equationString.Contains('+')) // --> Term
                {
                    result = this.parseTerm(equationString);
                }
                else if (equationString.Contains('*')) // --> Factor
                {
                    result = this.parseFactor(equationString);
                }
                else                                    // --> Constant
                {
                    result = this.parseConstant(equationString);
                }
            }
            else
            {
                result = null;
                System.Console.WriteLine("Input Error: Cannot parse empty Expression!");
            }
            return result;
        }

        // Parses an Expression.
        // Returns a String with the value of the expression.
        private String parseExpression(string equationString)
        {

            String result = null;
            if (equationString != "")
            {
                if (equationString.Contains('+')) // --> Term
                {
                    result = this.parseTerm(equationString);
                }
                else if (equationString.Contains('*')) // --> Factor
                {
                    result = this.parseFactor(equationString);
                }
                else                                    // --> Constant
                {
                    result = this.parseConstant(equationString);
                }
            }
            else
            {
                result = null;
                System.Console.WriteLine("Input Error: Cannot parse empty Expression!");
            }
            return result;

                
        
        }

        // Parses term.
        // Returns a String with the value of the term.
        private String parseTerm(string equationString)
        {

            String result = "";
            if (equationString != "")
            {
                if (equationString.Contains('(') || equationString.Contains(')') || equationString.Contains('*')) // --> Factor
                {
                    result = this.parseFactor(equationString);
                }
                else if (equationString.Contains('+'))
                {
                    if (equationString.Contains("++") || equationString.ElementAt(0) == '+' || equationString.ElementAt((equationString.Length-1)) == '+')
                    {
                        System.Console.WriteLine("Input Error '+'.");
                        result = null;
                    }
                    else                            // Only '+'-Operators
                    {
                        int loc = 0;
                        int x = 0;
                        string constant = "";
                        if (equationString != "")
                        {
                            while (loc < equationString.Length)
                            {
                                constant += equationString.ElementAt(loc);
                                loc++;

                                if (loc == equationString.Length || equationString.ElementAt(loc) == '+')
                                {
                                    if (constant != "")
                                    {
                                        x += Int32.Parse(constant);
                                        constant = "";
                                    }
                                }
                            }
                        }
                        result = x.ToString();
                    }
                }
                else
                {
                    if (result != null)
                    {
                        result = this.parseConstant(equationString);
                    }
                }
            }
            else
            {
                result = null;
                System.Console.WriteLine("Input Error: Cannot parse empty Expression!");
            }
            return result;

        }

        // Parses factors
        // Returns a term or a constant with the result as a String.
        private String parseFactor(string equationString)
        {
            String result = null;

            int bracketOpen = 0;
            int bracketClose = 0;

            bool brackets = false;

            string term = "";

            if (equationString != "" && equationString.Contains('('))
            {
                bracketOpen = equationString.IndexOf('(');
                brackets = true;
            }
            else if (equationString != "" && equationString.Contains(')')) // Checks if input is valid.
            {
                result = null;
                System.Console.WriteLine("Falsche Klammerung!");
            }
            else if (equationString.Contains('*'))                          // No brackets
            {
                if (equationString.Contains("+*") || equationString.Contains("*+") || equationString.Contains("**")) // Checks if input is valid.
                {
                    result = null;
                    System.Console.WriteLine("Invalid Input!");
                }
                else                                                        // calculates the term: multiplication fist, then addition
                {
                    int loc = 0;
                    int x = 0;
                    string constant = "";
                    string res = "";
                    if (equationString != "")
                    {
                        while (loc < equationString.Length)
                        {
                            constant += equationString.ElementAt(loc);
                            loc++;
                        
                            if (loc == equationString.Length || equationString.ElementAt(loc) == '*' || equationString.ElementAt(loc) == '+')
                            {
                                if (x == 0)
                                {
                                    x = Int32.Parse(constant);
                                    constant = "";
                                    res += x.ToString();
                                }
                                else
                                {
                                    x *= Int32.Parse(constant);
                                    constant = "";
                                    res = x.ToString();
                                }
                                if (loc < equationString.Length)
                                {
                                    if (equationString.ElementAt(loc) == '+')
                                    {
                                        result += res + "+";
                                        res = "";
                                        x = 0;
                                    } loc++;
                                }
                                else
                                {
                                    result += res;
                                }
                                
                            }
                        }
                    }
                    if (result != null)
                    {
                        result = this.parseExpression(result);
                    }
                    else
                    {
                        result = res;
                    }
                }
            }
            else                        // --> Constant
            {
                result = this.parseConstant(equationString);
            }
            if (brackets)               // There are brackets! Calculates term by term.
            {
                if (equationString.Contains(')'))
                {
                    int index = 1;
                    while (index < equationString.Length && equationString.ElementAt(index) != ')') // Searching inner brackets/ first term to calculate
                    {
                        index++;
                        if (equationString.ElementAt(index) == '(')
                        {
                            bracketOpen = index;
                        }
                    }
                    if (equationString.ElementAt(index) == ')')
                    {
                        bracketClose = index;
                    }
                    term = equationString.Substring(bracketOpen + 1, equationString.Length - (bracketOpen + 1) - equationString.Length - (bracketClose + 1));
                    if (term != "")
                    {
                        equationString = equationString.Substring(0, bracketOpen) + this.parseTerm(term) + equationString.Substring(bracketClose + 1, equationString.Length - (bracketClose++));
                        result = this.parseExpression(equationString);
                    }
                    else
                    {
                        System.Console.WriteLine("Input Error: Cannot parse empty Expression!");
                        result = null;
                    }
                }
                else
                {
                    result = null;
                    System.Console.WriteLine("Wrong brackets!");
                }
            }
            return result;
        }

        // Parses a constant
        // Returns a String with the value of the valid constant or null, if constant not valid
        private String parseConstant(string equationString)
        {
            string result = null;

            if (equationString != "")
            {
                int index = 0;
                while(index < equationString.Length && isDigit(equationString.ElementAt(index))){
                    result += equationString.ElementAt(index);
                    index++;
                }
            }
            else
            {
                result = null;
                System.Console.WriteLine("Wrong brackets!");              
            }
            return result;
        }

        // Checks for digits
        // Returns a boolean if the input is a digit.
        private Boolean isDigit(char equationString)
        {
            bool result = false;

            if (equationString == '0' || isDigitWithoutZero(equationString))
            {
                result = true;
            }
            return result;
        }

        // Checks for digits without zero.
        // Returns a boolean if the input is a digit without zero.
        private Boolean isDigitWithoutZero(char equationString)
        {
            bool result = false;

            if(equationString == '1' || equationString == '2' || equationString == '3' || 
                equationString == '4' || equationString == '5' || equationString == '6' || 
                equationString == '7' || equationString == '8' || equationString == '9')
            {
                result = true;
            }
            return result;
        }
    }
}
