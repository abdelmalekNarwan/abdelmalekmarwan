﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmanaTechnology.Dto
{
    public class CreateOrEditeDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}