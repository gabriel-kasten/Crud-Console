using Newtonsoft.Json;
using RestSharp;
using System;
using System.Runtime.InteropServices;

namespace crudManceira
{
    internal class Pokemon
    {
        public static string getPokemon(string pokemon)
        {
            return pokemon;
        }
        public static void getPokemonData(string pokemon)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            var request = new RestRequest(pokemon);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Rootobject data = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                Console.WriteLine($"Name: {data.name}");
                Console.WriteLine($"Id: {data.id}");
                Console.WriteLine($"Hp: {data.stats[0].base_stat}");
                getTypes(data);
                Console.WriteLine($"Attack: {data.stats[1].base_stat}");
                Console.WriteLine($"Defense: {data.stats[2].base_stat}");
            }
        }

        public static void getTypes(Rootobject data)
        {
            if (data.types.Length > 1)
            {
                Console.Write($"Types: ");
                for (int i = 0; i < data.types.Length; i++)
                {
                    string type = data.types[i].type.name;
                    Console.Write(type + " ");
                }
                Console.WriteLine(" ");
            } else
            {
                Console.WriteLine(data.types[0].type.name);
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

    //public class Animated
    //{
    //    public string back_default { get; set; }
    //    public string back_female { get; set; }
    //    public string back_shiny { get; set; }
    //    public string back_shiny_female { get; set; }
    //    public string front_default { get; set; }
    //    public string front_female { get; set; }
    //    public string front_shiny { get; set; }
    //    public string front_shiny_female { get; set; }
    //}

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
