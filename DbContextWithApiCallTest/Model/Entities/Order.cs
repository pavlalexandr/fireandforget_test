using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbContextWithApiCallTest.Model.Entities
{
    
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? Status { get; set; }
        public DateTime Updated { get; set; }
    }
}
