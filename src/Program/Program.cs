//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.IO;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// El punto de entrada del programa. Crea los objetos que hacen falta y
    /// arranca el juego.
    /// </summary>
    /// <remarks>
    /// Lo único que hace es armar el lector, el tablero, el impresor y el
    /// juego, y después largarlo a andar. Esa es su única razón de cambio, y
    /// está separada de la lógica porque si mañana el juego se lee o se muestra
    /// de otra forma, lo único que cambia acá son las clases que creo.
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            string boardPath = Path.Combine(folder, "board.txt");

            BoardReader reader = new BoardReader();
            Board board = reader.ReadBoard(boardPath);
            BoardPrinter printer = new BoardPrinter();
            Game game = new Game(board, printer);
            game.Play();
        }
    }
}
