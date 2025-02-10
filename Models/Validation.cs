using System;
using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class Validation
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le genre est obligatoire")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string Adresse { get; set; } 

        [Required(ErrorMessage = "Le code postal est obligatoire")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "La ville est obligatoire")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Adresse e-mail invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La date de début de formation est obligatoire")]
        public DateTime DateDebFormation { get; set; }

        [Required(ErrorMessage = "La formation est obligatoire")]
        public string Formation { get; set; }

        public string? AvisCobol { get; set; } // Peut être null
        public string? AvisCsharp { get; set; } // Peut être null
    }
}

