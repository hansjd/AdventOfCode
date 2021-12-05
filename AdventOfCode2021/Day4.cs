// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

public class Day4
{
    public Day4()
    {
        IEnumerable<string> input = File.ReadAllText("Input/04 Sample.txt").Split("\r\n\r\n");
        input = File.ReadAllText("Input/04.txt").Split("\r\n\r\n");


        Part1(input);
        //Part2(input);
    }

    private void Part1(IEnumerable<string> input)
    {
        Queue<string>? queue = new Queue<string>(input);

        Queue<int> values = new Queue<int>(queue.Dequeue().Split(',').Select(i => int.Parse(i)));

        BingoPlayer player = new BingoPlayer(queue);

        while (values.Any())
        {
            player.AddNumber(values.Dequeue());

            if (player.CheckBoard())
            {
                IEnumerable<BingoBoard> winningBoards = player.GetWinningBoards();
                foreach (var winningBoard in winningBoards)
                    Console.WriteLine($"board final score: {winningBoard.LastNumber * winningBoard.Sum}");
                //break;
            }
            if (player.Boards.Count == 0)
            {
                break;
            }
        }
        foreach (BingoBoard? board in player.Boards)
        {
            player.CheckBoard();
        }
    }

    private void Part2(List<string> input)
    {


    }
}

public class BingoPlayer
{
    public List<BingoBoard> Boards { get; set; } = new List<BingoBoard>();

    public BingoPlayer(Queue<string> boards)
    {
        foreach (string? board in boards)
        {
            Boards.Add(new BingoBoard(board));
        }
    }

    public void AddNumbers(int[] numbers)
    {
        foreach (BingoBoard? board in Boards)
        {
            board.AddNumbers(numbers);
        }
    }

    public void AddNumber(int number)
    {
        foreach (BingoBoard? board in Boards)
        {
            board.AddNumber(number);
        }
    }

    public bool CheckBoard()
    {
        return Boards.Any(board => board.HasFullRow() || board.HasFullColumns());
    }

    internal IEnumerable<BingoBoard> GetWinningBoards()
    {
        List<BingoBoard> winningboards = Boards.Where(board => board.HasWon).ToList();
        for (int i = 0; i < winningboards.Count; i++)
        {
            BingoBoard board = winningboards[i];
            int indexOfBoard = Boards.IndexOf(board);
            Boards.RemoveAt(indexOfBoard);
        }

        return winningboards;
    }
}


public class BingoBoard
{
    public int RowCount { get; set; } = 5;
    public int ColCount { get; set; } = 5;
    public BingoCell[,] Board { get; set; } = new BingoCell[5, 5];
    public bool HasWon => HasFullRow() || HasFullColumns();
    public int Sum => CalculateSum();
    public int? LastNumber { get; set; }

    public BingoBoard(string input)
    {
        string[]? rows = input.Split("\r\n").ToArray();
        for (int i = 0; i < rows.Length; i++)
        {
            var row = rows[i].Replace("  ", " ").Trim();
            var cells = row.Split(" ").Select(i => int.Parse(i)).ToArray();
            for (int j = 0; j < cells.Length; j++)
            {
                BingoCell cell = new() { Value = cells[j] };
                Board[i, j] = cell;
            }
        }
    }

    public void AddNumbers(int[] numbers)
    {
        foreach (int number in numbers)
        {
            AddNumber(number);
        }
    }

    public void AddNumber(int number)
    {
        LastNumber = number;
        foreach (BingoCell? bingoCell in Board)
        {
            if (!bingoCell.Marked)
                bingoCell.Marked = bingoCell.Value == number;
        }
    }

    public bool HasFullRow()
    {

        for (int i = 0; i < RowCount; i++)
        {
            var row = GetRow(i);
            var hasFullRow = !row.Any(x => !x.Marked);
            if (hasFullRow)
            {
                return true;
            }
        }

        return false;
    }

    internal bool HasFullColumns()
    {
        for (int i = 0; i < ColCount; i++)
        {
            var col = GetColumn(i);
            var hasFullCol = !col.Any(x => !x.Marked);
            if (hasFullCol)
            {
                return true;
            }
        }

        return false;
    }

    public int CalculateSum()
    {
        var sum = 0;
        foreach (BingoCell? cell in Board)
        {
            if (!cell.Marked)
                sum += cell.Value;
        }
        return sum;
    }

    IEnumerable<BingoCell> GetRow(int row)
    {
        for (int i = 0; i <= Board.GetUpperBound(1); ++i)
            yield return Board[row, i];
    }

    IEnumerable<BingoCell> GetColumn(int column)
    {
        for (int i = 0; i <= Board.GetUpperBound(0); ++i)
            yield return Board[i, column];
    }
}



public class BingoCell
{
    public int Value { get; set; }
    public bool Marked { get; set; } = false;
}