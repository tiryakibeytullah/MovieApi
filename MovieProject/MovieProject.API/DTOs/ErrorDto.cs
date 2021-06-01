﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<String> Errors { get; set; }
        public int Status { get; set; }
    }
}
