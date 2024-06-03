using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internet_Programlama_Final_Work.Models
{
    public class Sonuc
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }

        [Display(Name = "Fotoğraf")]
        public string FotografDosyasi { get; set; } // Dosya adını burada saklayacağız

        [NotMapped]
        public IFormFile Fotograf { get; set; } // Kullanıcı tarafından yüklenen dosya

        public int HastaId { get; set; }
        public Hasta Hasta { get; set; } // Foreign Key relationship with Hasta table

        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; } // Foreign Key relationship with Doktor table

        public int HemsireId { get; set; }
        public Hemsire Hemsire { get; set; } // Foreign Key relationship with LabGorevli table
    }
}
