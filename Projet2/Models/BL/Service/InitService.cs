using Projet2.Models.BL.Interface;
using System;
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

            _bddContext.Association.Add(new Association { Id = 1, AddressId = 2, Name = "Petits Princes", IsPublished = true, Description = "L'Association Petits Princes est une association à but non lucratif créée en 1987 qui s'est donné pour but de réaliser les rêves d’enfants et adolescents malades atteints de cancers, leucémies et certaines maladies génétiques.", Image = "/FileSystem/Pictures/petitprince.jpg", AssociationRepresentativeId = 1, Mail = "asso1@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 2, AddressId = 3, Name = "WWF", IsPublished = true, Description = "Le WWF ou Fonds mondial pour la nature est une organisation non gouvernementale internationale (ONGI) créée en 1961, vouée à la protection de l'environnement et au développement durable.", Image = "/FileSystem/Pictures/wwf.png", AssociationRepresentativeId = 2, Mail = "asso2@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 3, AddressId = 4, Name = "Association Hirondelle", IsPublished = true, Description = "Créée il y a plus de 25 ans, l’association Hirondelle est une association reconnue dans le domaine de la protection de l’environnement dans la région du Pays de Retz.", Image = "/FileSystem/Pictures/associationhirondelle.jpg", AssociationRepresentativeId = 2, Mail = "asso3@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 4, AddressId = 5, Name = "Tous Au Sport", IsPublished = false, Description = "Cette association loi 1901 à but non lucratif, constituée le 25 juillet 2016, a pour objet de permettre l'accès le plus grand possible au sport à toutes et à tous et cela dans le cadre des cours collectifs.", Image = "/FileSystem/Pictures/tousausport.png", AssociationRepresentativeId = 3, Mail = "asso4@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 5, AddressId = 6, Name = "Sidaction", IsPublished = false, Description = "Sidaction désigne à la fois une association de lutte contre le VIH/sida, créée en 1994 et un évènement télévisuel annuel de collecte de dons pour cette association qui finance à parts égales des programmes de recherche et des associations d’aide aux malades et de prévention, en France et à l’international. Pierre Bergé présidait l'association.", Image = "/FileSystem/Pictures/sidaction.jpg", AssociationRepresentativeId = 1, Mail = "asso4@gmail.com" });

            //YS 
            _bddContext.Member.Add(new Member { Id = 2, Firstname = "Yann", Lastname = "Senic", Mail = "ysenic@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Repr1", AddressId = 2, Role = "Representative" });
            _bddContext.Member.Add(new Member { Id = 3, Firstname = "Fatoumata", Lastname = "F", Mail = "f@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Repr2", AddressId = 2, Role = "Representative" });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 1, AssociationId = 3, MemberId =2});
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 2, AssociationId = 4, MemberId = 2 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 3, AssociationId = 5, MemberId = 2 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 1, EventTitle = " Concert des petits Princes",Description="Le plus grand concert javmais vu avec Rammstein", Image = "/FileSystem/Pictures/aigles.jpeg", Date = new DateTime(2022, 03, 24), EventType ="Concert", Speakers ="Al Capone", Artists=" Rammstein",TicketsTotalNumber=3210,AddressId=1,AssociationId=1, TicketPrice = 14 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 2, EventTitle = " Concert des WWE", Description = "Le plus grand concert ou cela va se bastonner", Image = "/FileSystem/Pictures/butterfly17532.jpg", Date = new DateTime(2022, 03, 24), EventType = "Concert", Speakers = "Al Bundy", Artists = " Croix de bois", TicketsTotalNumber = 2350, AddressId = 2, AssociationId = 4,TicketPrice = 12 });
            //YS End


            _bddContext.Document.Add(new Document { Id = 1, AssociationId = 4, Type = "OfficialJournalPublication", Path = "../FileSystem/Documents/Publication1.pdf" });
            _bddContext.Document.Add(new Document { Id = 2, AssociationId = 4, Type = "BankDetails", Path = "../FileSystem/Documents/RIB1.pdf" });
            _bddContext.Document.Add(new Document { Id = 3, AssociationId = 4, Type = "ID", Path = "../FileSystem/Documents/ID1.pdf" });

            _bddContext.Fundraising.Add(new Fundraising { Id = 1, AssociationId = 1, Name = "Des armes pour l'ukraine", Description = "Description1", IsActive = true, CurrentAmount = 0, DesiredAmount = 10000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Humanitaire"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 2, AssociationId = 1, Name = "Sauvez les éléphants", Description = "Description2", IsActive = true, CurrentAmount = 1500, DesiredAmount = 20000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Sport"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 3, AssociationId = 2, Name = "Aide aux victimes", Description = "Description3", IsActive = true, CurrentAmount = 500, DesiredAmount = 15000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Culture"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 4, AssociationId = 2, Name = "Blocage mine d'or", Description = "Description4", IsActive = true, CurrentAmount = 0, DesiredAmount = 18000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Enseignement"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 5, AssociationId = 3, Name = "Construction hopital", Description = "Description5", IsActive = true, CurrentAmount = 0, DesiredAmount = 5000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Défense des droits"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 6, AssociationId = 3, Name = "Achat lot de maillot", Description = "Description6", IsActive = true, CurrentAmount = 3000, DesiredAmount = 10000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Humanitaire"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 7, AssociationId = 4, Name = "Stop aux ailerons de requin !", Description = "Description7", IsActive = true, CurrentAmount = 50, DesiredAmount = 75000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Recherche"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 8, AssociationId = 4, Name = "Recherche scientifique", Description = "Description8", IsActive = true, CurrentAmount = 1, DesiredAmount = 100000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Humanitaire"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 9, AssociationId = 5, Name = "J'ai plus d'idée !", Description = "Description9", IsActive = true, CurrentAmount = 2500, DesiredAmount = 10000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Culture"});
            _bddContext.Fundraising.Add(new Fundraising { Id = 10, AssociationId = 5, Name = "J'ai plus d'idée !", Description = "Description10", IsActive = false, CurrentAmount = 0, DesiredAmount = 15000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Loisirs"});
            _bddContext.SaveChanges();
        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
