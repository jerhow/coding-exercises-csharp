using Exercises;

/*
Topic: Trees / Recursion / Depth-First Search

Difficulty: Easy

Problem: Same Tree

Description:
Given the roots of two binary trees, p and q, 
write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, 
and the nodes have the same value.

Examples:

Input: p = [1,2,3], q = [1,2,3]

Trees:

  p:  1        q:  1
     / \          / \
    2   3        2   3
Output: true

Input: p = [1,2], q = [1,null,2]

Trees:

  p:  1        q:  1
     /              \
    2                2
Output: false (They are not structurally identical).

---

Input: p = [1,2,1], q = [1,1,2]

Trees:

  p:  1        q:  1
     / \          / \
    2   1        1   2
Output: false (The structure is the same, but the node values are different).
*/

[Exercise("ex0020")]
public class Ex0020 : IExercise
{
    public void Run()
    {
        Console.WriteLine("");
    }

    // This structure is the heart of many tree algorithms. 
    // You handle the "null" cases, check the current node's value, 
    // and then recursively call the function on the left and right children, 
    // combining their boolean results with AND.
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        // Base Case 1: If both nodes are null, they are the same.
        if (p == null && q == null)
        {
            return true;
        }

        // Base Case 2: If only one is null, or if the values don't match, they are not the same.
        // Note: We know from the first `if` that they can't BOTH be null here.
        if (p == null || q == null || p.val != q.val)
        {
            return false;
        }

        // Recursive Step: The trees are the same only if BOTH the left subtrees
        // AND the right subtrees are the same.
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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
