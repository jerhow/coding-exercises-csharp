using Exercises;

/*
Valid Sudoku
Topic: Arrays / Hash Tables / Matrix

Difficulty: Medium

Problem:
Determine if a 9 x 9 Sudoku board is valid. 
Only the filled cells need to be validated according to the following three rules:
- Each row must contain the digits 1-9 without repetition.
- Each column must contain the digits 1-9 without repetition.
- Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

Notes:
- A Sudoku board (partially filled) could be valid but not necessarily solvable.
- You only need to validate the cells that are already filled.
- The input is a char[][], where empty cells are represented by the . character.

Example:

Input:

board =
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]

Output: true
*/

[Exercise("ex0022")]
public class Ex0022 : IExercise
{
    public void Run()
    {
        char[][] board =
            [['5','3','.','.','7','.','.','.','.']
            ,['6','.','.','1','9','5','.','.','.']
            ,['.','9','8','.','.','.','.','6','.']
            ,['8','.','.','.','6','.','.','.','3']
            ,['4','.','.','8','.','3','.','.','1']
            ,['7','.','.','.','2','.','.','.','6']
            ,['.','6','.','.','.','.','2','8','.']
            ,['.','.','.','4','1','9','.','.','5']
            ,['.','.','.','.','8','.','.','7','9']];

        bool result = IsValidSudoku(board);
        Console.WriteLine(result);
    }

    // Because the input size is fixed (constant), and does not grow with any variable input,
    // the time and space complexity of this solution is O(1).
    public bool IsValidSudoku(char[][] board)
    {
        // We need 9 sets for the columns and 9 sets for the boxes.
        var cols = new Dictionary<int, HashSet<char>>();
        var boxes = new Dictionary<(int, int), HashSet<char>>();

        for (int r = 0; r < 9; r++)
        {
            // A single set for the current row, which we re-create for each new row.
            var rows = new HashSet<char>();

            for (int c = 0; c < 9; c++)
            {
                char currentVal = board[r][c];

                // Skip empty cells
                if (currentVal == '.')
                {
                    continue;
                }

                // Rule 1: Check the Row
                if (rows.Contains(currentVal))
                {
                    return false; // Found a duplicate in the row
                }
                rows.Add(currentVal);

                // Rule 2: Check the Column
                // Ensure a HashSet exists for this column index
                if (!cols.ContainsKey(c))
                {
                    cols[c] = new HashSet<char>();
                }

                if (cols[c].Contains(currentVal))
                {
                    return false; // Found a duplicate in the column
                }

                cols[c].Add(currentVal);

                // Rule 3: Check the 3x3 Box
                // Calculate the key for the current box
                // NOTE: The 3x3 boxes map to these coordinates:
                // (0,0) (0,1) (0,2)
                // (1,0) (1,1) (1,2)
                // (2,0) (2,1) (2,2)
                // These compound values (`boxKey`) that we're using as keys in `boxes` are tuples.
                // They are calculated using integer division:
                // - box_row = row / 3
                // - box_col = col / 3
                // For example:
                // - Cell (7, 5): row=7, col=5. `7 / 3 = 2. 5 / 3 = 1`. This cell is in box (2, 1).
                // - Cell (1, 8): row=1, col=8. `1 / 3 = 0. 8 / 3 = 2`. This cell is in box (0, 2).
                var boxKey = (r / 3, c / 3);
                
                if (!boxes.ContainsKey(boxKey))
                {
                    boxes[boxKey] = new HashSet<char>();
                }

                if (boxes[boxKey].Contains(currentVal))
                {
                    return false; // Found a duplicate in the 3x3 box
                }

                boxes[boxKey].Add(currentVal);
            }
        }

        // If we end up here, the board is valid.
        return true;
    }
}
