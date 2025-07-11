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

    // The time complexity of this solution is O(n), where `n` is the number of nodes in the tree.
    // This is because each node is visited exactly once. It is added to the queue (Enqueue) one time and removed from the queue (Dequeue) one time. 
    // Since every node is processed a constant number of times, the runtime is directly proportional to the total number of nodes.
    // 
    // The space complexity is O(w) or O(n), where `w` is the maximum width of the tree (the maximum number of nodes at any single level).
    // The extra space is determined by the maximum number of nodes stored in the queue at any given time. This occurs at the widest level of the tree.
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
