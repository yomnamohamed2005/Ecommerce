﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
  public class ProductBrand : BaseEntity<int>
    {
        public string name { get; set; }
    }
}