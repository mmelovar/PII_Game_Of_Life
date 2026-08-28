using System;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Representa el tablero del Juego de la Vida de Conway y gestiona el estado y la evolución de sus células.
    /// 
    /// Justificación de Principios de Diseño:
    /// - Expert (Information Expert): Esta clase posee y encapsula la matriz de células (grid). Por lo tanto, es la 
    ///   única responsable de consultar el estado de las celdas, contar los vecinos vivos en la vecindad de Moore 
    ///   y computar la función de transición a la siguiente generación.
    /// - SRP (Single Responsibility Principle): Su única razón de cambio es la modificación en la lógica del autómata 
    ///   celular y las reglas de evolución de la simulación. No asume responsabilidades de lectura de archivos ni de 
    ///   representación gráfica en la interfaz de usuario.
    /// </summary>
    
    public class Board
    {
        private bool[,] grid;

        /// <summary>
        /// Obtiene el ancho del tablero expresado en número de columnas.
        /// </summary>
        /// <value>Cantidad de columnas de la matriz del tablero.</value>
     
        public int Width
        {
            get
            {
                return this.grid.GetLength(0);
            }
        }

        /// <summary>
        /// Obtiene la altura del tablero expresada en número de filas.
        /// </summary>
        /// <value>Cantidad de filas de la matriz del tablero.</value>
    
        public int Height
        {
            get
            {
                return this.grid.GetLength(1);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/> con una matriz bidimensional inicial.
        /// </summary>
        /// <param name="initialGrid">Matriz de booleanos donde <c>true</c> representa una célula viva y <c>false</c> una muerta.</param>
    
        public Board(bool[,] initialGrid)
        {
            this.grid = initialGrid;
        }

        /// <summary>
        /// Indica si la célula en la posición especificada por las coordenadas X e Y está viva.
        /// </summary>
        /// <param name="x">Coordenada en el eje X (columna) de la célula.</param>
        /// <param name="y">Coordenada en el eje Y (fila) de la célula.</param>
        /// <returns><c>true</c> si la célula está viva; de lo contrario, <c>false</c>.</returns>
    
        public bool IsAlive(int x, int y)
        {
            return this.grid[x, y];
        }

        /// <summary>
        /// Avanza la simulación al siguiente estado o generación aplicando las reglas del Juego de la Vida.
        /// </summary>
    
        public void Step()
        {
            bool[,] nextGeneration = new bool[this.Width, this.Height];

            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    int neighbors = this.CountAliveNeighbors(x, y);
                    bool currentlyAlive = this.grid[x, y];

                    // Reglas de Conway
                    if (currentlyAlive && (neighbors == 2 || neighbors == 3))
                    {
                        nextGeneration[x, y] = true;
                    }
                    else if (!currentlyAlive && neighbors == 3)
                    {
                        nextGeneration[x, y] = true;
                    }
                    else
                    {
                        nextGeneration[x, y] = false;
                    }
                }
            }

            this.grid = nextGeneration;
        }

        /// <summary>
        /// Cuenta la cantidad de células vecinas vivas que rodean a una posición dada dentro del tablero.
        /// </summary>
        /// <param name="x">Coordenada en el eje X (columna) de la célula central.</param>
        /// <param name="y">Coordenada en el eje Y (fila) de la célula central.</param>
        /// <returns>La cantidad de células vecinas en estado activo/vivo.</returns>
    
        private int CountAliveNeighbors(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y)
                    {
                        continue; // Excluir la célula actual
                    }

                    if (i >= 0 && i < this.Width && j >= 0 && j < this.Height && this.grid[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}