using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DemoAutoMigration.DTO
{
    public class JobDTO
    {
        public int id { get; set; }
        public string? jobName { get; set; }
        public string? salary { get; set; }
        public string? createdBy { get; set; }
        public string? dateCreated { get; set; }
        public string? lastUpdate { get; set; }
        public string? description { get; set; }
        public string[]? categoryName { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
