//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            string boardPath = Path.Combine(folder, "board.txt");
            
            // Leer el tablero del archivo
            BoardReader reader = new BoardReader(boardPath);
            bool[,] initialBoard = reader.Read();
            
            // Crear el tablero del juego
            GameBoard gameBoard = new GameBoard(initialBoard);
            
            // Crear el impresor
            BoardPrinter printer = new BoardPrinter();
            
            // Bucle infinito: imprimir, calcular siguiente generación, esperar
            while (true)
            {
                Console.Clear();
                printer.Print(gameBoard);
                gameBoard.NextGeneration();
                Thread.Sleep(300);
            }
        }
    }
}
