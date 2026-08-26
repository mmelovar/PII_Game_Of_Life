using System;
using System.IO;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Lee un archivo de texto, interpreta los caracteres y crea un tablero a partir de los mismos
    /// </summary>
    public class BoardReader
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BoardReader"/>.
        /// </summary>
        public BoardReader(string url)
        {
            this.Url = url;
        }

        private string Url { get; set; }

        /// <summary>
        /// Lee el archivo y lo traduce a un tablero.
        /// </summary>
        /// <returns>
        /// Devuelve matriz de booleanos que representa el tablero.
        /// </returns>
        public bool[,] Read()
        {
            string content = File.ReadAllText(this.Url);
            string[] separators = { "\r\n" };
            string[] contentLines = content.Split(separators, StringSplitOptions.None);
            bool[,] board = new bool[contentLines[0].Length, contentLines.Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }

            return board;
        }
    }
}
