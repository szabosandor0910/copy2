using System;
using System.Collections.Generic;

namespace feladat2
{
    public static class StringExtension
    {
        public static bool IsValid(this string sor)
        {
            char[] darabol = sor.ToCharArray();
            var stack = new Stack<char>(100);
            if (!darabol[0].Equals(')'))
            {
                for (var i = 0; i < darabol.Length; i++)
                {
                    if (darabol[i].Equals('('))
                    {
                        stack.Push('(');
                    }
                    else
                    {
                        try
                        {
                            stack.Pop();
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                if (stack.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
