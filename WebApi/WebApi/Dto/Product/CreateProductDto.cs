﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Dto.Product
{
    public class CreateProductDto 
    {
        public CreateProductDto()
        {
            DateRegister = DateTime.Now;
        }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public DateTime DateRegister { get; set; }

    }
}
