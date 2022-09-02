using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorythmParentheses
{
    internal class Program
    {
        static readonly List<char> openBrackets = new List<char> { '(', '[', '{' };
        static readonly List<char> closeBrackets = new List<char> { ')', ']', '}' };
        static readonly Dictionary<char, char> openCloseBrackets = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello World!");
                string bracketSequence = Console.ReadLine();

                bool result = false;

                //Простейшие валидации перед основной проверкой
                if (bracketSequence.Length > 0
                    && bracketSequence.Length % 2 == 0
                    && openBrackets.Contains(bracketSequence[0])
                    && closeBrackets.Contains(bracketSequence[bracketSequence.Length - 1])
                    )
                {
                    var openBracketsStack = new Stack<char>();

                    foreach (char c in bracketSequence)
                    {
                        if (openBrackets.Contains(c))
                        {
                            openBracketsStack.Push(c);
                        }
                        else if (closeBrackets.Contains(c))
                        {
                            if (openCloseBrackets.GetValueOrDefault(openBracketsStack.Peek()) != c)
                            {
                                break;
                            }
                            openBracketsStack.Pop();
                        }
                    }

                    // Если стек пустой возвращаем true
                    if (openBracketsStack.Count == 0)
                    {
                        result = true;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}
