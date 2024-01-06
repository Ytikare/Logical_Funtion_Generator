namespace Data_Structures
{
    using Collections;

    public class FuncData
    {
        public TreeNode root = null!;
        public int numberOfParameters;
        public Dictionary<string, bool> parameters = new Dictionary<string, bool>();
        public string funcName = null!;
        

        public FuncData()
        { }

        public FuncData(TreeNode root, int numberOfParameters, string funcName)
        {
            this.root = root;
            this.numberOfParameters = numberOfParameters;
            this.funcName = funcName;
        }


        public bool CompareParameters(string[] paramNames) 
        {
            if (paramNames.Length != this.parameters.Count)
            {
                return false;
            }

            for (int i = 0; i < paramNames.Length; i++)
            {
                if (parameters.ContainsKey(paramNames[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public TreeNode MakeCopy() 
        {
            var treeCopy = TreeNode.MakeCopy(root);

            return treeCopy;
        }

        public bool GetValue(int[] numbers)  
        {
            if (numbers.Length != parameters.Count)
            {
                throw new InvalidDataException("Wrong number of values passed.");
            }

            SetValues(numbers);

            var result = this.root.Value;

            return result;
        }

        private void SetValues(int[] numbers)
        {
            List<TreeNode> leafs = new List<TreeNode>();
            TreeNode.GetLeafs(leafs, root);

            int i = 0;

            foreach (var param in parameters)
            {
                bool value = false;
                if (numbers[i] == 1)
                {
                    value = true;
                }

                param.Pair.Value = value;

                for (int j = 0; j < leafs.Count; j++)
                {
                    if (param.Pair.Key == leafs[j].Name)
                    {
                        leafs[j].Value = value;
                    }
                }

                i++;
            }
        }
    }
}
