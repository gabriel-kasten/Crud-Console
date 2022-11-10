using Newtonsoft.Json;
using RestSharp;
using System;
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
