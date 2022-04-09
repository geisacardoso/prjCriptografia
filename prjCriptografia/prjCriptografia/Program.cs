using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace prjCriptografia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            string texto;
            string codigo;
            Console.Write("Digite o texto:");
            texto = Console.ReadLine();
            codigo = Criptografia.Codificar(texto);
            Console.WriteLine("Texto Codigo:{0}", codigo);
            Console.WriteLine("Texto Codigo:{0}", Criptografia.Decodificar(codigo));
            Console.ReadKey();
        }
    }
}