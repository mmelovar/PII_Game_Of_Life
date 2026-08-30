//------------------------------------------------------------------------------
// <copyright file="Game.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// El juego. Repite una y otra vez los pasos de mostrar el tablero,
    /// calcular la generación siguiente y esperar un rato.
    /// </summary>
    /// <remarks>
    /// Lo único de lo que se encarga es del orden de esos pasos, y ese es su
    /// único motivo para cambiar (SRP). No cuenta vecinos ni escribe en la
    /// consola: para eso le pide al tablero y al impresor, que son los expertos
    /// en cada una de esas cosas. Si el cálculo de vecinos o los Console
    /// estuvieran acá, esta clase tendría más de una razón para cambiar.
    /// </remarks>
    public class Game
    {
        private Board board;
        private BoardPrinter printer;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/> con el
        /// tablero y el impresor recibidos.
        /// </summary>
        /// <param name="board">El tablero del juego.</param>
        /// <param name="printer">El impresor del tablero.</param>
        public Game(Board board, BoardPrinter printer)
        {
            this.board = board;
            this.printer = printer;
        }

        /// <summary>
        /// Juega el juego de la vida mostrando una generación tras otra.
        /// </summary>
        public void Play()
        {
            while (true)
            {
                this.printer.Print(this.board);
                this.board.NextGeneration();
                Thread.Sleep(300);
            }
        }
    }
}
