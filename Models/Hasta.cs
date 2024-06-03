namespace Internet_Programlama_Final_Work.Models
{
    public class Hasta
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public int Yas { get; set; }

        // Sorumlu doktor ve lab görevli ilişkileri
        public int? SorumluDoktorId { get; set; }

        public Doktor SorumluDoktor { get; set; }
        public int? SorumluHemsireId { get; set; }
        public Hemsire SorumluHemsire { get; set; }

    }
}
