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
        if (value != Data)
        {
            if (value < Data)
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
            if (Left is not null)
            {
                return Left.Contains(value);
            }
        }
        else
        {
            if (Right is not null)
            {
                return Right.Contains(value);
            }
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Get left subtree's height (0 if null)
        int leftHeight;
        if (Left is null)
        {
            leftHeight = 0;
        }
        else
        {
            leftHeight = Left.GetHeight();
        }

        // Get right subtree's height (0 if null)
        int rightHeight;
        if (Right is null)
        {
            rightHeight = 0;
        }
        else
        {
            rightHeight = Right.GetHeight();
        }
        // Return current node height = 1 + max of left and right
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}