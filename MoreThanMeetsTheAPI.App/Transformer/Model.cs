using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Transformer {
    public class Model {

        public string? Name { get; set; }
        public string? Faction { get; set; }
        public IEnumerable<int> AltModes { get; set; } = new List<int>();
        public IEnumerable<int> Groups { get; set; } = new List<int>();
        public IEnumerable<int> Weapons { get; set; } = new List<int>();
        public IEnumerable<int> Abilities { get; set; } = new List<int>();
        public IEnumerable<int> Appearances { get; set; } = new List<int>();
        public DateTime? Created { get; set; }
        public int? Id { get; set; }

        //public Dto(
        //    string name, 
        //    string faction, 
        //    List<int> altModes, 
        //    List<int> groups, 
        //    List<int> weapons, 
        //    List<int> abilities, 
        //    List<int> appearances, 
        //    DateTime created, 
        //    int id) {

        //    this.name = name;
        //    this.faction = faction;
        //    this.altModes = altModes;
        //    this.groups = groups;
        //    this.weapons = weapons;
        //    this.abilities = abilities;
        //    this.appearances = appearances;
        //    this.created = created;
        //    this.id = id;
        //}
    }
}
