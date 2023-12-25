namespace Data_Structures
{
    public class TreeNode
    {
        private bool value;
        public TreeNode? Left, Right;
        public string? Name;
        public bool IsOperator;

        public bool Value
        {
            get
            {
                if (IsOperator == false)
                {
                    return value;
                }

                switch (Name)
                {
                    case "!":
                        return !Left!.Value;

                    case "&":
                        return Left!.Value & Right!.Value;

                    default:
                        return Left!.Value | Right!.Value;

                }
            }

            set { Value = value; }
        }


        public static int GetLeafsCount(TreeNode? node) 
        {
            if (node == null)
            {
                return 0;
            }
            if (node.Left == null && node.Right == null)
            {
                return 1;
            }
            return GetLeafsCount(node.Left) + GetLeafsCount(node.Right);
        }
    }
}
