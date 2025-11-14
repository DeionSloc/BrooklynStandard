using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BrooklynStandard.Models.Data

{
    [Table("request_data")]
    public class UserRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("number")]
        public int? Number { get; set; }

        [Column("company")]
        public string? Company { get; set; }

        [Column("file")]
        public IFormFile? File { get; set; }


        [Column("request")]
        public string? Request { get; set; }
    }
}