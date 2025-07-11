using Exercises;

/*
Symmetric Tree
Topic: Trees / DFS / BFS
Difficulty: Easy

Problem:
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
Note: 'mirror', not 'identical'.

Examples:

Input: A tree with root = [1,2,2,3,4,4,3]

This represents the tree:

    1
   / \
  2   2
 / \ / \
3  4 4  3

Output: true

---

Input: root = [1,2,2,null,3,null,3]
This represents the tree:

  1
 / \
2   2
 \   \
 3    3
Output: false
*/

[Exercise("ex0024")]
public class Ex0024 : IExercise
{
    public void Run()
    {
        Console.WriteLine("");
    }

    public bool IsSymmetric(TreeNode root) 
    {
        // A tree with no root is symmetric.
        if (root == null) 
        {
            return true;
        }
        
        // Kick off the comparison with the root's two children.
        return IsMirror(root.left, root.right);
    }

    // Helper function that checks if two nodes are mirror images.
    private bool IsMirror(TreeNode node1, TreeNode node2) 
    {
        // Base Case 1: If both are null, they are symmetric.
        if (node1 == null && node2 == null) 
        {
            return true;
        }

        // Base Case 2: If one is null, they are not symmetric.
        if (node1 == null || node2 == null) 
        {
            return false;
        }

        // Check the values and then the subtrees with the "mirror" logic.
        return (node1.val == node2.val)
            && IsMirror(node1.left, node2.right)  // Outer children
            && IsMirror(node1.right, node2.left); // Inner children
    }
}

/*
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
*/
