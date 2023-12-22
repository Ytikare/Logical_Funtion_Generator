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
    }
}
