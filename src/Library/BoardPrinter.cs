//------------------------------------------------------------------------------
// <copyright file="BoardPrinter.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Muestra un tablero en la consola.
    /// </summary>
    /// <remarks>
    /// La separé del tablero por el mismo motivo que BoardReader: mostrar no es
    /// lo mismo que calcular generaciones. Si después hay que mostrar el juego
    /// de otra manera, se cambia sólo esta clase (SRP). Acá Expert es la que
    /// sabe cómo se dibuja cada célula, "|X|" si está viva y "___" si está
    /// muerta; si está viva o muerta se lo pregunta al tablero, porque eso lo
    /// sabe él y no ella.
    /// </remarks>
    public class BoardPrinter
    {
        /// <summary>
        /// Imprime el tablero recibido en la consola.
        /// </summary>
        /// <param name="board">El tablero a imprimir.</param>
        public void Print(Board board)
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if (board.IsAlive(x, y))
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }

                s.Append("\n");
            }

            Console.WriteLine(s.ToString());
        }
    }
}
