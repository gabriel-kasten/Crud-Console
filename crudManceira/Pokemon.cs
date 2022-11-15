using System;

namespace crudManceira
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Hp { get; set; }
        public string Stats { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }

        public Pokemon(string _name, int _id, int _hp, string _stats, int _attack, int _defence)
        {
            this.Name = _name;
            this.Id = _id;
            this.Hp = _hp;
            this.Stats = _stats;
            this.Attack = _attack;
            this.Defence = _defence;
        }
    }
}
