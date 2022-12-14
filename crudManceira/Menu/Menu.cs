using System;
using static System.Console;

namespace crudManceira
{
    internal class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string[] options, string prompt = "")
        {
            this.Prompt = prompt;
            this.Options = options;
            this.SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = " > ";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} {currentOption}");
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
        Database db = new Database();
        public void SearchPokemon()
        {
            PokemonMenu pokedex = new PokemonMenu();
            Clear();
            Write("Give the pokemon name: ");
            string _pokemon = ReadLine();
            _pokemon.ToLower();
            if (_pokemon == "")
            {
                Clear();
                WriteLine("Digite o nome de algum pokemon.");
                System.Threading.Thread.Sleep(3000);
            }
            else if (_pokemon == "manceira")
            {
                Clear();
                pokedex.displayManceiramon();
            }
            else
            {
                Rootobject pokemonData = db.getPokemonInfo(_pokemon);
                if (pokemonData == null)
                {
                    WriteLine("Erro");
                }
                else
                {
                    pokedex.displayPokemonInfo(pokemonData);
                }
            }
        }
    }
}