﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOS_PROJECT3.Models
{
    public class EForumNode
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string CreatorEmail { get; set; }
        public string CreatorFio { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public EForumNode ParentNode { get; set; }
        public List<EForumNode> ChildNodes { get; set; }
        public List<EForumEndpoint> ChildEndpoints { get; set; }
    }
}
