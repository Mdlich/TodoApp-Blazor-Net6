using System;
using System.Collections.Generic;

namespace TodoApp.API.Data
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TodoUserId { get; set; }
    }
}
