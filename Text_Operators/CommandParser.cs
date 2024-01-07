using Data_Structures;
using Data_Structures.Collections;

namespace Text_Operators
{
    public static class CommandParser
    {
        public static string ReadCommand(string line)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in line)
            {
                if (c == ' ')
                {
                    break;
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        public static Data_Structures.Collections.List<string> GetParameters(string s)
        {
            Data_Structures.Collections.List<string> parameters = new Data_Structures.Collections.List<string>();

            StringBuilder sb = new StringBuilder();


            for (int i = s.IndexOfChar('(') + 1; i <= s.IndexOfChar(')'); i++)
            {
                if (char.IsLetter(s[i]) || char.IsDigit(s[i]))
                {
                    sb.Append(s[i]);
                }
                else if (s[i] == ',' || s[i] == ')')
                {
                    parameters.Add(sb.ToString());
                    sb.Clear();
                }
            }

            return parameters;
        }


        public static bool Define(string line, int parametersCount, out int functionCode, out string functionName, out TreeNode root, HashSet<int, FuncData> hashset)
        {
            string fName;
            bool funcFlag = false;
            StringBuilder sb = new StringBuilder();

            fName = GetFuntionNameFromLine(line);
            functionName = fName;

            Data_Structures.Collections.Stack<TreeNode> stack = new Data_Structures.Collections.Stack<TreeNode>();


            for (int i = line.IndexOfChar('"') + 1; i < line.Length - 1; i++)
            {
                char c = line[i];


                if (funcFlag && line[i] != ')')
                {
                    sb.Append(c);
                    continue;
                }

                if (line[i + 1] == ' ' && funcFlag)
                {
                    sb.Append(')');
                    string temp = sb.ToString();
                    sb.Clear();

                    string tempFuncName = temp.SubstringExtension(temp.IndexOfChar('('));
                    int funcHash = Hasher.HashName(tempFuncName);
                    var funcData = hashset[funcHash];

                    while (funcData != null)
                    {
                        if (funcData.Pair.Key == funcHash)
                        {
                            break;
                        }
                        funcData = funcData.Next;
                    }

                    if (funcData == null)
                    {
                        throw new InvalidOperationException($"Function with name {tempFuncName} does not exist!");
                    }

                    var data = GetParameters(temp).ToArray();
                    if (funcData.Pair.Value.CompareParameters(data) == false)
                    {
                        throw new InvalidDataException($"Invalid number of parameters have been based to the function {tempFuncName}!");
                    }

                    stack.Push(TreeNode.MakeCopy(funcData.Pair.Value.root));


                    funcFlag = false;
                }
                else if (c == ' ')
                {
                    continue;
                }


                if (char.IsLetter(c))
                {
                    if (char.IsLetter(line[i + 1] ))
                    {
                        funcFlag = true;
                        sb.Append(c);
                        continue;
                    }

                    stack.Push(new TreeNode
                    {
                        IsOperator = false,
                        Name = c.ToString(),
                    });
                }
                else if (c == '&' || c == '|')
                {
                    TreeNode tempOne = stack.Pop();
                    TreeNode tempTwo = stack.Pop();

                    stack.Push(new TreeNode
                    {
                        IsOperator = true,
                        Left = tempOne,
                        Right = tempTwo,
                        Name = c.ToString()
                    });
                }
                else if (c == '!')
                {
                    TreeNode temp = stack.Pop();

                    stack.Push(new TreeNode
                    {
                        IsOperator = true,
                        Left = temp,
                        Name = c.ToString()
                    });
                }
            }


            if (stack.Count != 1)
            {
                throw new InvalidDataException("Invalid line sequence!");
            }
            root = stack.Pop();

            Data_Structures.Collections.List<string> tempList = new Data_Structures.Collections.List<string>();
            TreeNode.GetLeafsCount(root, tempList);
            
            if (tempList.Count != parametersCount)
            {
                throw new InvalidDataException("Different number of parameters in function definition and expression!");
            }

            functionCode = Hasher.HashName(fName);

            return true;
        }


        public static bool Solve(string line, Data_Structures.Collections.HashSet<int, FuncData> functions)
        {
            string funcName = GetFuntionNameFromLine(line);
            int funcCode = Hasher.HashName(funcName);

            var list = functions[funcCode];
            SetFunction(list, funcName);


            var paramaeters = ConvertStringArrToInt(GetParameters(line).ToArray());

            var funcData = list!.Pair.Value;

            return funcData.GetValue(paramaeters);
        }


        public static string[] All(string line, Data_Structures.Collections.HashSet<int, FuncData> functions) 
        {
            string fName = GetFuntionNameFromLineForAll(line);
            int funcitonHash = Hasher.HashName(fName);

            var list = functions[funcitonHash];
            SetFunction(list, fName);

            var paramCount = list!.Pair.Value.numberOfParameters;
            int[] arr = new int[paramCount];


            Data_Structures.Collections.List<string> results = new Data_Structures.Collections.List<string>();

            do
            {
                bool value = list.Pair.Value.GetValue(arr);


                if (value)
                {
                    results.Add($"{FancyIntArrayDisplay(arr)}: 1");
                }
                else
                {
                    results.Add($"{FancyIntArrayDisplay(arr)}: 0");
                }

            } while (Next(arr, 2));


            return results.ToArray();
        }


        private static string FancyIntArrayDisplay(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
                sb.Append($"{item} ");
            return sb.ToString();
        }

        private static bool Next(int[] arr, int v)
        {
            var k = arr.Length;

            arr[k - 1]++;
            for (int i = k - 1; i > 0; i--)
            {
                if (arr[i] >= v)
                {
                    arr[i] = 0;
                    arr[i - 1]++;
                }
            }
            return arr[0] < v;
        }

        private static void SetFunction(KeyValuePairNode<int, FuncData>? list, string funcName)
        {
            while (list != null)
            {
                if (list.Pair.Value.funcName.Equals(funcName))
                {
                    break;
                }


                list = list.Next;
            }

            if (list == null)
            {
                throw new InvalidDataException("Function with specified name does not exist!");
            }
        }
        
        private static string GetFuntionNameFromLineForAll(string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = line.IndexOfChar(' ') + 1; i < line.Length; i++)
            {
                sb.Append(line[i]);
            }
            return sb.ToString();
        }

        private static string GetFuntionNameFromLine(string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = line.IndexOfChar(' ') + 1; i < line.IndexOfChar('('); i++)
            {
                sb.Append(line[i]);
            }
            return sb.ToString();
        }

        private static int[] ConvertStringArrToInt(string[] arr) 
        {
            int[] temp = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++) 
            {
                temp[i] = int.Parse(arr[i]);
            }

            return temp;
        }
    }
}
