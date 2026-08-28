using System;
using System.IO;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Encargado de la lectura e interpretación de archivos de texto para construir la instancia inicial de un tablero.
    /// 
    /// Justificación de Principios de Diseño:
    /// - SRP (Single Responsibility Principle): Su única razón de cambio son las modificaciones en el formato del archivo 
    ///   de origen o en el mecanismo de Entrada/Salida para obtener la configuración inicial. Permite que la simulación cambie 
    ///   de fuente de datos sin afectar a la clase Board.
    /// - Expert (Information Expert): Es el experto en la estructura del archivo de texto y en cómo convertir la cadena de 
    ///   caracteres ('1' y '0') a la estructura de matriz de datos necesaria para instanciar el tablero.
    /// </summary>

    public class BoardLoader
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="BoardLoader"/>.
        /// </summary>
        public BoardLoader()
        {
        }

        /// <summary>
        /// Lee un archivo de texto desde la ruta especificada y genera un objeto <see cref="Board"/> cargado con su estado inicial.
        /// </summary>
        /// <param name="filePath">Ruta del archivo de texto que contiene el tablero representado con caracteres '1' y '0'.</param>
        /// <returns>Una nueva instancia de <see cref="Board"/> configurada con los datos del archivo.</returns>
        public Board LoadFromFile(string filePath)
        {
            // Normalizamos los saltos de línea (\r\n / \n)
            string content = File.ReadAllText(filePath).Replace("\r", "");
            string[] lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            int height = lines.Length;
            int width = lines[0].Length;
            bool[,] initialGrid = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (lines[y][x] == '1')
                    {
                        initialGrid[x, y] = true;
                    }
                }
            }

            return new Board(initialGrid);
        }
    }
}