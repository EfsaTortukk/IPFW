using System;
using System.ComponentModel.DataAnnotations;

namespace Internet_Programlama_Final_Work.Models
{
    public class Hemsire
    {
        public int Id { get; set; }

        [Display(Name = "Hemşire Adı")]
        [Required(ErrorMessage = "Hemşire adı gereklidir.")]
        public string AdSoyad { get; set; }

        [Display(Name = "Bölüm")]
        public string Bölüm { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string Telefon { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "İşe Başlama Tarihi")]
        [DataType(DataType.Date)]
        public DateTime İşeBaşlamaTarihi { get; set; }

        // İsteğe bağlı olarak diğer özellikler eklenebilir.
    }
}
