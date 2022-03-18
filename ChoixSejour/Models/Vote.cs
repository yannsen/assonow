using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int? UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

        public int? SejourId { get; set; }
        public virtual Sejour Sejour { get; set; }

        public int? SondageId { get; set; }
        public virtual Sondage Sondage { get; set; }
    }
}
