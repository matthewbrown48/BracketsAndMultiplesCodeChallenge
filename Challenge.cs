using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BracketsAndMultiples
{
    class Challenge
    {
                static void Main(string[] args) {
                Console.WriteLine(Balance("{test{}}").ToString());
                Console.WriteLine(FindMultiples().ToString());
        }

        public static int FindMultiples()
        {
            //Find the sum of all the multiples of 3 or 5 below 1000
            //For example, if we sum all multiples of 3 or 5 below 10, 
            //we would get 3, 5, 6, and 9 and the sum of these multiples is 23

            //We could just use a formula to calculate this, but that would be cheating ;) 
            //I did look up the formula afterwards to doublecheck my answer, in addition to testing it with smaller, known values
            
            
            List<int> lst_Multiples = new List<int>();
            //Loop through all the multiples of 3 under 1000
            for(int i = 0; i < 1000; i++)
            {
                if(i % 3 == 0)
                {
                    //add them to the list
                    lst_Multiples.Add(i);
                }
            }
            //loop through all the multiples of 5 under 1000
            for (int i = 0; i < 1000; i++)
            {
                if(i % 5 == 0)
                {
                    //Add them to the list of they aren't already there. (We don't want duplicates. if we did, we would just remove this check)
                    if(!lst_Multiples.Contains(i))
                    {
                        lst_Multiples.Add(i);
                    }
                }
            }
            //Add the contents of the list together and return them
            int int_result = lst_Multiples.Sum();
            return int_result;
        }

        public static bool Balance(string str_Content)
         {
            //Create a stack to keep track of our opening brackets 
            Stack stk_Brackets = new Stack();
            //Loop through each char in our string
            foreach(char c in str_Content) 
            {
                //If we find an opening bracket, add it to our stack
                if(c == '{') 
                {
                    stk_Brackets.Push(c);
                }
                else if(c == '}') //if we have a close, check and see if there was a previous open bracket
                {
                    //First make sure this isn't an closing bracket without having something in the stack first. (avoids exceptions on the next check for trying to pop an empty stack)
                    //We could simply watch for an exception on the next if statement, and return false in a try/catch, but this seems simpler.
                    try
                    {
                        if (stk_Brackets.Pop().ToString() != "{")
                        {
                            //if not, we have an unbalanced string return false. 
                            return false;
                        }
                    }
                    catch(InvalidOperationException) //If we hit this it means the Stack was empty, meaning we have a closing bracket without an open bracket.
                    {//We could use an if statement beforehand to check if it's empty, but that increases runtime significantly. 
                        return false;
                    }
                }  
            }
            if(stk_Brackets.Count == 0)// If we've finished looping, and have an empty stack, we are good to go! 
            {
                return true;
            }
            else //if the stack isn't empty, we have a lonely open brace, so return false. 
            {
                return false;
            }
        }
    }
}
