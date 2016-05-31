using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class CriacaoTerraPlantio : CriacaoTerra
    {
        public override void criarTerra(Terra terra)
        {
            TerraPlantio terrasPlantio = (TerraPlantio)terra;
            db.TerrasPlantios.Add(terrasPlantio);
            db.SaveChanges();
            base.criarTerra(terra);
        }

        public override void excluirTerra(Terra terra)
        {
            TerraPlantio terrasPlantio = (TerraPlantio)terra;
            db.TerrasPlantios.Attach(terrasPlantio);
            db.TerrasPlantios.Remove(terrasPlantio);
            db.SaveChanges();
            base.excluirTerra(terra);
        }
    }
}