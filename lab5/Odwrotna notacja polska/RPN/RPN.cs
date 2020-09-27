using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class RPN
    {
        public List<Node> symbols = new List<Node>();
        List<Node> polish = new List<Node>();

        public string BuildListOfSymbols(string text, List<string> functions)
        {
            for (int i = 0; i < text.Length; i++)
            {
                // unary sign check
                char symbol = text[i];
                if (symbol == '.') { return "Don't use points in expression"; }

                if (i == 0 && (symbol == '-' || symbol == '+'))
                {
                    symbols.Add(new Node() { digit = 0.0, sign = null, bracket = null, priority = 0, type = "digit" });
                }

                if (symbols.Count() > 0 && symbols.LastOrDefault().bracket == "(" && (symbol == '-' || symbol == '+'))
                {
                    symbols.Add(new Node() { digit = 0.0, sign = null, bracket = null, priority = 0, type = "digit" });
                }

                // isDigit
                bool stopDigit = false;
                if (Char.IsDigit(symbol) || symbol == ',')
                {
                    string digit = symbol.ToString();
                    if (i + 1 < text.Length)
                    {
                        i++;
                        symbol = text[i];
                    }
                    else
                    {
                        stopDigit = true;
                    }

                    while ((Char.IsDigit(symbol) || symbol == ',') && !stopDigit)
                    {
                        digit += symbol.ToString();
                        if (i + 1 < text.Length)
                        {
                            symbol = text[++i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (i + 1 < text.Length)
                    {
                        --i;
                    }
                    double d = double.Parse(digit);
                    symbols.Add(new Node() { digit = d, sign = null, bracket = null, priority = 0, type = "digit" });
                    continue;
                };

                // functions
                if (symbol != 'x' && Char.IsLetter(symbol))
                {
                    string func = symbol.ToString();
                    if (i + 1 < text.Length)
                    {
                        i++;
                        symbol = text[i];
                    }
                    while (Char.IsLetter(symbol))
                    {
                        func += symbol.ToString();
                        if (i + 1 < text.Length)
                        {
                            symbol = text[++i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (i + 1 < text.Length)
                    {
                        --i;
                    }
                    if (functions.Exists(x => x == func))
                    {
                        symbols.Add(new Node() { digit = 0.0, sign = "sin", bracket = null, priority = 3, type = "sign" });
                        continue;
                    }
                    return "Функция " + func + " не найдена";
                };

                if (symbol == 'x')
                {
                    symbols.Add(new Node() { digit = 0.0, sign = "x", bracket = null, priority = 0, type = "variable" });
                    continue;
                }

                switch (symbol)
                {
                    case '+':
                        symbols.Add(new Node() { digit = 0.0, sign = "+", bracket = null, priority = 1, type = "sign" });
                        break;
                    case '-':
                        symbols.Add(new Node() { digit = 0.0, sign = "-", bracket = null, priority = 1, type = "sign" });
                        break;
                    case '*':
                        symbols.Add(new Node() { digit = 0.0, sign = "*", bracket = null, priority = 2, type = "sign" });
                        break;
                    case '/':
                        symbols.Add(new Node() { digit = 0.0, sign = "/", bracket = null, priority = 2, type = "sign" });
                        break;
                    case '(':
                        symbols.Add(new Node() { digit = 0.0, sign = null, bracket = "(", priority = 0, type = "bracket" });
                        break;
                    case ')':
                        symbols.Add(new Node() { digit = 0.0, sign = null, bracket = ")", priority = 0, type = "bracket" });
                        break;
                }
            }
            return "";
        }

        public string BuildRPN()
        {
            List<Node> symbolsWork = new List<Node>(symbols);
            Stack<Node> stc = new Stack<Node>();

            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i].type == "digit" || symbols[i].type == "variable")
                {
                    polish.Add(symbols[i]);
                    symbolsWork.Remove(symbols[i]);
                    continue;
                }
                else if (symbols[i].bracket == "(")
                {
                    stc.Push(symbols[i]);
                    symbolsWork.Remove(symbols[i]);
                    continue;
                }
                else if (symbols[i].bracket == ")")
                {
                    while (stc.Count > 0)
                    {
                        Node symbol = stc.Pop();
                        if (symbol.bracket == "(")
                        {
                            symbolsWork.Remove(symbols[i]);
                            break;
                        }
                        polish.Add(symbol);
                    }
                    continue;
                }

                if (symbols[i].type == "sign")
                {
                                        
                    if (stc.Count == 0|| (stc.Count > 0 && stc.Peek().bracket == "("))
                    {
                        //polish.Add(symbols[i]);
                        stc.Push(symbols[i]);
                        symbolsWork.Remove(symbols[i]);
                        continue;
                    }
                    else if (stc.Count > 0 && stc.Peek().type == "sign" && stc.Peek().priority < symbols[i].priority)
                    {
                        stc.Push(symbols[i]);
                        symbolsWork.Remove(symbols[i]);
                        continue;
                    }
                    else if (stc.Count > 0)
                    {
                        polish.Add(stc.Pop());
                        i--;
                        continue;
                    }
                }
            }

            while (stc.Count > 0)
            {
                polish.Add(stc.Pop());
            }

            string result = "";
            foreach (var item in polish)
            {
                if (item.type == "digit")
                { result += item.digit.ToString(); }
                if (item.type == "sign" || item.type == "variable")
                { result += item.sign; }
            }

            return result;
        }

        public string Calculate(double a, double b, double h)
        {
            List<Node> list = polish.FindAll(x => x.type == "variable");

            string result = "";

            for (double i = a; i <= b; i += h)
            {
                foreach (var item in list)
                {
                    item.digit = i;
                }

                Stack<double> st = new Stack<double>();

                foreach (var item in polish)
                {

                    if (item.type == "digit" || item.type == "variable")
                        st.Push(item.digit);
                    else
                    {
                        double value;
                        switch (item.sign)
                        {
                            case "+":
                                st.Push(st.Pop() + st.Pop());
                                break;
                            case "*":
                                st.Push(st.Pop() * st.Pop());
                                break;
                            case "-":
                                var temp1 = st.Pop();
                                var temp2 = st.Pop();                                                                
                                st.Push(temp2 - temp1);                                
                                break;
                            case "/":
                                value = st.Pop();
                                if (value != 0.0)
                                    st.Push(st.Pop() / value);
                                else
                                    return "Devide by zero";
                                break;
                            case "sin":
                                st.Push(Math.Sin(st.Pop()));
                                
                                break;
                        }
                    }
                }

                result += "For x = " + i + " result: " + st.Pop().ToString() + "\r\n";

                if (i + h > b && i != b)
                {
                    i = b - h;
                }
            }
            return result;
        }
    }
}
