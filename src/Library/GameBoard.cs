namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Representa el tablero del juego
    /// </summary>
    public class GameBoard
    {
        private bool[,] currentBoard;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameBoard"/>.
        /// </summary>
        public GameBoard(bool[,] board)
        {
            this.currentBoard = board;
        }

        /// <summary>
        /// Calcula la siguiente generación.
        /// </summary>
        public void NextGeneration()
        {
            int boardWidth = this.currentBoard.GetLength(0);
            int boardHeight = this.currentBoard.GetLength(1);
            bool[,] nextBoard = new bool[boardWidth, boardHeight];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && this.currentBoard[i, j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if (this.currentBoard[x, y])
                    {
                        aliveNeighbors--;
                    }
                    if (this.currentBoard[x, y] && aliveNeighbors < 2)
                    {
                        // Célula muere por baja población
                        nextBoard[x, y] = false;
                    }
                    else if (this.currentBoard[x, y] && aliveNeighbors > 3)
                    {
                        // Célula muere por sobrepoblación
                        nextBoard[x, y] = false;
                    }
                    else if (!this.currentBoard[x, y] && aliveNeighbors == 3)
                    {
                        // Célula nace por reproducción
                        nextBoard[x, y] = true;
                    }
                    else
                    {
                        // Célula mantiene el estado que tenía
                        nextBoard[x, y] = this.currentBoard[x, y];
                    }
                }
            }
            this.currentBoard = nextBoard;
        }
    }
}