using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DemoAutoMigration.Models
{
    [Table("Job")]
    public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Job_Id")]
        public int id { get; set; }
        [Column("Job_Name")]
        [Required]
        public string jobName { get; set; }
        [Column("Salary")]
        public string salary { get; set; }
        [Column("Created_By")]
        public int createdBy { get; set; }
        [Column("Date_Created")]
        public DateTime dateCreated { get; set; }
        [Column("Last_Update")]
        public DateTime lastUpdate { get; set; }
        [Column("Description")]
        [AllowNull]
        public string description { get; set; }
        [Column("Category_Id")]
        public string categoryId;
        [Column("Is_Active")]
        public bool isActive { get; set; }
        [Column("Is_Delete")]
        public bool isDelete { get; set; }
    }
}
