//------------------------------------------------------------------------------
// <copyright file="BoardReader.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.IO;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Arma un tablero leyendo un archivo de texto, donde cada línea es una
    /// fila y cada carácter '1' es una célula viva y cada '0' una muerta.
    /// </summary>
    /// <remarks>
    /// Leer el archivo lo dejé afuera del tablero para que Board no tenga que
    /// saber de archivos. Si mañana el tablero viene de otro lado, cambio esta
    /// clase y no toco ninguna otra; ese es su único motivo para cambiar, así
    /// que cumple con SRP. Y es Expert en el formato del archivo, que es lo
    /// único que hay que saber para poder armar el tablero.
    /// </remarks>
    public class BoardReader
    {
        /// <summary>
        /// Lee el archivo recibido y crea el tablero con su contenido.
        /// </summary>
        /// <param name="path">La ruta del archivo con el tablero.</param>
        /// <returns>El tablero leído desde el archivo.</returns>
        public Board ReadBoard(string path)
        {
            string[] contentLines = File.ReadAllLines(path);
            int height = contentLines.Length;
            int width = contentLines[0].Length;

            bool[,] cells = new bool[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        cells[x, y] = true;
                    }
                }
            }

            return new Board(cells);
        }
    }
}
