public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// For example, if the function was called on:
    ///
    /// sortedNumbers = new[]{10, 20, 30, 40, 50, 60};
    /// first = 0;
    /// last = 5;
    /// 
    /// then the value 30 (index 2 which is the middle) would be added 
    /// to the 'bst' (the insert function in the <see cref="BinarySearchTree"/> can be used
    /// to do this).   
    ///
    /// Subsequent recursive calls are made to insert the middle from the values 
    /// before 30 and the values after 30.  If done correctly, the order
    /// in which values are added (which results in a balanced bst) will be:
    /// 
    /// 30, 10, 20, 50, 40, 60
    /// 
    /// This function is intended to be called the first time by CreateTreeFromSortedList.
    ///
    /// The purpose for having the first and last parameters is so that we do 
    /// not need to create new sub-lists when we make recursive calls.  Avoid 
    /// using list slicing to create sub-lists to solve this problem.    
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index in the sortedNumbers to insert</param>
    /// <param name="last">the last index in the sortedNumbers to insert</param>
    /// <param name="bst">the BinarySearchTree in which to insert the values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // TODO Start Problem 5

        // On the recursive, the index that gets the last (in case of working with the left side) or first (in case of working with the right side) is an equation (middle +- 1) so, if the first index is greater than the last one, it means two cases:
        // >> last = middle - 1 (which is last for the left side) is less than first. 
        // >> first = middle + 1 (which is first fort the right side) is greater than last.
        // Both cases: stop, there're no more indexes, you passed a leaf.
        if (first > last)
        {
            return;
        }

        // The middle value is in a spot on the half of the sum of the first value and the last index. This keeps it simple to find the middle one. (This is also known as midpoint).
        int middleIndex = (first + last) / 2;

        // So the middle value is the one on the middle index.
        var middleValue = sortedNumbers[middleIndex];


        // Insert in the tree.
        bst.Insert(middleValue);

        // At this point there's still more than one index (allegedly). So recurse to the left half of the list (menus 1 index, this index is the "parent" one).
        InsertMiddle(sortedNumbers, first, middleIndex - 1, bst);

        // Finally, recurse to the right half to finalize the tree (plus 1 index, this index is the "parent" one).
        InsertMiddle(sortedNumbers, middleIndex + 1, last, bst);
    }
}