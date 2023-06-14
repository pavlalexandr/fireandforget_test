using System.ComponentModel.DataAnnotations;

namespace DbContextWithApiCallTest.Dto
{
    public class OrderRequest
    {
        [Required]
        public int Id { get; set; }
        public string? Status { get; set; }
    }
}
