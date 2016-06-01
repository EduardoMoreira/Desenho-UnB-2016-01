using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class TerraPlantio : Terra
    {
        [Required(ErrorMessage = "Digite a data de plantio!")]
        [Display(Name = "Data de Plantio")]
        [DataType(DataType.Date)]
        public DateTime DTPlantio { get; set; }

        [Display(Name = "Data de Colheita")]
        [DataType(DataType.Date)]
        public DateTime? DTColheita { get; set; }

        [Display(Name = "Tipo de Grão")]
        public TipoGrao TPGrao { get; set; }
    }
}