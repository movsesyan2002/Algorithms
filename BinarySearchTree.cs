class BinarySearchTree
{
    TreeNode? root = null;

    public BinarySearchTree()
    {

    }

    public bool Search(int val)
    {
        return Search(root, val);
    }

    private bool Search(TreeNode node, int val)
    {
        if (node == null) return false;
        if (node.val == val) return true;
        bool right = false;
        bool left = false;
        if (val > node.val)
        {
            right = Search(node.Right, val);
        }

        else
        {
            left = Search(node.Left, val);
        }

        return right || left;
    }

    public void Insert(int val)
    {
        if (Search(root, val) == true)
        {
            Console.WriteLine("The element exist");
            return;
        }
        root = Insert(root, val);
    }

    private TreeNode Insert(TreeNode node, int val)
    {
        if (node == null) return new TreeNode(val);

        if (node.val > val)
        {
            node.Left = Insert(node.Left, val);
        }

        if (node.val < val)
        {
            node.Right = Insert(node.Right, val);
        }

        return node;
    }

    public void Remove(int val)
    {

        if (Search(root, val) == false)
        {
            Console.WriteLine("The element doesn't exist");
            return;
        }
        root = Remove(root, val);
    }

    private TreeNode Remove(TreeNode node, int val)
    {
        if (node == null) return node;

        if (node.val > val)
        {
            node.Left = Remove(node.Left, val);
        }

        else if (node.val < val)
        {
            node.Right = Remove(node.Right, val);
        }

        else
        {
            if (node.Left == null) return node.Right;

            if (node.Right == null) return node.Left;

            else
            {
                TreeNode temp = GetPredeccessor(val);
                (node.val, temp.val) = (temp.val, node.val);
                node.Right = Remove(node.Right, val);
            }
        }

        return node;
    }

    public void Display()
    {
        Display(root);
    }

    private void Display(TreeNode node)
    {
        if (node == null) return;

        Display(node.Left);
        Console.Write(node.val + " ");
        Display(node.Right);
    }


    private TreeNode GetMin(TreeNode node) 
    {
        if (node == null || node.Right == null) return node;

        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }

    private TreeNode GetMax(TreeNode node) 
    {
        if (node == null || node.Left == null) return node;

        while (node.Right != null)
        {
            node = node.Right;
        }

        return node;
    }

    private TreeNode GetSuccessor(int val)
    {
        TreeNode curr = root;
        TreeNode succ = null;

        if (curr == null)
        {
            return null;
        }

        if (curr.Right != null)
        {
            succ = GetMin(curr.Right);
        }
        
        while (curr != null)
        {
            if (val < curr.val)
            {
                succ = curr;
                curr = curr.Left;
            }

            else if (val > curr.val)
            {
                curr = curr.Right;
            }

            else
            {
                break;
            }
        }


        return succ;
    }

    public TreeNode GetPredeccessor(int val)
    {
        TreeNode predeccessor = null;
        TreeNode curr = root;
        if (curr != null)
        {
            return null;
        }

        if (curr.Left != null)
        {
            return GetMax(curr.Left);
        }

        while (curr != null)
        {
            if (val > curr.val)
            {
                predeccessor = curr;
                curr = curr.Right;
            }

            else if (val < curr.val)
            {
                curr = curr.Left;
            }

            else
            {
                break;
            }
        }


        return predeccessor;
    }
    public void PreTraversal()
    {
        TreeNode temp = root;
        PreTraversal(temp);
    }

    private void PreTraversal(TreeNode node)
    {
        if (node == null) return;

        Console.WriteLine(node.val);
        PreTraversal(node.Left);
        PreTraversal(node.Right);
    }

    public void InTraversal()
    {
        TreeNode temp = root;
        InTraversal(temp);
    }

    private void InTraversal(TreeNode node)
    {
        if (node == null) return;

        InTraversal(node.Left);
        Console.WriteLine(node.val);
        InTraversal(node.Right);
    }

    public void PostTraversal()
    {
        TreeNode temp = root;
        PostTraversal(temp);
    }

    private void PostTraversal(TreeNode node)
    {
        if (node == null) return;

        PostTraversal(node.Left);
        PostTraversal(node.Right);
        Console.WriteLine(node.val);
    }
}

class TreeNode
{
    public int val { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.Left = left;
        this.Right = right;
    } 

}