﻿using Microsoft.OpenApi.Models;

namespace FundooNotes
{
    internal class AppInfo : OpenApiInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
}