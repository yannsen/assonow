using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Association
    {
        
        public int Id { get; set; }

        [Required]
        public int AssociationRepresentativeId { get; set; }

        public bool IsPublished { get; set; }
        public bool TicketService { get; set; }
        public bool DonationService { get; set; }
        public bool MemberService { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Required(ErrorMessage = "L'adresse mail est obligatoire")]
        [Display(Name = "Adresse mail :")]
        [RegularExpression(@"^[A-Za-z0-9+_.-]+@(.+)$", ErrorMessage = "L'adresse mail n'est pas valide")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [Display(Name = "Nom :")]
        public string Name { get; set; }

        [Display(Name = "Description :")]
        public string Description { get; set; }
        public string Image { get; set; }
        //public List<AssociationEvent> AssociationEvents { get; set; }
    }
}
