namespace crudManceira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string prompt = "Bem vindo à sua Pokedex, o que gostaria de fazer?\n*use as setas e enter para selecionar*";
            string[] options = { "Gotta Catch'Em All", "Pokedex", "Sair" };

            bool run = true;

            Menu mainMenu = new Menu(options, prompt);
            Database db = new Database();

            while (run)
            {
                int selectedIndex = mainMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        mainMenu.SearchPokemon();
                        break;
                    case 1:
                        db.getAllPokemons();
                        break;
                    case 2:
                        run = false;
                        break;
                }
            }
        }
    }
}