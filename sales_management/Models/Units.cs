﻿using System.ComponentModel.DataAnnotations.Schema;

namespace sales_management.Models
{
    public class Units
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public virtual List<products> products { get; set; }

    }
}
