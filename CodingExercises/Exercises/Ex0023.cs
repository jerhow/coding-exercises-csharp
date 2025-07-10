using Exercises;

/*
Level Order Traversal
This problem is the quintessential BFS exercise. It asks you to implement the algorithm directly.

Topic: Trees / Breadth-First Search (BFS)

Difficulty: Medium

Problem:
Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

Examples:

Input: A tree with root = [3, 9, 20, null, null, 15, 7]

This represents the tree:

  3
 / \
9  20
  /  \
 15   7

Output: [[3], [9,20], [15,7]]
*/

[Exercise("ex0023")]
public class Ex0023 : IExercise
{
    public void Run()
    {
        Console.WriteLine("");
    }

    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        var results = new List<IList<int>>();
        if (root == null) 
        {
            return results;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) 
        {
            // Get the number of nodes at the current level
            int levelSize = queue.Count;
            var currentLevel = new List<int>();

            // Process all nodes for the current level
            for (int i = 0; i < levelSize; i++) 
            {
                TreeNode currentNode = queue.Dequeue();
                currentLevel.Add(currentNode.val);

                // Add children to the queue for the next level
                if (currentNode.left != null) 
                {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null) 
                {
                    queue.Enqueue(currentNode.right);
                }
            }
            
            // Add the completed level to the results
            results.Add(currentLevel);
        }

        return results;
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
