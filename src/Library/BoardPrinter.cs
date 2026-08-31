using System;

namespace Ucu.Poo.GameOfLife
{
public class BoardPrinter
{
    public void Print(GameBoard board)
    {
        for (int y = 0; y < board.Height; y++)
        {
            for (int x = 0; x < board.Width; x++)
            {
                if (board.IsAlive(x, y))
                {
                    Console.Write("|X|");
                }
                else
                {
                    Console.Write("___");
                }
            }

            Console.WriteLine();
        }
    }
}
}