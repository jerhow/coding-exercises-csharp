using Exercises;

/*
Topic: Trees / Recursion
Problem: Maximum Depth of Binary Tree

Description:
Given the root of a binary tree, return its maximum depth.

The maximum depth is the number of nodes along the longest path 
from the root node down to the farthest leaf node.

Examples:

Input: A tree with root = [3, 9, 20, null, null, 15, 7]

This represents the tree:

  3
 / \
9  20
  /  \
 15   7

Output: 3

Explanation: The longest path is 3 -> 20 -> 7 (or 3 -> 20 -> 15), which has 3 nodes.

---

Input: root = [1, null, 2]

This represents the tree:

  1
   \
    2

Output: 2
*/

[Exercise("ex0019")]
public class Ex0019 : IExercise
{
    public void Run()
    {
        Console.WriteLine("");
    }

    public int MaxDepth(TreeNode root)
    {
        // Base Case: If the node is null, we've reached the end. Its depth is 0.
        if (root == null)
        {
            return 0;
        }

        // Recursive Step:
        // 1. Find the max depth of the left side.
        int leftSubtreeDepth = MaxDepth(root.left);
        
        // 2. Find the max depth of the right side.
        int rightSubtreeDepth = MaxDepth(root.right);

        // 3. The depth from this node down is 1 (for this node) plus the
        //    deeper of the two subtrees.
        return 1 + Math.Max(leftSubtreeDepth, rightSubtreeDepth);
    }
}

// For reference
public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
