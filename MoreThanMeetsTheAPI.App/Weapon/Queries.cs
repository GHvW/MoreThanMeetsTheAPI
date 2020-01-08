using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Weapon {
    public class Queries : IRepositoryQueries {

        public string GetAll { get; } = "SELECT * FROM weapon_view";

        public string GetById { get; } = "SELECT * FROM weapon_view WHERE id = @Id";
    }
}
