public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data) // If you got the value already in the data. Stop this iteration.
        {
            return;
        }

        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }

        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        if (value == Data)
        {
            return true;
        }

        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
            {
                return false;
            }

            return Left.Contains(value);
        }

        else
        {
            if (Right is null)
            {
                return false;
            }

            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Base case: Check if both of the children are null. If so, then there's just the current node, so height is 1. Note: this should be a leaf then.
        if (Left == null && Right == null)
        {
            return 1;
        }

        // Get the height of the left subtree.
        int leftSubTreeHeight;

        if (Left is not null) // if left exist, then get the heigh by recursive.
        {
            leftSubTreeHeight = Left.GetHeight();
        }

        else // If Left doesn't exist, then it is 0.
        {
            leftSubTreeHeight = 0;
        }

        // Get the height of the right subtree.
        int rightSubTreeHeight;

        if (Right is not null) // if Right exist, then get the heigh by recursive.
        {
            rightSubTreeHeight = Right.GetHeight();
        }

        else // If Right doesn't exist, then it is 0.
        {
            rightSubTreeHeight = 0;
        }

        // The tree's height is 1 + the greater height of the two subtrees. Note: That 1 is the root (or pseudo-root when speaking of the bottom branches).
        int treeHeight = 1 + Math.Max(leftSubTreeHeight, rightSubTreeHeight);

        return treeHeight; 
    }
}