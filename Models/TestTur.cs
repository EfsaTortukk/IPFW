namespace Internet_Programlama_Final_Work.Models
{
    public class TestTur
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string LabAdi { get; set; } // Name of the lab performing the test
        public bool AcTok { get; set; } // Indicates if the test requires fasting (Yes/No)
        public int SonucSuresi { get; set; } // Estimated time for test results (in days)
    }
}
