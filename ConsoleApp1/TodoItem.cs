using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    [Table("TodoItems")]
    public class TodoItem
    {
        [Key]
        [Column]
        public long Id { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public bool IsCompleted { get; set; }
    }
}
