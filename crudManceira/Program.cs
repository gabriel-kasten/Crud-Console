using System;

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

            string prompt = "Bem vindo à sua Pokedex, o que gostaria de fazer?";
            string[] options = { "Gotta Catch'Em All", "Pokedex", "Exit" };

            Menu MainMenu = new Menu(prompt, options);
            int selectedIndex = MainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
            }

            Console.ReadKey(true);
        }
    }
}
