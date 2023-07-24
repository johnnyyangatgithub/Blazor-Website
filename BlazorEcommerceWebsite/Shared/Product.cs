using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerceWebsite.Shared
{
	public class Product
	{
        public int ID { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        public bool Featured { get; set; } = false;

        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public bool Visbile { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}

