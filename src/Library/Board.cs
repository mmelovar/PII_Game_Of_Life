//------------------------------------------------------------------------------
// <copyright file="Board.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// El tablero del juego. Guarda las células y sabe cómo queda el tablero en
    /// la generación siguiente.
    /// </summary>
    /// <remarks>
    /// Tiene una sola razón de cambio: cómo evoluciona el tablero de una
    /// generación a la otra, así que cumple con SRP. El cálculo de la
    /// generación siguiente lo puse acá por Expert: para saber si una célula
    /// vive o muere hay que mirar a sus vecinas, y la única que tiene las
    /// células es el tablero. Si ese cálculo estuviera en otra clase, esa clase
    /// le tendría que pedir todas las células al tablero para poder hacerlo.
    /// </remarks>
    public class Board
    {
        // En cada posición, true es una célula viva y false una muerta.
        private bool[,] cells;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/> con
        /// las células recibidas.
        /// </summary>
        /// <param name="cells">Las células del tablero.</param>
        public Board(bool[,] cells)
        {
            this.cells = cells;
        }

        /// <summary>
        /// Obtiene el ancho del tablero, es decir la cantidad de columnas.
        /// </summary>
        public int Width
        {
            get { return this.cells.GetLength(0); }
        }

        /// <summary>
        /// Obtiene la altura del tablero, es decir la cantidad de filas.
        /// </summary>
        public int Height
        {
            get { return this.cells.GetLength(1); }
        }

        /// <summary>
        /// Determina si la célula que está en la posición recibida está viva.
        /// </summary>
        /// <param name="x">La columna de la célula.</param>
        /// <param name="y">La fila de la célula.</param>
        /// <returns><c>true</c> si la célula está viva; si no <c>false</c>.</returns>
        public bool IsAlive(int x, int y)
        {
            return this.cells[x, y];
        }

        /// <summary>
        /// Calcula la siguiente generación del tablero aplicando las reglas del
        /// juego de la vida.
        /// </summary>
        public void NextGeneration()
        {
            int boardWidth = this.Width;
            int boardHeight = this.Height;

            bool[,] cloneBoard = new bool[boardWidth, boardHeight];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && this.cells[i, j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }

                    if (this.cells[x, y])
                    {
                        aliveNeighbors--;
                    }

                    if (this.cells[x, y] && aliveNeighbors < 2)
                    {
                        // Célula muere por baja población
                        cloneBoard[x, y] = false;
                    }
                    else if (this.cells[x, y] && aliveNeighbors > 3)
                    {
                        // Célula muere por sobrepoblación
                        cloneBoard[x, y] = false;
                    }
                    else if (!this.cells[x, y] && aliveNeighbors == 3)
                    {
                        // Célula nace por reproducción
                        cloneBoard[x, y] = true;
                    }
                    else
                    {
                        // Célula mantiene el estado que tenía
                        cloneBoard[x, y] = this.cells[x, y];
                    }
                }
            }

            this.cells = cloneBoard;
        }
    }
}
