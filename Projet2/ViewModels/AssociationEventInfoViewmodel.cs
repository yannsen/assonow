using Projet2.Models;
using System.ComponentModel.DataAnnotations;


namespace Projet2.ViewModels
{
    public class AssociationEventInfoViewmodel
    {
        public AssociationEvent AssociationEvent { get; set; }
        public Address Address { get; set; }
    }
}
