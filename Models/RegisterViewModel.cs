using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

    namespace Internet_Programlama_Final_Work.Models
    {
        public class RegisterViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool LoggedStatus { get; set; }
        }
    }


