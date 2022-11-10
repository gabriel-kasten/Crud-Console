namespace crudManceira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            string prompt = "Bem vindo à sua Pokedex, o que gostaria de fazer?\n*use as setas e enter para selecionar*";
            string[] options = { "Gotta Catch'Em All", "Pokedex", "Exit" };
            string[] pokedex = { "Eu escolho você", "Novo Aleatório", "Sair" };
            Menu mainMenu = new Menu(prompt, options);
            while (run)
            {
                int selectedIndex = mainMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        mainMenu.StartPokedex();

                        Menu pokedexMenu = new Menu("", pokedex);
                        pokedexMenu.Run();

                        break;
                    case 1:

                        break;
                    case 2:
                        run = mainMenu.Exit();
                        break;
                }
            }
        }
    }
}
