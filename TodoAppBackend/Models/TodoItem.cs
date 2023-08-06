using System.ComponentModel.DataAnnotations;

namespace TodoAppBackend.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}


