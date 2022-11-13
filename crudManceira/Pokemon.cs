using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing.Drawing2D;
using static System.Console;

namespace crudManceira
{
    internal class Pokemon
    {
        public void getPokemonData(string pokemon)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            var request = new RestRequest(pokemon);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Rootobject data = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                string front_default = data.sprites.front_default;
                PokemonImage.ConvertImg(front_default.ToString());

                WriteLine($"\nName: {data.name}");
                WriteLine($"Id: {data.id}");
                WriteLine($"Hp: {data.stats[0].base_stat}");
                getPokemonElements(data);
                WriteLine($"Attack: {data.stats[1].base_stat}");
                WriteLine($"Defense: {data.stats[2].base_stat}");

                ReadKey(true);

                //string[] pokedex = { "Salvar", "Novo Aleatório", "Sair" };
                //Menu pokedexMenu = new Menu(pokedex);
                //pokedexMenu.Run();
            }
            else
            {
                WriteLine("O pokemon não foi encontrado, tente digitar outro ou verifique a caligrafica");
                System.Threading.Thread.Sleep(3000);
            }
        }

        private static void getPokemonElements(Rootobject data)
        {
            if (data.types.Length > 1)
            {
                Write($"Types: ");
                for (int i = 0; i < data.types.Length; i++)
                {
                    string type = data.types[i].type.name;
                    Console.Write(type + " ");
                }
            }
            else
            {
                WriteLine("Type: " + data.types[0].type.name);
            }
        }

        public void getManceiramon()
        {
            string manceiramon = @"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&@&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&&&&@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@&##&&&@@@&&@@&@@@@@@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&&&@@@&&#GBGB###&@&&&&&&#&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&@&&&GPP5J?YGP5PB&&&##&#####&&@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&##B7::~!!7?YPGB##BBBBBBB###&&&&&B#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@#GG7.::^~~!7?Y5PGGGGGGGBB###&&&&&###&@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@#G5:.:^^^~~!7?J5PPPPPPGGB#########BB#&@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&G!..:^~!!!7?JJ5PGPPPPPGB#######BBBB#&@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@&#P..:!J5PGBBBGPPPGPPPPGB#&&@@&&&#GGGB#@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&7 .~!?Y5PGBBBGP555GB##&&@@@&&&@@&&BBB#@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@B..::~J5G#&###BP?7JG#&@@@@&&&&&@@@@&&#B&@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@&7.:^~JPYG&@&&&#P7!JP#&@@@@@@@@@@@@@@&&BB@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@7!:.^~~~!?YPGBBGY7~!JP#&@@@@&&&&@@&&&&##BB@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@YY..:^~!!7?Y55J!~^~7YPB#&@&&&&&&&&#BBGGBBB&@&@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@B?...:^~!7??77!!^:~?5GBBB&&&&&&##########B&&&@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@5...:^^~!!7?J5!^77JGB&&&#&&&&#####&&&&###&&@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@&:.::^^~!7?5GG?5&#PP#@@@&&&&&##&&&&&&&###&&@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@!.:::^~!?5PPYJJ55PB#&@@@@&&&##&&&&&&&####&@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@7:::^~!?JYYJ?JJJYB#G#&@@@&&&&&&&&&&&&###B&@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@B^:^~!7JJJYY??JYYPGB#&&&@@@@&&&&&&&&&&##&@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@5.^~7?J5GBB5YY5GGB#&&&@@@@@&&&&&&&&&&#&@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@!^~7?YG##GJ?JPB####&&&@@@@&&&&&@@@&&&@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@#~!7JPGGYJJY5GB#&&&&&&&&&&&&&&@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@G!?YPG5YYYY55PGB##&&&&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P?YPPY??JY55GBB##&&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5^J5P5??Y5PGB##&&&&@@@@@@@@@@@@&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@B^:~75PP5PGGB#&&&&&@@@@@@@@@@@@&##@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@&?77::~!7JY5PGGB##&&&&&@@@@@@@@@@&&&#&&B&@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@5:~JJ^:^~7?JY55PGBB#&&&&&@@@@@@@@&&&&##@#GG&@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@&GJ~^:7YY~^^~!7?JYY55PGB##&&&&&@@@@@&&&&&&&&##BBB&@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@#PYY7^~^~JY55!~~!7?JYYYY55PGB#&&&&&&&&&&&&&&#B####BBBB#&&@@@@@@@@@@@@@@@@
@@@@@@@@@@@@&#P5Y!!5GJ~~^7Y55PJ~!!7?JYYYYYY5PGB#&&&&&&&&&&&BGG########BB##GB#&@@@@@@@@@@@@
@@@@@&BGY7G5??JY?~?GGY!~!J5555Y~:^~~7?YYYY55PGB##&&&&&##BGGGB&&##########&BGBBGB##&&@@@@@@
G5YYYYP577PBPP5Y77YGPG7~!YP555PPJ^:.::^!!7?JJY5PPPPPPPPPGGB###&&&&######&&#BB##BBBBBBB#&@@
^:!5GGPJ!75GGP5J??5GPG?~7YY5P55PG5!::::^^~~!!77???JYY5PPPPB########&&&#&&&&#BB###BB##BGG@@";
            WriteLine(manceiramon);
            WriteLine($"\nName: Manceiramon");
            WriteLine($"Id: 999");
            WriteLine($"Hp: 999");
            WriteLine("Lendary Psychic");
            WriteLine($"Attack: 999");
            WriteLine($"Defense: 999");

            ReadKey(true);
        }
    }

    public class Rootobject
    {
        public int id { get; set; }
        public string name { get; set; }
        public Sprites sprites { get; set; }
        public Stat[] stats { get; set; }
        public Type[] types { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public class Stat
    {
        public int base_stat { get; set; }
    }

    public class Type
    {
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
    }

    public class Type2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
