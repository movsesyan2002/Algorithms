// class TreeNode
// {
//     public int val { get; set; }
//     public TreeNode Left { get; set; }
//     public TreeNode Right { get; set; }

//     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
//     {
//         this.val = val;
//         this.Left = left;
//         this.Right = right;
//     } 

// }

class BalancedTree
{
    TreeNode? root = null;

    public BalancedTree()
    {

    }

    public void Insert(int val)
    {
        if (root == null) return;
        root = InsertInTree(root, val);
        return;
    }

    private TreeNode InsertInTree(TreeNode node, int val)
    {
        if (node == null) return new TreeNode(val);

        if (node.val > val)
        {
            node.Left = InsertInTree(node.Left, val);
        }

        else if (node.val < val)
        {
            node.Right = InsertInTree(node.Right, val);
        }

        int bf = GetBalanceFactor(node);

        if (bf > 1 && node.Left.val > val)
        {
            return RightRotate(node);
        }

        if (bf > 1 && node.Left.val < val)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (bf < -1 && node.Right.val < val)
        {
            return LeftRotate(node);
        }

        if (bf < -1 && node.Right.val > val)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    public void Delete(int value)
    {
        root = Delete(root, value);
    }

    private TreeNode Delete(TreeNode node, int value)
    {
        if (node == null) return null;

        if (value < node.val) node.Left = Delete(node.Left, value);
        if (value > node.val) node.Right = Delete(node.Right, value);

        else
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;
            TreeNode temp = GetMax(node.Left);
            (node.val, temp.val) = (temp.val, node.val);
            node.Left = Delete(node.Left, value);
        }

        int bf = GetBalanceFactor(node);

        if (bf > 1 && GetBalanceFactor(node.Left) >= 0)
        {
            return RightRotate(node);
        }

        if (bf > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (bf < -1 && GetBalanceFactor(node.Right) < 0)
        {
            return LeftRotate(node);
        }

        if (bf < -1 && GetBalanceFactor(node.Right) >= 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private TreeNode RightRotate(TreeNode? node)
    {
        if (node == null) throw new Exception("Node is null");

        TreeNode temp = node.Left;
        TreeNode T3 = temp.Right;
        temp.Right = node;
        node.Left = T3;
        return temp;
    }

    private TreeNode LeftRotate(TreeNode? node)
    {
        if (node == null) throw new Exception("Node is null");

        TreeNode temp = node.Right;
        TreeNode T3 = temp.Left;
        temp.Left = node;
        node.Right = T3;

        return temp;
    }

    private int GetBalanceFactor(TreeNode? node)
    {
        if (node == null) throw new Exception("Node is null");

        return GetMaxDepth(node.Left) - GetMaxDepth(node.Right);
    }

    private int GetMaxDepth(TreeNode? node)
    {
        if (node == null) return 0;
        int left = GetMaxDepth(node.Left);
        int right = GetMaxDepth(node.Right);

        return Math.Max(left, right) + 1;
    }

    private TreeNode GetMax(TreeNode? node)
    {
        if (node == null || node.Right == null) return node;

        while (node.Right != null)
        {
            node = node.Right;
        }

        
        return node;
    }

    
    
}