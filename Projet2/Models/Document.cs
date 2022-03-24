using System.ComponentModel;

namespace Projet2.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Type { get; set; }

        [DefaultValue("")]
        public string Path { get; set; }

        public int AssociationId { get; set; }

        public Association Association { get; set; }
    }
}
