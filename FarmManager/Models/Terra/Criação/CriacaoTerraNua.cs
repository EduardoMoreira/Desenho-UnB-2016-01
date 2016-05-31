using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class CriacaoTerraNua : CriacaoTerra
    {
        public override void criarTerra(Terra terra)
        {
            TerraNua terrasNua = (TerraNua)terra;
            db.TerrasNuas.Add(terrasNua);
            db.SaveChanges();
            base.criarTerra(terra);
        }

        public override void excluirTerra(Terra terra)
        {
            TerraNua terrasNua = (TerraNua)terra;
            db.TerrasNuas.Attach(terrasNua);
            db.TerrasNuas.Remove(terrasNua);
            db.SaveChanges();
            base.excluirTerra(terra);
        }
    }
}