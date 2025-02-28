﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIC_Demo_Project.Response
{
    public class ApiResponse
    {
        public string statusCode { get; set; } = "200";
        public string status { get; set; }
        public dynamic result { get; set; }
        public string message { get; set; }
        public PagingResponse PagingDetails { get; set; }

    }
   
}
