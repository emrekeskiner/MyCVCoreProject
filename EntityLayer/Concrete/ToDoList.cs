using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDoList
    {
        public int ToDoListId { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
    }
}
