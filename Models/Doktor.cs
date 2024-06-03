using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;

namespace Internet_Programlama_Final_Work.Models
{
    public class Doktor
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; } // Combined name and surname

        public string UzmanlikAlani { get; set; } // Doctor's specialization

        public string? DoktorPhoto { get; set; }
        [NotMapped]
        [DisplayName("Upload Image File")]
        public IFormFile? ImageFile { get; set; }

        public string Numara { get; set; } // Doctor's phone number

        public string Email { get; set; } // Doctor's email address

        public ICollection<Sonuc>? Sonuclar { get; set; } // Navigation property for a collection of Sonuc objects
    }
}
