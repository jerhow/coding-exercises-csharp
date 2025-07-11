using Exercises;

/*
Rotate Image
Topic: Arrays / Matrix
Difficulty: Medium

Problem:
You are given an n x n 2D matrix representing an image. Rotate the image by 90 degrees clockwise.

You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. 
DO NOT allocate another 2D matrix and do the rotation.

Examples:

Input:

matrix =
[[1,2,3],
 [4,5,6],
 [7,8,9]]

Output:
[[7,4,1],
 [8,5,2],
 [9,6,3]]

Input:

matrix =
[[5,1,9,11],
 [2,4,8,10],
 [13,3,6,7],
 [15,14,12,16]]

Output:
[[15,13,2,5],
 [14,3,4,1],
 [12,6,8,9],
 [16,7,10,11]]
*/

[Exercise("ex0025")]
public class Ex0025 : IExercise
{
    public void Run()
    {
        int[][] matrix = [[1,2,3],
                          [4,5,6],
                          [7,8,9]];
        Rotate(matrix);
    }

    // Step 1: Transpose the matrix.
    // Step 2: Reverse each row of the transposed matrix.
    public void Rotate(int[][] matrix)
    {
        int size = matrix.Length;

        // Step 1: Transpose the matrix
        // Meaning, swap the elements across the main diagonal (from top-left to bottom-right)
        for (int row = 0; row < size; row++) {
            for (int col = row; col < size; col++) {
                // Swap the element at (row, col) with the element at (col, row)
                int temp = matrix[col][row];
                matrix[col][row] = matrix[row][col];
                matrix[row][col] = temp;
            }
        }

        // Step 2: Reverse each individual row
        for (int row = 0; row < size; row++) {
            Array.Reverse(matrix[row]);
        }
    }
}
