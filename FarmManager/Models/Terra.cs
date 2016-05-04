﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class Terra
    {
        [Key]
        public int CDTerra { get; set; }
        public int NRHectares { get; set; }
    }
}