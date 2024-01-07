
namespace Data_Structures
{
    using Collections;
    public class TreeNode
    {
        private bool value;
        public TreeNode? Left, Right;
        public string Name = null!;
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
                        Value = !Left!.Value;
                        return !Left!.Value;

                    case "&":
                        Value = Left!.Value & Right!.Value;
                        return Left!.Value & Right!.Value;

                    default:
                        Value = Left!.Value | Right!.Value;
                        return Left!.Value | Right!.Value;

                }
            }

            set { this.value = value; }
        }


        public static int GetLeafsCount(TreeNode? node, List<string> uniqueElements) 
        {
            if (node == null)
            {
                return 0;
            }
            if (node.Left == null && node.Right == null)
            {
                if (uniqueElements.Contains(node.Name) == false)
                {
                    uniqueElements.Add(node.Name);
                }
                return 1;
            }
            return GetLeafsCount(node.Left, uniqueElements) + GetLeafsCount(node.Right, uniqueElements);
        }

        public static void GetLeafs(List<TreeNode> leafs, TreeNode node) 
        {
            if (node.Left == null && node.Right == null)
            {
                leafs.Add(node);
                return;
            }

            if (node.Left != null)
            {
                GetLeafs(leafs, node.Left);
            }

            if (node.Right != null)
            {
                GetLeafs(leafs, node.Right);
            }
        }


        public static TreeNode MakeCopy(TreeNode source) 
        {
            TreeNode temp = new TreeNode()
            {
                IsOperator = source.IsOperator,
                Name = source.Name,
                Value = source.Value,
                Left = source.Left == null ? null : MakeCopy(source.Left),
                Right = source.Right == null ? null : MakeCopy(source.Right)

            };

            return temp;
        }
    }
}
