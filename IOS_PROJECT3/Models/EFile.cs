﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOS_PROJECT3.Models
{
    public class EFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public virtual EUser UserLoad { get; set; }
        public  string DateLoad { get; set; }
    }
}
