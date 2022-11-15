using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using static System.Console;

namespace crudManceira
{
    internal class Database
    {
        List<Pokemon> pokemons = new List<Pokemon>();
        public Rootobject getPokemonInfo(string _pokemon)
        {

            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
            var request = new RestRequest(_pokemon);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Rootobject data = JsonConvert.DeserializeObject<Rootobject>(rawResponse);

                return data;
            } else { return null; }
        }


        public void getAllPokemons()
        {
            int counter = 0;
            foreach (Pokemon _pokemon in pokemons)
            {
                counter++;
                WriteLine($"[{ counter }] - {_pokemon.Name}");
            }
        }

        public void addtPokemon()
        {

        }

        public void updatePokemon()
        {

        }

        public void deletePokemon()
        {

        }
    }
}