using System;
using System.Security.Authentication.ExtendedProtection;

namespace crudManceira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Digite o nome de um pokemon: ");
            //string name = Console.ReadLine();
            //Pokemon pokemon = new Pokemon();
            //pokemon.getPokemonData(name);

            Pokemon pokemon = new Pokemon();

            string prompt = "Bem vindo à sua Pokedex, o que gostaria de fazer?";
            string[] options = { "Gotta Catch'Em All", "Pokedex", "Exit" };

            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    menu.StartPokedex();
                    break;
                case 1:
                    break;
            }

            Console.ReadKey(true);
        }
    }
}
