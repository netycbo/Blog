﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_AppServices.API.DTO
{
    public class NewPostDto
    {
        public string PostedDate { get; set; }
        public int UserId { get; set; }
        public string Topic { get; set; }

    }
}
    

