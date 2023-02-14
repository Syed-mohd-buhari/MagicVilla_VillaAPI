﻿using static MagicVilla_Utility.SD;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_WEB.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
