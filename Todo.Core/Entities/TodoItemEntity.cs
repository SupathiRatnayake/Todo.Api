using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Entities
{
    public class TodoItemEntity
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public bool IsDeleted { get; set; }
    }
}
