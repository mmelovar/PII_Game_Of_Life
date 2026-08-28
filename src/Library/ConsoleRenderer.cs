using System;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Encargado de renderizar el estado del tablero en la consola del sistema.
    /// 
    /// Justificación de Principios de Diseño:
    /// - SRP (Single Responsibility Principle): Su única razón de cambio es una modificación en la capa de presentación 
    ///   o la interfaz gráfica en consola (por ejemplo, alterar los caracteres visuales '|X|' por otros símbolos). Aísla 
    ///   al resto de la biblioteca de la interacción directa con Console.
    /// - Expert (Information Expert): Conoce el formato y la sintaxis requerida por la interfaz de salida por consola, 
    ///   recibiendo la información de la instancia de Board únicamente a través de su interfaz pública para dibujar su estado.
    /// </summary>

    public class ConsoleRenderer
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConsoleRenderer"/>.
        /// </summary>
        public ConsoleRenderer()
        {
        }

        /// <summary>
        /// Imprime en la consola la representación visual actual del tablero recibido.
        /// </summary>
        /// <param name="board">Instancia de <see cref="Board"/> que contiene el estado actual a representar.</param>
        public void Render(Board board)
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if (board.IsAlive(x, y))
                    {
                        sb.Append("|X|");
                    }
                    else
                    {
                        sb.Append("___");
                    }
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}