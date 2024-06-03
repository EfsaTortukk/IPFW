using System.ComponentModel.DataAnnotations;

namespace Internet_Programlama_Final_Work.Models
{
    public class Logincs
    {
        [Key]
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool LoggedStatus { get; set; }
        }
}
