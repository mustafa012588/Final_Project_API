﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project_BL.Comman
{
    public class GeneralResult
    {
        public bool Success { get; set; }
        public ResultError[] Errors { get; set; } = [];
    }

    public class GeneralResult<T> : GeneralResult
    {
        public T? Data { get; set; }
    }

    public class ResultError
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
