﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOS_PROJECT3.ViewModels
{
    public class MassRegViewModel
    {
        public int Count { get; set; }
        public IList<string> FIOs { get; set; }
        public IList<string> Emails { get; set; }
        public IList<string> Passwords { get; set; }
        public IList<string> Roles { get; set; }
    }
}
