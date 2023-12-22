namespace Data_Structures
{
    public class FuncData
    {
        public TreeNode root = null!;
        public int numberOfParameters;
        public List<string> parameters = new List<string>();

        public FuncData(TreeNode root, int numberOfParameters)
        {
            this.root = root;
            this.numberOfParameters = numberOfParameters;
        }
    }
}
