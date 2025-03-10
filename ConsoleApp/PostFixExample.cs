using DataStructuresLib.Stack;

namespace ConsoleApp
{
    public class PostFixExample
    {
        private string expression;
        LinkedListStack<string> S = new();

        private string Expression()
        {
            int val1, val2, ans;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+')
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val1 + val2;
                    S.Push(ans.ToString());
                }
                else if (expression[i] == '-')
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 - val1;
                    S.Push(ans.ToString());
                }
                else if (expression[i] == '*')
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 * val1;
                    S.Push(ans.ToString());
                }
                else if (expression[i] == '/')
                {
                    val1 = int.Parse(S.Pop());
                    val2 = int.Parse(S.Pop());
                    ans = val2 / val1;
                    S.Push(ans.ToString());
                }
                else
                {
                    S.Push(expression[i].ToString());
                }
            }

            return S.Pop();
        }

        public static string Run(string expresion)
        {
            PostFixExample e = new()
            {
                expression = expresion
            };

            return e.Expression();
        }
    }
}
