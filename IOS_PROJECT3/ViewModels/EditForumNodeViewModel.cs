﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOS_PROJECT3.ViewModels
{
    public class EditForumNodeViewModel
    {
        [Required(ErrorMessage = "Не указано название")]
        public string NodeName { get; set; }
        public string NodeId { get; set; }
    }
}
