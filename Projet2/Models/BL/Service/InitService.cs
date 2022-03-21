using Projet2.Models.BL.Interface;
using System.IO;

namespace Projet2.Models.BL.Service
{
    public class InitService : IInitService
    {
        private IAuthentificationService authentificationService;
        private BddContext _bddContext;

        public InitService()
        {
            this.authentificationService = new AuthentificationService();
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public void InitializeDB()
        {
            DeleteCreateDatabase();
            _bddContext.Address.Add(new Address { Id = 1, RoadNumber = "2", Road = "Rue de bel air", City = "Saint-Pryvé-Saint-Mesmin", PostalCode = "45750", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 2, RoadNumber = "3", Road = "Avenue de la république", City = "Angers", PostalCode = "49000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 3, RoadNumber = "4", Road = "Rue du paradis", City = "Le Mans", PostalCode = "72000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 4, RoadNumber = "5", Road = "Rue du général de gaulle", City = "Bordeaux", PostalCode = "33000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 5, RoadNumber = "6", Road = "Rue du général", City = "Paris", PostalCode = "75000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 6, RoadNumber = "7", Road = "Rue du caporal", City = "Grenoble", PostalCode = "38000", Country = "France" });

            _bddContext.Member.Add(new Member { Id = 1, Firstname = "Damien", Lastname = "Parmenon", Mail = "parmenon.damien@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Admin", AddressId = 1, Role = "Administrator" });

            _bddContext.Association.Add(new Association { Id = 1, AddressId = 2, Name = "Petits Prince", IsPublished = true, Description = "Description1", Image = File.ReadAllText("wwwroot/init/asso1.txt"), AssociationRepresentativeId = 1, Mail = "asso1@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 2, AddressId = 3, Name = "WWF", IsPublished = true, Description = "Description2", Image = File.ReadAllText("wwwroot/init/asso2.txt"), AssociationRepresentativeId = 1, Mail = "asso2@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 3, AddressId = 4, Name = "Association Hirondelle", IsPublished = true, Description = "Description3", Image = File.ReadAllText("wwwroot/init/asso3.txt"), AssociationRepresentativeId = 1, Mail = "asso3@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 4, AddressId = 5, Name = "Tous Au Sport", IsPublished = true, Description = "Description3", Image = File.ReadAllText("wwwroot/init/asso4.txt"), AssociationRepresentativeId = 1, Mail = "asso4@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 5, AddressId = 6, Name = "Sidaction", IsPublished = true, Description = "Description3", Image = File.ReadAllText("wwwroot/init/asso5.txt"), AssociationRepresentativeId = 1, Mail = "asso4@gmail.com" });
            _bddContext.SaveChanges();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
