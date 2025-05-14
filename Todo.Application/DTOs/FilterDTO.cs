using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.DTOs
{
    public class FilterDTO
    {
        public string? SearchText { get; set; }
        public DateTime? dueDate { get; set; }
        public bool? IsComplete { get; set; }
        public bool? isDeleted { get; set; }
    }
}
