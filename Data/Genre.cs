﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Genre : BaseEntity
    {
        public string? Name { get; set; }
        public List<Film>? Films { get; set; }
    }
}
