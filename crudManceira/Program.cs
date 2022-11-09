namespace crudManceira
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            string prompt = "Bem vindo à sua Pokedex, o que gostaria de fazer?\n*use as setas e enter para selecionar*";
            string[] options = { "Gotta Catch'Em All", "Pokedex", "Exit" };
            Menu menu = new Menu(prompt, options);
            while (run)
            {
                int selectedIndex = menu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        menu.StartPokedex();
                        break;
                    case 1:

                        break;
                    case 2:
                        run = menu.Exit();
                        break;
                }
            }
        }
    }
}
