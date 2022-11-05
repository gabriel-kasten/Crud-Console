using System;

namespace crudManceira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.Write("Digite o nome de um pokemon: ");
            string pokemon = Console.ReadLine();
            Pokemon.getPokemonData(pokemon);

            Console.ReadLine();
        }
    }
}
