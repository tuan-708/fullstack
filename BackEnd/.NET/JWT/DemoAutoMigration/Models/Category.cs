using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAutoMigration.Models
{
    public class Category
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column("Category_Name")]
        public string name { get; set; }
        [Column("Is_Delete")]
        public bool isDelete { get; set; }
    }
}
