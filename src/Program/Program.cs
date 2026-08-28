//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Clase principal que contiene el punto de entrada del programa.
    /// Inicializa la simulación del Juego de la Vida y controla el bucle ejecutor.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        /// <param name="args">Argumentos de la línea de comandos.</param>
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            string boardPath = Path.Combine(folder, "board.txt");

            BoardLoader loader = new BoardLoader();
            Board board = loader.LoadFromFile(boardPath);
            ConsoleRenderer renderer = new ConsoleRenderer();

            while (true)
            {
                renderer.Render(board);
                board.Step();
                Thread.Sleep(300);
            }
        }
    }
}


