using Microsoft.AspNetCore.Http;
using Projet2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Projet2.ViewModels
{
    public class AssociationEventInfoViewmodel
    {
        public AssociationEvent AssociationEvent { get; set; }
        public List<AssociationEvent>AssociationEventsList { get; set; }
        public Address Address { get; set; }

        [Display(Name = "Image :")]

        [Required(ErrorMessage = "Aucune image n'est fournie")]
        public IFormFile File { get; set; }


        public List<Association> AssociationList { get; set; }


        
        public int SelectedAssociationId { get; set; }

        public int TicketsNumber { get; set; }






    }
}
