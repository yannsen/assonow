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


            InitializeDB_Members();

            InitializeDB_Associations();

            InitializeDB_AMembers();

            InitializeDB_AEvents();

            InitializeDB_Documents();

            InitializeDB_Fundraising();

            InitializeDB_Advices();

            InitializeDB_Adresses();


            _bddContext.SaveChanges();

        }


        // ORDER : 
        // Members  -> Associations -> Association's members -> Association's events -> Documents -> Fundraising -> Advices -> Adresses 

        // MEMBERS
        public void InitializeDB_Members()
        {
            // Administrators
            _bddContext.Member.Add(new Member { Id = 1, Firstname = "Damien", Lastname = "Parmenon", Mail = "parmenon.damien@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Admin", AddressId = 1, Role = "Administrator" });
            _bddContext.Member.Add(new Member { Id = 2, Firstname = "Antoine", Lastname = "Boulkeroua", Mail = "antoine.blk@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Atnblk", AddressId = 2, Role = "Administrator" });
            _bddContext.Member.Add(new Member { Id = 3, Firstname = "Yann", Lastname = "Senicourt", Mail = "ysenic@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "YnSenic", AddressId = 3, Role = "Administrator" });
            _bddContext.Member.Add(new Member { Id = 4, Firstname = "Fatoumata", Lastname = "Kanfana", Mail = "fkanfana@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "FaKanf", AddressId = 4, Role = "Administrator" });
            // LegalExperts
            _bddContext.Member.Add(new Member { Id = 5, Firstname = "Jean", Lastname = "Lexpert", Mail = "antoine.blk@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Exp1", AddressId = 5, Role = "LegalExpert" });
            // Representatives
            _bddContext.Member.Add(new Member { Id = 6, Firstname = "Jade", Lastname = "Arnold", Mail = "arnold@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Repr1", AddressId = 6, Role = "Representative" });
            _bddContext.Member.Add(new Member { Id = 7, Firstname = "Louise", Lastname = "Farina", Mail = "farina@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Repr2", AddressId = 7, Role = "Representative" });
            _bddContext.Member.Add(new Member { Id = 8, Firstname = "Alice", Lastname = "Lemelin", Mail = "femelin@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Repr3", AddressId = 8, Role = "Representative" });
            _bddContext.Member.Add(new Member { Id = 9, Firstname = "Jean", Lastname = "Beverly", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Repr4", AddressId = 9, Role = "Representative" });
            // Members
            _bddContext.Member.Add(new Member { Id = 10, Firstname = "Jade", Lastname = "Arnold", Mail = "arnold@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb1", AddressId = 10, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 11, Firstname = "Louise", Lastname = "Farina", Mail = "farina@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb2", AddressId = 11, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 12, Firstname = "Alice", Lastname = "Lemelin", Mail = "femelin@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb3", AddressId = 12, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 13, Firstname = "Jean", Lastname = "Beverly", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb4", AddressId = 13, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 14, Firstname = "Jade", Lastname = "Arnold", Mail = "arnold@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb5", AddressId = 14, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 15, Firstname = "Louise", Lastname = "Farina", Mail = "farina@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb6", AddressId = 15, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 16, Firstname = "Alice", Lastname = "Lemelin", Mail = "femelin@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb7", AddressId = 16, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 17, Firstname = "Jean", Lastname = "Beverly", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb8", AddressId = 17, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 18, Firstname = "Jean", Lastname = "Beverly", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb9", AddressId = 18, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 19, Firstname = "Jean", Lastname = "Beverly", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb10", AddressId = 19, Role = "Member" });
      
        }


        // ASSOCIATIONS
        public void InitializeDB_Associations()
        {
            // 1 -> 10
            _bddContext.Association.Add(new Association { Id = 1, Contribution = 50, AddressId = 20, Name = "Petits Princes", IsPublished = true, Description = "L'Association Petits Princes est une association à but non lucratif créée en 1987 qui s'est donné pour but de réaliser les rêves d’enfants et adolescents malades atteints de cancers, leucémies et certaines maladies génétiques.", Image = "/FileSystem/Pictures/petitprince.jpg", AssociationRepresentativeId = 1, Mail = "asso1@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 2, AddressId = 21, Name = "WWF", IsPublished = true, Description = "Le WWF ou Fonds mondial pour la nature est une organisation non gouvernementale internationale (ONGI) créée en 1961, vouée à la protection de l'environnement et au développement durable.", Image = "/FileSystem/Pictures/wwf.png", AssociationRepresentativeId = 2, Mail = "asso2@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 3, AddressId = 22, Name = "Association Hirondelle", IsPublished = true, Description = "Créée il y a plus de 25 ans, l’association Hirondelle est une association reconnue dans le domaine de la protection de l’environnement dans la région du Pays de Retz.", Image = "/FileSystem/Pictures/associationhirondelle.jpg", AssociationRepresentativeId = 2, Mail = "asso3@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 4, AddressId = 23, Name = "Tous Au Sport", IsPublished = false, Description = "Cette association loi 1901 à but non lucratif, constituée le 25 juillet 2016, a pour objet de permettre l'accès le plus grand possible au sport à toutes et à tous et cela dans le cadre des cours collectifs.", Image = "/FileSystem/Pictures/tousausport.png", AssociationRepresentativeId = 3, Mail = "asso4@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 5, AddressId = 24, Name = "Sidaction", IsPublished = false, Description = "Sidaction désigne à la fois une association de lutte contre le VIH/sida, créée en 1994 et un évènement télévisuel annuel de collecte de dons pour cette association qui finance à parts égales des programmes de recherche et des associations d’aide aux malades et de prévention, en France et à l’international. Pierre Bergé présidait l'association.", Image = "/FileSystem/Pictures/sidaction.jpg", AssociationRepresentativeId = 1, Mail = "asso4@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 6, AddressId = 25, Name = "Société Française de Musicologie", IsPublished = true, Description = "La Société française de musicologie, fondée en 1917 par des musicologues appartenant à l’ancienne « section française » de la Société internationale de musique, est une société savante dédiée à l’étude scientifique de la musique. Son champ d’étude couvre tout phénomène musical sans restriction d’époques, de civilisations et d’esthétiques, et encourage la diversité des approches méthodologiques.", Image = "/FileSystem/Pictures/sfm.jpg", AssociationRepresentativeId = 1, Mail = "sfm@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 7, AddressId = 26, Name = "Société des Touristes du Dauphiné", IsPublished = true, Description = " En participant à de nombreuses activités et manifestations, la S.T.D. continue d’exercer son influence dans le monde de la montagne. La S.T.D. est affiliée à la Fédération Française de Montagne et d’Escalade ainsi qu’à la Fédération Française de Randonnée Pédestre. La S.T.D. n’assure plus la formation de guides, ce qui est du ressort de l’ENSA, seul organisme habilité.", Image = "/FileSystem/Pictures/std.jpg", AssociationRepresentativeId = 2, Mail = "std@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 8, AddressId = 27, Name = "Reporters Sans Frontières (RSF)", IsPublished = true, Description = "La promotion des droits de l'homme et plus particulièrement la défense de la liberté d'informer et d'être informé à travers le monde. Reporters sans frontières (RSF) est une organisation non gouvernementale internationale fondée en 1985, reconnue d'utilité publique en France et présente en 2020 dans 14 pays. Elle se donne pour objectif la défense de la liberté de la presse et la protection des sources des journalistes. L'association reçoit en 2005 le prix Sakharov du Parlement européen. ", Image = "/FileSystem/Pictures/rsf.jpg", AssociationRepresentativeId = 2, Mail = "rsf@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 9, AddressId = 28, Name = "Fédération des diabétiques de France", IsPublished = false, Description = "La Fédération Française des Diabétiques est une association de patients, au service des patients et dirigée par des patients. Avec son réseau d’environ 100 associations locales et de délégations, réparties sur l’ensemble du territoire et son siège national, elle a pour vocation de représenter les 4 millions de patients diabétiques.", Image = "/FileSystem/Pictures/diabetique.jpg", AssociationRepresentativeId = 4, Mail = "diabetique@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 10, AddressId = 29, Name = "Abris maternelle", IsPublished = false, Description = "Aider les femmes attendant ou ayant un ou plusieurs enfants et les familles qui se trouvent en difficulté pour diverses raisons", Image = "/FileSystem/Pictures/abris.jpg", AssociationRepresentativeId = 1, Mail = "abris@gmail.com" });
            // 11 -> 20
            _bddContext.Association.Add(new Association { Id = 11, AddressId = 30, Name = "A chacun son Everest", IsPublished = true, Description = "Accompagner les enfants et adolescents des services d’Oncohématologie Pédiatrique et éventuellement leurs familles, pour les aider à atteindre leur sommet et les soutenir dans leur maladie", Image = "/FileSystem/Pictures/everest.jpg", AssociationRepresentativeId = 1, Mail = "everest@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 12, AddressId = 31, Name = "E-enfance", IsPublished = true, Description = "Protection des enfants et des adolescents contre les risques liés à l'utilisation de tous moyens de communication interactifs (internet, téléphone mobile, ordinateur, télévision)", Image = "/FileSystem/Pictures/eenfance.jpeg", AssociationRepresentativeId = 1, Mail = "eenfance@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 13, AddressId = 32, Name = "A Domicile 45 ", IsPublished = true, Description = "Mettre en œuvre, organiser et gérer toute action individuelle, pluridisciplaire ou collective destinée à l’aide et au maintien à domicile de toutes personnes ou groupes de personnes, notamment des personnes handicapées, des personnes âgées, des personnes et des familles vulnérables, en situation de précarité ou de pauvreté, en tenant compte de leurs besoins et de leurs attentes, sur l’ensemble du Département du Loiret.", Image = "/FileSystem/Pictures/domicile.jpeg", AssociationRepresentativeId = 1, Mail = "domicile@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 14, AddressId = 33, Name = "Peuples Solidiaires", IsPublished = true, Description = "Créer une dynamique en faveur du développement solidaire de tous les peuples et permettre à chacun/chacune d'être acteur /actrice de la construction collective d'un monde solidaire où les droits fondamentaux sont universellement respectés", Image = "/FileSystem/Pictures/peuples.jpeg", AssociationRepresentativeId = 1, Mail = "peuples@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 15, AddressId = 34, Name = "Agir Soigner Eduquer Insérer (ASEI)", IsPublished = true, Description = "Prise en charge globale et insertion des personnes handicapées quel que soit leur âge, la prise en charge des personnes dépendantes et fragilisées, la promotion des droits des personnes en situation de handicap et la lutte contre l’exclusion de ces personnes, dans le respect des valeurs qui ont toujours présidé à l’action de l’association : la laïcié, le refus de toutes les discriminations, le respect de la personne et la solidarité.", Image = "/FileSystem/Pictures/asei.jpg", AssociationRepresentativeId = 1, Mail = "asei@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 16, AddressId = 35, Name = "Asssociation Aurore", IsPublished = true, Description = "Réadaptation sociale et professionnelle des personnes que la maladie, l'isolement, les détresses morales et matérielles, un séjour en prison ou à l'hôpital ont privé d'une vie normale.", Image = "/FileSystem/Pictures/aurore.jpg", AssociationRepresentativeId = 1, Mail = "aurore@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 17, AddressId = 36, Name = "Académie de l'air et de l'espace", IsPublished = true, Description = "Elaborer une pensée multidisciplinaire de haut niveau et de favoriser le développement d’activités de qualité de toute nature dans le domaine de l’air et de l’espace ; elle se propose de valoriser et d’enrichir le patrimoine scientifique, technique, culturel et humain, de diffuser les connaissances et d’être un pôle d’animation.", Image = "/FileSystem/Pictures/academie.jpg", AssociationRepresentativeId = 1, Mail = "academie@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 18, AddressId = 37, Name = "Les jours heureux", IsPublished = true, Description = "Venir en aide aux familles par des informations et des conseils, de promouvoir et mettre en œuvre tout ce qui pourrait être nécessaire pour le meilleur développement physique, intellectuel et moral de leurs enfants mineurs ou majeurs handicapés mentaux ; accueillir des personnes handicapées mentales au sein d'établissements et de services appropriés avec pour objectifs leur éducation, leur accompagnement, leur réducation, leur adaptation, leur mise au travail, leur insertion sociale, leur hébergement, l'organisation de leurs loisirs, et toute autre action qui apparaitrait nécessaire.", Image = "/FileSystem/Pictures/heureux.jpg", AssociationRepresentativeId = 1, Mail = "heureux@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 19, AddressId = 38, Name = "Les petits frères des pauvres", IsPublished = true, Description = "Accueil, aide et accompagnement dans une relation fraternelle et désintéressée, des personnes, en priorité de plus de 50 ans, souffrant de pauvreté, de solitude, d’ exclusion, de précarité, de maladie grave, par des moyens et dans des conditions adaptés à chacune d’elles. Elle a pour objet de promouvoir le bénévolat de solidarité ; sensibiliser et alerter l’opinion et les pouvoirs publics ; et ce, au service des personnes quels que soient leur origine, leur situation sociale et leur été physique ou psychique.", Image = "/FileSystem/Pictures/freres.jpg", AssociationRepresentativeId = 1, Mail = "freres@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 20, AddressId = 39, Name = "Vaincre la Mucoviscidose", IsPublished = true, Description = "Servir de trait d’union entre les malades atteints de mucoviscidose et de les aider, eux et leurs familles, à résoudre les divers problèmes et difficultés matériels et moraux causés par cette maladie, ainsi que d’assurer la défense des droits des malades et de leurs familles ; Contribuer à la diffusion des informations concernant le dépistage, le diagnostic et les méthodes modernes de traitement de la maladie.", Image = "/FileSystem/Pictures/muco.jpg", AssociationRepresentativeId = 1, Mail = "muco@gmail.com" });
            // 21 -> 30
            _bddContext.Association.Add(new Association { Id = 21, AddressId = 40, Name = "Les enfants du soleil", IsPublished = true, Description = "La Fondation Les enfants du soleil, créée en 2015, renforce l’action de l’association du même nom qui vient en aide aux enfants des rues de Madagascar en prenant en charge leur accueil, leur hébergement, leur éducation, leur formation professionnelle et leur réinsertion dans la vie active avec un métier.", Image = "/FileSystem/Pictures/soleil.jpg", AssociationRepresentativeId = 1, Mail = "soleil@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 22, AddressId = 41, Name = "Ty Al Levenez (Maison du bonheur)", IsPublished = true, Description = "Gérer des foyers, en particulier des Foyers de Jeunes Travailleurs, des logements pour jeunes travailleurs, dans un ou des foyers de jeunes travailleurs ou dans leurs annexes, des services de logements en ville, des restaurants sociaux, des centres de formation ; Service des repas à des organismes sociaux ; Organiser des activités culturelles et sportives dans ses locaux ou à l’extérieur ; Accueillir les groupes et organismes à but non lucratif ; Ouvrir des Centres socio-culturels.", Image = "/FileSystem/Pictures/maison.jpg", AssociationRepresentativeId = 1, Mail = "ty@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 23, AddressId = 42, Name = "Societé Française de Santé Publique", IsPublished = true, Description = "Elle a pour objet toutes les questions se rapportant à la santé publique.", Image = "/FileSystem/Pictures/santepub.jpg", AssociationRepresentativeId = 1, Mail = "santepub@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 24, AddressId = 43, Name = "Société d'Histoire Littéraire de la France", IsPublished = true, Description = "Fournir aux personnes qui s'intéressent à l'histoire de la littérature française des moyens de se réunir d'échanger leurs idées, de profiter en commun des recherches individuelles, d'unir leurs efforts et de grouper leurs travaux.", Image = "/FileSystem/Pictures/histoire.jpg", AssociationRepresentativeId = 1, Mail = "histoire@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 25, AddressId = 44, Name = "Terre d'amitié", IsPublished = true, Description = "Lutter contre la faim et la malnutrition; informer le public sur les problèmes concernant le tiers monde; coopérer sanitairement en faveur du tiers monde.", Image = "/FileSystem/Pictures/amitie.jpg", AssociationRepresentativeId = 1, Mail = "amitié@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 26, AddressId = 45, Name = "Vacances Ouvertes", IsPublished = true, Description = "Stimuler et promouvoir auprès de tous organismes publics ou privés, toues actions tendant à l'accès de tous aux vacances (notamment les jeunes, les familles et les adultes fragilisés ou en difficulté économique et sociale).", Image = "/FileSystem/Pictures/ouverte.jpg", AssociationRepresentativeId = 1, Mail = "ouverte@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 27, AddressId = 46, Name = "Société Nationale de Sauvetage en mer (SNSM)", IsPublished = true, Description = "​Les Sauveteurs en Mer interviennent sur demande des centres régionaux opérationnels de surveillance et de sauvetage (CROSS), effectuent les opérations de recherche en mer, assistent les navires en difficulté, évaluent l'état des personnes à secourir, leur donnent les premiers soins et ramènent les blessés et les naufragés à terre où d’autres organismes de secours les prennent en charge.", Image = "/FileSystem/Pictures/sncm.jpg", AssociationRepresentativeId = 1, Mail = "snsm@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 28, AddressId = 47, Name = "Société Géologique de France", IsPublished = true, Description = "Concourir à l'avancement de la géologie en général et particulièrement de faire connaître le sol de la France tant en lui même que dans ses rapports avec les arts industriels et l'agriculture.", Image = "/FileSystem/Pictures/geologue.jpg", AssociationRepresentativeId = 1, Mail = "geologue@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 29, AddressId = 48, Name = "Société Française d'Anesthésie et de Réanimation (SFAR)", IsPublished = true, Description = "L'étude, l'avancement et l'enseignement de l'Anesthésiologie, telle qu'elle est définie par l'ordre National des médecins d'anesthésie et réanimation.", Image = "/FileSystem/Pictures/anest.jpg", AssociationRepresentativeId = 1, Mail = "anest@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 30, AddressId = 49, Name = "Société d'Horticulture de la Gironde (SHG)", IsPublished = true, Description = "Perfectionnement et les progrès de toutes les branches de l'horticulture des arts et industries qui s'y rattachent; récompenser par des primes diverses tous les mérites horticoles.", Image = "/FileSystem/Pictures/horti.jpg", AssociationRepresentativeId = 1, Mail = "horti@gmail.com" });

            // empty to complete
            //_bddContext.Association.Add(new Association { Id = 11, AddressId = 30, Name = "A chacun son everest", IsPublished = true, Description = "", Image = "/FileSystem/Pictures/petitprince.jpg", AssociationRepresentativeId = 1, Mail = "asso1@gmail.com" });
           
        }

         
        // ASSOCIATIONS MEMBERS
        public void InitializeDB_AMembers()
        {
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 1, AssociationId = 3, MemberId = 2 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 2, AssociationId = 4, MemberId = 2 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 3, AssociationId = 5, MemberId = 2 });

        }

        // ASSOCIATIONS EVENTS
        public void InitializeDB_AEvents()
        {
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 1, EventTitle = " Concert des petits Princes", Description = "Le plus grand concert javmais vu avec Rammstein", Image = "lien vers image", Date = new DateTime(2022, 03, 24), EventType = "Concert", Speakers = "Al Capone", Artists = " Rammstein", TicketsTotalNumber = 3210, AddressId = 1, AssociationId = 1 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 2, EventTitle = " Concert des WWE", Description = "Le plus grand concert ou cela va se bastonner", Image = "lien vers image", Date = new DateTime(2022, 03, 24), EventType = "Concert", Speakers = "Al Bundy", Artists = " Croix de bois", TicketsTotalNumber = 2350, AddressId = 2, AssociationId = 4 });
        }
        // DOCUMENTS

        public void InitializeDB_Documents()
        {
            _bddContext.Document.Add(new Document { Id = 1, AssociationId = 4, Type = "OfficialJournalPublication", Path = "../FileSystem/Documents/Publication1.pdf" });
            _bddContext.Document.Add(new Document { Id = 2, AssociationId = 4, Type = "BankDetails", Path = "../FileSystem/Documents/RIB1.pdf" });
            _bddContext.Document.Add(new Document { Id = 3, AssociationId = 4, Type = "ID", Path = "../FileSystem/Documents/ID1.pdf" });
        }

        // FUNDRAISING
        public void InitializeDB_Fundraising()
        {
            _bddContext.Fundraising.Add(new Fundraising { Id = 1, AssociationId = 1, Name = "Des armes pour l'ukraine", Description = "Description1", IsActive = true, CurrentAmount = 0, DesiredAmount = 10000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Humanitaire" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 2, AssociationId = 1, Name = "Sauvez les éléphants", Description = "Description2", IsActive = true, CurrentAmount = 1500, DesiredAmount = 20000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Sport" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 3, AssociationId = 2, Name = "Aide aux victimes", Description = "Description3", IsActive = true, CurrentAmount = 500, DesiredAmount = 15000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Culture" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 4, AssociationId = 2, Name = "Blocage mine d'or", Description = "Description4", IsActive = true, CurrentAmount = 0, DesiredAmount = 18000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Enseignement" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 5, AssociationId = 3, Name = "Construction hopital", Description = "Description5", IsActive = true, CurrentAmount = 0, DesiredAmount = 5000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Défense des droits" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 6, AssociationId = 3, Name = "Achat lot de maillot", Description = "Description6", IsActive = true, CurrentAmount = 3000, DesiredAmount = 10000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Humanitaire" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 7, AssociationId = 4, Name = "Stop aux ailerons de requin !", Description = "Description7", IsActive = true, CurrentAmount = 50, DesiredAmount = 75000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Recherche" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 8, AssociationId = 4, Name = "Recherche scientifique", Description = "Description8", IsActive = true, CurrentAmount = 1, DesiredAmount = 100000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Humanitaire" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 9, AssociationId = 5, Name = "J'ai plus d'idée !", Description = "Description9", IsActive = true, CurrentAmount = 2500, DesiredAmount = 10000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Culture" });
            _bddContext.Fundraising.Add(new Fundraising { Id = 10, AssociationId = 5, Name = "J'ai plus d'idée !", Description = "Description10", IsActive = false, CurrentAmount = 0, DesiredAmount = 15000, StartingDate = new DateTime(2022, 03, 30), EndingDate = new DateTime(2022, 03, 30), Field = "Loisirs" });

        }

        // ADVIVES
        public void InitializeDB_Advices()
        {
            // Advice requests
            _bddContext.AdviceRequest.Add(new AdviceRequest { Id = 1, AdviceRequestSubject = "DEMANDE DE CONSEIL UN ", AdviceRequestText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam", Date = new DateTime(2022, 01, 01), CompletedRequest = false, AssociationId = 1, MemberId = 1 });
            _bddContext.AdviceRequest.Add(new AdviceRequest { Id = 2, AdviceRequestSubject = "DEMANDE DE CONSEIL DEUX ", AdviceRequestText = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem ac illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.", Date = new DateTime(2022, 02, 02), CompletedRequest = false, AssociationId = 2, MemberId = 1 });
           
            //Advices

            _bddContext.Advice.Add(new Advice { Id = 1, AdviceSubject = "CONSEIL UN ", AdviceText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam", Date = new DateTime(2022, 02, 01), AdviceRequestId = 1, MemberId = 1 });
            //_bddContext.Advice.Add(new Advice { Id = 2, AdviceSubject = "CONSEIL DEUX ", AdviceText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam", Date = new DateTime(2022, 02, 01), AdviceRequestId = 2, MemberId = 1 });

        }
        // ADRESSES
        public void InitializeDB_Adresses()
        {
            // 1 -> 10
            _bddContext.Address.Add(new Address { Id = 1, RoadNumber = "2", Road = "Rue de bel air", City = "Saint-Pryvé-Saint-Mesmin", PostalCode = "45750", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 2, RoadNumber = "3", Road = "Avenue de la république", City = "Angers", PostalCode = "49000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 3, RoadNumber = "4", Road = "Rue du paradis", City = "Le Mans", PostalCode = "72000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 4, RoadNumber = "5", Road = "Rue du général de gaulle", City = "Bordeaux", PostalCode = "33000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 5, RoadNumber = "6", Road = "Rue du général", City = "Paris", PostalCode = "75000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 6, RoadNumber = "7", Road = "Rue du caporal", City = "Grenoble", PostalCode = "38000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 7, RoadNumber = "2", Road = "Rue de bel air", City = "Saint-Pryvé-Saint-Mesmin", PostalCode = "45750", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 8, RoadNumber = "3", Road = "Avenue de la république", City = "Angers", PostalCode = "49000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 9, RoadNumber = "4", Road = "Rue du paradis", City = "Le Mans", PostalCode = "72000", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 10, RoadNumber = "5", Road = "Rue du général de gaulle", City = "Bordeaux", PostalCode = "33000", Country = "France" });
            // 11 -> 20
            _bddContext.Address.Add(new Address { Id = 11, RoadNumber = "11", Road = "Rue marguerite renaudin", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 12, RoadNumber = "12", Road = "Rue de l'est", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 13, RoadNumber = "13", Road = "Rue de l'ouest", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 14, RoadNumber = "14", Road = "Rue du Château", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 15, RoadNumber = "15", Road = "Rue du Guet", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 16, RoadNumber = "16", Road = "Rue du Jeanne", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 17, RoadNumber = "17", Road = "Rue du Gathelot", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 18, RoadNumber = "18", Road = "Rue du Trosy", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 19, RoadNumber = "19", Road = "Rue Chef", City = "Clamart", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 20, RoadNumber = "20", Road = "Rue Martin", City = "Clamart", PostalCode = "92140", Country = "France" });
            // 21 -> 30
            _bddContext.Address.Add(new Address { Id = 21, RoadNumber = "6", Road = "Rue du général", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 22, RoadNumber = "7", Road = "Rue du colonel", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 23, RoadNumber = "6", Road = "Rue du lieutenant-colonel", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 24, RoadNumber = "7", Road = "Rue du capitaine", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 25, RoadNumber = "6", Road = "Rue du lieutenant", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 26, RoadNumber = "7", Road = "Rue du sous-lieutenant", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 27, RoadNumber = "7", Road = "Rue du gendarme", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 28, RoadNumber = "6", Road = "Rue de l'aspirant", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 29, RoadNumber = "7", Road = "Rue du major", City = "Chatillon", PostalCode = "92320", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 30, RoadNumber = "7", Road = "Rue de l'adjudant-chef", City = "Chatillon", PostalCode = "92320", Country = "France" });
            // 31 -> 40
            _bddContext.Address.Add(new Address { Id = 31, RoadNumber = "11", Road = "Rue Louise Michel", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 32, RoadNumber = "12", Road = "Rue Olympe de Gouges ", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 33, RoadNumber = "13", Road = "Rue Clara Zetkin ", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 34, RoadNumber = "14", Road = "Rue Emmeline Pankhurst ", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 35, RoadNumber = "15", Road = "Rue  Emilie Gourd", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 36, RoadNumber = "16", Road = "Rue  Marguerite Yourcenar", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 37, RoadNumber = "17", Road = "Rue Rosa Parks", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 38, RoadNumber = "18", Road = "Rue Malala Yousafzai", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 39, RoadNumber = "19", Road = "Rue Helene Brion", City = "Nice", PostalCode = "92140", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 40, RoadNumber = "20", Road = "Rue Andree Butillard", City = "Nice", PostalCode = "92140", Country = "France" });
            // 41 -> 50
            _bddContext.Address.Add(new Address { Id = 41, RoadNumber = "1", Road = "Rue Alfred Aho", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 42, RoadNumber = "12", Road = "Rue Gene Amdahl", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 43, RoadNumber = "3", Road = "Rue Al-Khwârizmî", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 44, RoadNumber = "14", Road = "Rue John Backus", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 45, RoadNumber = "1", Road = "Rue Alexander Graham Bell", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 46, RoadNumber = "16", Road = "Rue Nolan Bushnell", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 47, RoadNumber = "17", Road = "Rue Alan Cox", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 48, RoadNumber = "8", Road = "Rue Haskell Curry", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 49, RoadNumber = "19", Road = "Rue Andreï Ershov", City = "Nantes", PostalCode = "44109", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 50, RoadNumber = "2", Road = "Rue Jay Forrester", City = "Nantes", PostalCode = "44109", Country = "France" });

        }


        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
