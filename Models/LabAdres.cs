namespace Internet_Programlama_Final_Work.Models
{
    public class LabAdres
    {
        public int Id { get; set; }
        public string Ad { get; set; } // Lab name
        public string KoridorNo { get; set; } // Corridor number (optional)
        public int KatNo { get; set; } // Floor number
        public string TelefonNo { get; set; } // Lab phone number
    }
}
