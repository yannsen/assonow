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

            InitializeDB_Order();

            InitializeDB_Ticket();

            InitializeDB_Contribution();

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
            _bddContext.Member.Add(new Member { Id = 11, Firstname = "Isabelle", Lastname = "Grégory", Mail = "farina@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb2", AddressId = 11, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 12, Firstname = "Aline", Lastname = "Baudouin", Mail = "femelin@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb3", AddressId = 12, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 13, Firstname = "Jean", Lastname = "Beverly", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb4", AddressId = 13, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 14, Firstname = "Marion", Lastname = "Lefevre", Mail = "arnold@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb5", AddressId = 14, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 15, Firstname = "Louise", Lastname = "Farina", Mail = "farina@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb6", AddressId = 15, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 16, Firstname = "Alice", Lastname = "Lemelin", Mail = "femelin@gmail.com", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb7", AddressId = 16, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 17, Firstname = "Jeanne", Lastname = "Boulanger", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb8", AddressId = 17, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 18, Firstname = "Charlie", Lastname = "Maréchal", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb9", AddressId = 18, Role = "Member" });
            _bddContext.Member.Add(new Member { Id = 19, Firstname = "Anthony", Lastname = "Durocher", Mail = "feverly@yahoo.fr", Password = authentificationService.EncodeMD5("123456"), Pseudonym = "Memb10", AddressId = 19, Role = "Member" });

        }
        // ASSOCIATIONS
        public void InitializeDB_Associations()
        {
            // Association utile
            _bddContext.Association.Add(
                new Association
                {
                    Id = 1,
                    DonationService = true,
                    TicketService = true,
                    MemberService = true,
                    Contribution = 40,
                    IsHighlighted = true,
                    AddressId = 54,
                    Name = "A chacun son Everest",
                    IsPublished = true,
                    Description = "Accompagner les enfants et adolescents des services d’Oncohématologie Pédiatrique et éventuellement leurs familles, pour les aider à atteindre leur sommet et les soutenir dans leur maladie",
                    Image = "/FileSystem/Pictures/Everest.jpg",
                    AssociationRepresentativeId = 6,
                    Mail = "everest@gmail.com"
                });

            _bddContext.Association.Add(
                new Association
                {
                    Id = 2,
                    DonationService = true,
                    TicketService = true,
                    MemberService = true,
                    Contribution = 20,
                    IsHighlighted = true,
                    AddressId = 40,
                    Name = "Les enfants du soleil",
                    IsPublished = true,
                    Description = "La Fondation Les enfants du soleil, créée en 2015, renforce l’action de l’association du même nom qui vient en aide aux enfants des rues de Madagascar en prenant en charge leur accueil, leur hébergement, leur éducation, leur formation professionnelle et leur réinsertion dans la vie active avec un métier.",
                    Image = "/FileSystem/Pictures/soleil.jpg",
                    AssociationRepresentativeId = 7,
                    Mail = "soleil@gmail.com"
                });

            _bddContext.Association.Add(
                new Association
                {
                    Id = 3,
                    DonationService = true,
                    TicketService = true,
                    MemberService = true,
                    Contribution = 10,
                    IsHighlighted = true,
                    AddressId = 39,
                    Name = "Vaincre la Mucoviscidose",
                    IsPublished = true,
                    Description = "Servir de trait d’union entre les malades atteints de mucoviscidose et de les aider, eux et leurs familles, à résoudre les divers problèmes et difficultés matériels et moraux causés par cette maladie, ainsi que d’assurer la défense des droits des malades et de leurs familles; Contribuer à la diffusion des informations concernant le dépistage, le diagnostic et les méthodes modernes de traitement de la maladie.",
                    Image = "/FileSystem/Pictures/muco.jpg",
                    AssociationRepresentativeId = 7,
                    Mail = "muco@gmail.com"
                });



            // Association remplissage

            _bddContext.Association.Add(new Association { Id = 4, Contribution = 5, IsHighlighted = false, AddressId = 23, Name = "Tous Au Sport", IsPublished = false, Description = "Cette association loi 1901 à but non lucratif, constituée le 25 juillet 2016, a pour objet de permettre l'accès le plus grand possible au sport à toutes et à tous et cela dans le cadre des cours collectifs.", Image = "/FileSystem/Pictures/tousausport.png", AssociationRepresentativeId = 9, Mail = "asso4@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 5, Contribution = 10, IsHighlighted = false, AddressId = 24, Name = "Sidaction", IsPublished = false, Description = "Sidaction désigne à la fois une association de lutte contre le VIH/sida, créée en 1994 et un évènement télévisuel annuel de collecte de dons pour cette association qui finance à parts égales des programmes de recherche et des associations d’aide aux malades et de prévention, en France et à l’international. Pierre Bergé présidait l'association.", Image = "/FileSystem/Pictures/sidaction.jpg", AssociationRepresentativeId = 9, Mail = "asso4@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 6, Contribution = 10, IsHighlighted = false, AddressId = 25, Name = "Société Française de Musicologie", IsPublished = true, Description = "La Société française de musicologie, fondée en 1917 par des musicologues appartenant à l’ancienne « section française » de la Société internationale de musique, est une société savante dédiée à l’étude scientifique de la musique. Son champ d’étude couvre tout phénomène musical sans restriction d’époques, de civilisations et d’esthétiques, et encourage la diversité des approches méthodologiques.", Image = "/FileSystem/Pictures/sfm.jpg", AssociationRepresentativeId = 9, Mail = "sfm@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 7, Contribution = 30, IsHighlighted = false, AddressId = 26, Name = "Société des Touristes du Dauphiné", IsPublished = true, Description = " En participant à de nombreuses activités et manifestations, la S.T.D. continue d’exercer son influence dans le monde de la montagne. La S.T.D. est affiliée à la Fédération Française de Montagne et d’Escalade ainsi qu’à la Fédération Française de Randonnée Pédestre. La S.T.D. n’assure plus la formation de guides, ce qui est du ressort de l’ENSA, seul organisme habilité.", Image = "/FileSystem/Pictures/std.jpg", AssociationRepresentativeId = 9, Mail = "std@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 8, Contribution = 20, IsHighlighted = true, AddressId = 27, Name = "Reporters Sans Frontières", IsPublished = true, Description = "La promotion des droits de l'homme et plus particulièrement la défense de la liberté d'informer et d'être informé à travers le monde. Reporters sans frontières (RSF) est une organisation non gouvernementale internationale fondée en 1985, reconnue d'utilité publique en France et présente en 2020 dans 14 pays. Elle se donne pour objectif la défense de la liberté de la presse et la protection des sources des journalistes. L'association reçoit en 2005 le prix Sakharov du Parlement européen. ", Image = "/FileSystem/Pictures/rsf.jpg", AssociationRepresentativeId = 9, Mail = "rsf@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 9, Contribution = 20, IsHighlighted = false, AddressId = 28, Name = "Fédération des diabétiques de France", IsPublished = false, Description = "La Fédération Française des Diabétiques est une association de patients, au service des patients et dirigée par des patients. Avec son réseau d’environ 100 associations locales et de délégations, réparties sur l’ensemble du territoire et son siège national, elle a pour vocation de représenter les 4 millions de patients diabétiques.", Image = "/FileSystem/Pictures/diabetique.jpg", AssociationRepresentativeId = 9, Mail = "diabetique@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 10, Contribution = 20, IsHighlighted = false, AddressId = 29, Name = "Abris maternelle", IsPublished = false, Description = "Aider les femmes attendant ou ayant un ou plusieurs enfants et les familles qui se trouvent en difficulté pour diverses raisons", Image = "/FileSystem/Pictures/abris.jpg", AssociationRepresentativeId = 9, Mail = "abris@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 11, Contribution = 50, IsHighlighted = false, AddressId = 20, Name = "Petits Princes", IsPublished = true, Description = "L'Association Petits Princes est une association à but non lucratif créée en 1987 qui s'est donné pour but de réaliser les rêves d’enfants et adolescents malades atteints de cancers, leucémies et certaines maladies génétiques.", Image = "/FileSystem/Pictures/petitprince.jpg", AssociationRepresentativeId = 9, Mail = "asso1@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 12, Contribution = 40, IsHighlighted = false, AddressId = 31, Name = "E-enfance", IsPublished = true, Description = "Protection des enfants et des adolescents contre les risques liés à l'utilisation de tous moyens de communication interactifs (internet, téléphone mobile, ordinateur, télévision)", Image = "/FileSystem/Pictures/eenfance.jpeg", AssociationRepresentativeId = 9, Mail = "eenfance@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 13, Contribution = 0, IsHighlighted = false, AddressId = 32, Name = "A Domicile 45 ", IsPublished = true, Description = "Mettre en œuvre, organiser et gérer toute action individuelle, pluridisciplaire ou collective destinée à l’aide et au maintien à domicile de toutes personnes ou groupes de personnes, notamment des personnes handicapées, des personnes âgées, des personnes et des familles vulnérables, en situation de précarité ou de pauvreté, en tenant compte de leurs besoins et de leurs attentes, sur l’ensemble du Département du Loiret.", Image = "/FileSystem/Pictures/domicile.jpeg", AssociationRepresentativeId = 9, Mail = "domicile@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 14, Contribution = 20, IsHighlighted = true, AddressId = 33, Name = "Peuples Solidaires", IsPublished = true, Description = "Créer une dynamique en faveur du développement solidaire de tous les peuples et permettre à chacun/chacune d'être acteur /actrice de la construction collective d'un monde solidaire où les droits fondamentaux sont universellement respectés", Image = "/FileSystem/Pictures/peuples.jpeg", AssociationRepresentativeId = 9, Mail = "peuples@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 15, Contribution = 30, IsHighlighted = false, AddressId = 34, Name = "Agir Soigner Eduquer Insérer (ASEI)", IsPublished = true, Description = "Prise en charge globale et insertion des personnes handicapées quel que soit leur âge, la prise en charge des personnes dépendantes et fragilisées, la promotion des droits des personnes en situation de handicap et la lutte contre l’exclusion de ces personnes, dans le respect des valeurs qui ont toujours présidé à l’action de l’association : la laïcié, le refus de toutes les discriminations, le respect de la personne et la solidarité.", Image = "/FileSystem/Pictures/asei.jpg", AssociationRepresentativeId = 9, Mail = "asei@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 16, Contribution = 0, IsHighlighted = true, AddressId = 35, Name = "Association Aurore", IsPublished = true, Description = "Réadaptation sociale et professionnelle des personnes que la maladie, l'isolement, les détresses morales et matérielles, un séjour en prison ou à l'hôpital ont privé d'une vie normale.", Image = "/FileSystem/Pictures/aurore.jpg", AssociationRepresentativeId = 9, Mail = "aurore@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 17, Contribution = 5, IsHighlighted = true, AddressId = 36, Name = "Académie de l'air et de l'espace", IsPublished = true, Description = "Elaborer une pensée multidisciplinaire de haut niveau et de favoriser le développement d’activités de qualité de toute nature dans le domaine de l’air et de l’espace ; elle se propose de valoriser et d’enrichir le patrimoine scientifique, technique, culturel et humain, de diffuser les connaissances et d’être un pôle d’animation.", Image = "/FileSystem/Pictures/academie.jpg", AssociationRepresentativeId = 9, Mail = "academie@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 18, Contribution = 15, IsHighlighted = true, AddressId = 37, Image = "/FileSystem/Pictures/heureux.jpg", AssociationRepresentativeId = 8, Name = "Les jours heureux", IsPublished = true, Description = "Venir en aide aux familles par des informations et des conseils, de promouvoir et mettre en œuvre tout ce qui pourrait être nécessaire pour le meilleur développement physique, intellectuel et moral de leurs enfants mineurs ou majeurs handicapés mentaux ; accueillir des personnes handicapées mentales au sein d'établissements et de services appropriés avec pour objectifs leur éducation, leur accompagnement, leur réducation, leur adaptation, leur mise au travail, leur insertion sociale, leur hébergement, l'organisation de leurs loisirs, et toute autre action qui apparaitrait nécessaire.", Mail = "heureux@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 19, Contribution = 0, IsHighlighted = false, AddressId = 38, Name = "Les petits frères des pauvres", IsPublished = true, Description = "Accueil, aide et accompagnement dans une relation fraternelle et désintéressée, des personnes, en priorité de plus de 50 ans, souffrant de pauvreté, de solitude, d’ exclusion, de précarité, de maladie grave, par des moyens et dans des conditions adaptés à chacune d’elles. Elle a pour objet de promouvoir le bénévolat de solidarité ; sensibiliser et alerter l’opinion et les pouvoirs publics ; et ce, au service des personnes quels que soient leur origine, leur situation sociale et leur été physique ou psychique.", Image = "/FileSystem/Pictures/freres.jpg", AssociationRepresentativeId = 9, Mail = "freres@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 20, Contribution = 40, IsHighlighted = false, AddressId = 21, Name = "WWF", IsPublished = true, Description = "Le WWF ou Fonds mondial pour la nature est une organisation non gouvernementale internationale (ONGI) créée en 1961, vouée à la protection de l'environnement et au développement durable.", Image = "/FileSystem/Pictures/wwf.png", AssociationRepresentativeId = 9, Mail = "asso2@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 21, Contribution = 0, IsHighlighted = false, AddressId = 22, Name = "Association Hirondelle", IsPublished = true, Description = "Créée il y a plus de 25 ans, l’association Hirondelle est une association reconnue dans le domaine de la protection de l’environnement dans la région du Pays de Retz.", Image = "/FileSystem/Pictures/associationhirondelle.jpg", AssociationRepresentativeId = 9, Mail = "asso3@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 22, Contribution = 20, IsHighlighted = false, AddressId = 41, Name = "Chacun sa maison du bonheur", IsPublished = true, Description = "Gérer des foyers, en particulier des Foyers de Jeunes Travailleurs, des logements pour jeunes travailleurs, dans un ou des foyers de jeunes travailleurs ou dans leurs annexes, des services de logements en ville, des restaurants sociaux, des centres de formation ; Service des repas à des organismes sociaux ; Organiser des activités culturelles et sportives dans ses locaux ou à l’extérieur ; Accueillir les groupes et organismes à but non lucratif ; Ouvrir des Centres socio-culturels.", Image = "/FileSystem/Pictures/maison.jpg", AssociationRepresentativeId = 8, Mail = "ty@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 23, Contribution = 0, IsHighlighted = false, AddressId = 42, Name = "Societé Française de Santé Publique", IsPublished = true, Description = "Elle a pour objet toutes les questions se rapportant à la santé publique.", Image = "/FileSystem/Pictures/santepub.jpg", AssociationRepresentativeId = 9, Mail = "santepub@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 24, Contribution = 30, IsHighlighted = false, AddressId = 43, Name = "Société d'Histoire Littéraire de la France", IsPublished = true, Description = "Fournir aux personnes qui s'intéressent à l'histoire de la littérature française des moyens de se réunir d'échanger leurs idées, de profiter en commun des recherches individuelles, d'unir leurs efforts et de grouper leurs travaux.", Image = "/FileSystem/Pictures/histoire.jpg", AssociationRepresentativeId = 9, Mail = "histoire@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 25, Contribution = 40, IsHighlighted = false, AddressId = 44, Name = "Terre d'amitié", IsPublished = true, Description = "Lutter contre la faim et la malnutrition; informer le public sur les problèmes concernant le tiers monde; coopérer sanitairement en faveur du tiers monde.", Image = "/FileSystem/Pictures/amitie.jpg", AssociationRepresentativeId = 9, Mail = "amitié@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 26, Contribution = 30, IsHighlighted = true, AddressId = 45, Name = "Vacances Ouvertes", IsPublished = true, Description = "Stimuler et promouvoir auprès de tous organismes publics ou privés, toues actions tendant à l'accès de tous aux vacances (notamment les jeunes, les familles et les adultes fragilisés ou en difficulté économique et sociale).", Image = "/FileSystem/Pictures/ouverte.jpg", AssociationRepresentativeId = 8, Mail = "ouverte@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 27, Contribution = 0, IsHighlighted = false, AddressId = 46, Name = "Société Nationale de Sauvetage en mer (SNSM)", IsPublished = true, Description = "​Les Sauveteurs en Mer interviennent sur demande des centres régionaux opérationnels de surveillance et de sauvetage (CROSS), effectuent les opérations de recherche en mer, assistent les navires en difficulté, évaluent l'état des personnes à secourir, leur donnent les premiers soins et ramènent les blessés et les naufragés à terre où d’autres organismes de secours les prennent en charge.", Image = "/FileSystem/Pictures/sncm.jpg", AssociationRepresentativeId = 8, Mail = "snsm@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 28, Contribution = 10, IsHighlighted = false, AddressId = 47, Name = "Société Géologique de France", IsPublished = true, Description = "Concourir à l'avancement de la géologie en général et particulièrement de faire connaître le sol de la France tant en lui même que dans ses rapports avec les arts industriels et l'agriculture.", Image = "/FileSystem/Pictures/geologue.jpg", AssociationRepresentativeId = 9, Mail = "geologue@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 29, Contribution = 10, IsHighlighted = false, AddressId = 48, Name = "Société Française d'Anesthésie et de Réanimation (SFAR)", IsPublished = true, Description = "L'étude, l'avancement et l'enseignement de l'Anesthésiologie, telle qu'elle est définie par l'ordre National des médecins d'anesthésie et réanimation.", Image = "/FileSystem/Pictures/anest.jpg", AssociationRepresentativeId = 8, Mail = "anest@gmail.com" });
            _bddContext.Association.Add(new Association { Id = 30, Contribution = 0, IsHighlighted = false, AddressId = 49, Name = "Société d'Horticulture de la Gironde (SHG)", IsPublished = true, Description = "Perfectionnement et les progrès de toutes les branches de l'horticulture des arts et industries qui s'y rattachent; récompenser par des primes diverses tous les mérites horticoles.", Image = "/FileSystem/Pictures/horti.jpg", AssociationRepresentativeId = 9, Mail = "horti@gmail.com" });

            // empty to complete
            //_bddContext.Association.Add(new Association { Id = 11, AddressId = 30, Name = "A chacun son everest", IsPublished = true, Description = "", Image = "/FileSystem/Pictures/petitprince.jpg", AssociationRepresentativeId = 1, Mail = "asso1@gmail.com" });

        }

        // ASSOCIATIONS MEMBERS
        public void InitializeDB_AMembers()
        {
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 1, AssociationId = 1, MemberId = 10 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 2, AssociationId = 1, MemberId = 11 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 3, AssociationId = 1, MemberId = 12 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 4, AssociationId = 1, MemberId = 13 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 5, AssociationId = 1, MemberId = 14 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 6, AssociationId = 2, MemberId = 15 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 7, AssociationId = 2, MemberId = 16 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 8, AssociationId = 2, MemberId = 17 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 9, AssociationId = 2, MemberId = 18 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 10, AssociationId = 2, MemberId = 19 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 11, AssociationId = 3, MemberId = 10 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 12, AssociationId = 3, MemberId = 11 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 13, AssociationId = 3, MemberId = 12 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 14, AssociationId = 3, MemberId = 13 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 15, AssociationId = 3, MemberId = 14 });
            _bddContext.AssociationMember.Add(new AssociationMember { Id = 16, AssociationId = 3, MemberId = 15 });

        }
        // Cotisations
        public void InitializeDB_Contribution()
        {
            _bddContext.Contribution.Add(new Contribution { Id = 1, AssociationId = 1, MemberId = 10, Amount = 40 });
            _bddContext.Contribution.Add(new Contribution { Id = 2, AssociationId = 1, MemberId = 11, Amount = 40 });
            _bddContext.Contribution.Add(new Contribution { Id = 3, AssociationId = 1, MemberId = 12, Amount = 40 });
            _bddContext.Contribution.Add(new Contribution { Id = 4, AssociationId = 1, MemberId = 13, Amount = 40 });
            _bddContext.Contribution.Add(new Contribution { Id = 5, AssociationId = 1, MemberId = 14, Amount = 40 });
            _bddContext.Contribution.Add(new Contribution { Id = 6, AssociationId = 2, MemberId = 15, Amount = 20 });
            _bddContext.Contribution.Add(new Contribution { Id = 7, AssociationId = 2, MemberId = 16, Amount = 20 });
            _bddContext.Contribution.Add(new Contribution { Id = 8, AssociationId = 2, MemberId = 17, Amount = 20 });
            _bddContext.Contribution.Add(new Contribution { Id = 9, AssociationId = 2, MemberId = 18, Amount = 20 });
            _bddContext.Contribution.Add(new Contribution { Id = 10, AssociationId = 2, MemberId = 19, Amount = 20 });
            _bddContext.Contribution.Add(new Contribution { Id = 11, AssociationId = 3, MemberId = 10, Amount = 10 });
            _bddContext.Contribution.Add(new Contribution { Id = 12, AssociationId = 3, MemberId = 11, Amount = 10 });
            _bddContext.Contribution.Add(new Contribution { Id = 13, AssociationId = 3, MemberId = 12, Amount = 10 });
            _bddContext.Contribution.Add(new Contribution { Id = 14, AssociationId = 3, MemberId = 13, Amount = 10 });
            _bddContext.Contribution.Add(new Contribution { Id = 15, AssociationId = 3, MemberId = 14, Amount = 10 });
            _bddContext.Contribution.Add(new Contribution { Id = 16, AssociationId = 3, MemberId = 15, Amount = 10 });
        }

        // ASSOCIATIONS EVENTS
        public void InitializeDB_AEvents()
        {
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 1, IsHighlighted = true, EventTitle = " Concert privé Rammstein pour Vaincre la Muco", Description = "S’il était nécessaire de prouver que Rammstein figure actuellement parmi les plus grands groupes du monde, le succès de leur septième album éponyme et la conclusion de la première partie de leur tournée des stades en dit long. pour soutenir l'association Vaincre la Mucovisidose Rammstein organie un concert privé", Image = "/FileSystem/Pictures/rammstein.jpg", Date = new DateTime(2022, 05, 24), EventType = "Concert", Speakers = "", Artists = " Rammstein", TicketsTotalNumber = 200, RemainingTickets= 6, AddressId = 39, AssociationId = 3,TicketPrice= 20.0 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 2, IsHighlighted = true, EventTitle = " Odyssée : la conférence musicale ", Description = "Il s’agit de l’histoire d’amour entre Ulysse et Pénélope. Mais il s’agit également de l’histoire d’amour entre René Brillotte, professeur de grec antique et conférencier spécialiste d’Homère, et Marie Louise Costaille, directrice de la salle. Lorsque René commence sa conférence, il ne se doute pas que, sous l’influence de Marie-Louise, tout va déraper et se transformer en un délire musical où l’Odyssée sera racontée à la sauce loufoque entre sorcières, dieux, cyclopes et retour à Ithaque !", Image = "/FileSystem/Pictures/odyssee.png", Date = new DateTime(2022, 03, 24), EventType = "conte musicale", Speakers = "", Artists = "Julie Costanza, Stéphanie Gagneux et Simon Gallant ", TicketsTotalNumber = 400, RemainingTickets = 400, AddressId = 2, AssociationId = 6, TicketPrice = 15.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 3, IsHighlighted = true, EventTitle = " Exoconference", Description = "Un astrophysicien (Alexandre Astier) donne une conférence au cours de laquelle il retrace les grandes étapes de la formation de l'univers depuis le Big Bang avant de se pencher sur la question de la vie extraterrestre", Image = "/FileSystem/Pictures/Exoconference.jpg", Date = new DateTime(2022, 03, 24), EventType = "Concert", Speakers = "", Artists = " Alexandre Astier", TicketsTotalNumber = 500, RemainingTickets = 500, AddressId = 2, AssociationId = 17, TicketPrice = 15.00 });          
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 4, IsHighlighted = true, EventTitle = " Puy Du Fou", Description = "Il existe des mondes et des époques que l’on croyait à jamais disparus. Pourtant, la forêt centenaire du Puy du Fou est devenue leur refuge et l’Histoire continue.Évadez - vous au Puy du Fou pour découvrir cette terre où les héros sont éternels.Venez percer le mystère de ce lieu hors norme et partez pour un spectaculaire voyage dans le temps des Romains au XXème siècle! Chaque spectacle, chaque aventure resteront gravés à jamais dans votre mémoire.En famille ou entre amis, préparez-vous à vivre une expérience bouleversante riche en émotions fortes, en grands spectacles et en souvenirs!", Image = "/FileSystem/Pictures/puydufou.jpg", Date = new DateTime(2022, 03, 24), EventType = "Spectacle", Speakers = "", Artists = "La compagnie du Puy du Fou", TicketsTotalNumber = 200, RemainingTickets = 200, AddressId = 2, AssociationId = 19, TicketPrice = 15.50 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 5, IsHighlighted = true, EventTitle = " Conférence de Michel Ocelot", Description = "Rétrospective Michel Ocelot,Autodidacte, Michel Ocelot a consacré toute sa carrière au cinéma d’animation, écrivant ses propres histoires, dessinant lui-même les personnages de ses films et créant leur univers graphique. ", Image = "/FileSystem/Pictures/Conference_Michel_Ocelot.jpg", Date = new DateTime(2022, 03, 24), EventType = "Conférérence", Speakers = "Michel Laclotte", Artists = "", TicketsTotalNumber = 400, RemainingTickets = 400, AddressId = 2, AssociationId = 12, TicketPrice = 15.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 6, IsHighlighted = true, EventTitle = " Conférence des sciences ", Description = "La confrontation des savoirs et des savoir-faire est indispensable au progrès scientifique. Riche de sa pluridisciplinarité et de ses relations étroites avec les forces de la recherche, en France comme à l’étranger, l’Académie des sciences propose chaque année une série de manifestations scientifiques consacrées aux frontières de la connaissance", Image = "/FileSystem/Pictures/conference-Sci.jpg", Date = new DateTime(2022, 04, 18), EventType = "Conférence", Speakers = "", Artists = "Antonin  Atger", TicketsTotalNumber = 200, RemainingTickets = 200, AddressId = 2, AssociationId = 29, TicketPrice = 15.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 7, IsHighlighted = true, EventTitle = " Tadjikistan au pays des fleuves d'or", Description = "la plus grande exposition jamais consacrée en occident au Tadjikistan. Elle révèle la richesse culturelle de ce pays méconnu, resté dans l’ombre de ses voisins davantage médiatisés que sont l’Afghanistan et l’Ouzbékistan, avec des pièces exceptionnelles et rares.", Image = " /FileSystem/Pictures/archeologie.jpg", Date = new DateTime(2022, 03, 24), EventType = "Conférence", Speakers = "", Artists = " ", TicketsTotalNumber = 2350, RemainingTickets = 2350, AddressId = 2, AssociationId = 24, TicketPrice = 2.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 8, IsHighlighted = true, EventTitle = " Solidays", Description = "Faire chavirer les cœurs. Voilà l’ambition de cette 24e édition qui s’annonce exceptionnelle.", Image = "/FileSystem/Pictures/solidays1.jpg", Date = new DateTime(2022, 06, 24), EventType = "Concert", Speakers = "", Artists = " Black Eyed Peas, Damso, Justice ", TicketsTotalNumber = 500, RemainingTickets = 500, AddressId = 5, AssociationId = 5, TicketPrice = 15.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 9, IsHighlighted = true, EventTitle = " Matchs d'exhibition  du comité Yvelines Tennis", Description = "Depuis déjà plusieurs années, le Comité Yvelines nous apporte son soutien à travers le Circuit TMC Everest 78. Un tournoi féminin avec de nombreuses dates, les profits des matchs sont reversés à l'association.", Image = "/FileSystem/Pictures/comitetennisy.png", Date = new DateTime(2022, 06, 03), EventType = "Concert", Speakers = "comité Yvelines de Tennis", Artists = "", TicketsTotalNumber = 200, RemainingTickets = 200, AddressId = 51, AssociationId = 1, TicketPrice = 5.50 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 10, IsHighlighted = false, EventTitle = "Winter Legacy", Description = "Au programme : une course polyvalente ouverte à tous pour se mesurer à cinq disciplines: bosses, géant, super géant, ski cross et water slide. De nombreuses animations sont prévues : DJ, tombola, ski test…etc.", Image = "/FileSystem/Pictures/winter.jpg", Date = new DateTime(2022, 04, 09), EventType = "Concert", Speakers = "", Artists = "Alexis Pinturault", TicketsTotalNumber = 300, RemainingTickets = 5, AddressId = 6, AssociationId = 1, TicketPrice = 60.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 11, IsHighlighted = false, EventTitle = "TOC TOC à Saint-Jorioz", Description = "L'association Mums'n roses vous invite à assister à la représentation Toc Toc, le grand succès de Laurent Baffie interprété par la troupe Imagine.", Image = "/FileSystem/Pictures/toctoc.jpg", Date = new DateTime(2022, 04, 07), EventType = "Spectacle", Speakers = "", Artists = "Mums'n roses", TicketsTotalNumber = 150, RemainingTickets = 150, AddressId = 2, AssociationId = 1, TicketPrice = 6.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 12, IsHighlighted = false, EventTitle = "Concert M", Description = "Concert exceptionnel de l'artiste M en soutien à l'association Les Enfants du soleil", Image = "/FileSystem/Pictures/concertM.jpg", Date = new DateTime(2022, 04, 09), EventType = "Spectacle", Speakers = "", Artists = "M", TicketsTotalNumber = 1500, RemainingTickets = 150, AddressId = 55, AssociationId = 2, TicketPrice = 6.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 13, IsHighlighted = false, EventTitle = "Un air de famille", Description = "Le théâtre du Triangle, troupe au talent reconnu joue une nouvelle fois pour les Enfants du Soleil  et donne la célèbre pièce Un air de famille", Image = "/FileSystem/Pictures/Ttriangle.jpg", Date = new DateTime(2022, 05, 18), EventType = "Theatre", Speakers = "", Artists = "Le théâtre du Triangle", TicketsTotalNumber = 200, RemainingTickets = 150, AddressId = 56, AssociationId = 2, TicketPrice = 6.00 });
            _bddContext.AssociationEvent.Add(new AssociationEvent { Id = 14, IsHighlighted = false, EventTitle = "Green de l'espoir à St Germain En Laye", Description = "Le Green de l’espoir, une histoire de famille et surtout de grande famille, la nôtre et celle de la MUCO. c’est pourquoi nous nous sommes engagés depuis maintenant 5 ans dans l’organisation d’une compétition Green de l’espoir.", Image = "/FileSystem/Pictures/greenMuco.png", Date = new DateTime(2022, 05, 18), EventType = "Sport", Speakers = "", Artists = "", TicketsTotalNumber = 100, RemainingTickets = 100, AddressId = 56, AssociationId = 3, TicketPrice = 6.00 });
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
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 1,
                AssociationId = 1,
                Name = "Une semaine à Chamonix",
                Description = "16 enfants ou adolescents se retrouvent à Chamonix pour vivre une semaine intense, adaptée à leurs possibilités. La vie collective est basée sur le respect, l’autonomisation des enfants et leur repos. Enfants et adultes participent à la vie de la Maison.",
                IsActive = true,
                CurrentAmount = 2420,
                DesiredAmount = 10000,
                StartingDate = new DateTime(2022, 03, 30),
                EndingDate = new DateTime(2022, 04, 20),
                Image = "/FileSystem/Pictures/chacunsoneverest1.jpg",
                IsHighlighted = true,
                Field = "Social"
            }) ;
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 2,
                AssociationId = 1,
                Name = "Achat d'équipements",
                Description = "L’équipement indispensable aux activités de montagne étant fourni pour nos stages (veste gore tex, veste polaire, pantalon, chaussures de randonnée, chaussons d’escalade, bottes de neige, gants, bonnet, lunette de soleil, sac à dos…), nous devons nous réapprovisionner en matériel",
                IsActive = true,
                CurrentAmount = 1500,
                DesiredAmount = 20000,
                StartingDate = new DateTime(2022, 03, 30),
                EndingDate = new DateTime(2022, 03, 30),
                Image = "/FileSystem/Pictures/chacunsoneverest2.jpg",
                IsHighlighted = true,
                Field = "Social"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 3,
                AssociationId = 1,
                Name = "Rénovation des locaux",
                Description = "Un lieu d’accueil, de Vie, de « résilience ». pour laisser la place au repos, et offrir à ces femmes un temps de reprise de souffle. Un lieu d’accueil, de Vie, de « résilience ». Un lieu « cocooning »pour laisser la place au repos, et offrir à ces femmes un temps de reprise de souffle. Un lieu polyvalent, spécialement aménagé : un grand parc entoure la Maison, avec une vue apaisante sur le Mont-Blanc. Une grande salle d’escalade, un espace zen et son parc aventure.",
                IsActive = true,
                CurrentAmount = 500,
                DesiredAmount = 15000,
                StartingDate = new DateTime(2022, 04, 02),
                EndingDate = new DateTime(2022, 05, 15),
                Image = "/FileSystem/Pictures/chacunsoneverest3.jpg",
                IsHighlighted = true,
                Field = "Social"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 4,
                AssociationId = 2,
                Name = "Financement cantine",
                Description = "Au sud de la Grande « Île Rouge », à Tuléar, la sous-nutrition et la malnutrition sont particulièrement dramatiques. Selon les autorités locales, le taux de fréquentation de l’école est inférieur à 40%, et le taux réel de scolarisation encore plus faible. Si les enfants dans cette région ont certes un toit et une famille, très souvent, ils ne bénéficient que d’un seul repas par jour, parfois moins. C’est pourquoi l’association a décidé d’intervenir dans des cantines scolaires à Tuléar.",
                IsActive = true,
                CurrentAmount = 0,
                DesiredAmount = 18000,
                StartingDate = new DateTime(2022, 03, 15),
                EndingDate = new DateTime(2022, 04, 30),
                Image = "/FileSystem/Pictures/enfantsoleil1.jpg",
                IsHighlighted = true,
                Field = "Enseignement"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 5,
                AssociationId = 2,
                Name = "Nouveau centre d'accueil",
                Description = "Les enfants sont identifiés dans le cadre de rondes dans la ville organisées par un assistant social et un éducateur faisant partie du personnel. Leur rôle est de proposer aux enfants de passer la nuit en sécurité dans un Centre d’Accueil et d’Ecoute. Au sein de ce centre, les enfants sont accueillis par un éducateur et ont la possibilité de se laver, de prendre un repas, de jouer avec d’autres enfants et de dormir en sécurité.",
                IsActive = true,
                CurrentAmount = 0,
                DesiredAmount = 5000,
                StartingDate = new DateTime(2022, 03, 30),
                EndingDate = new DateTime(2022, 07, 06),
                Image = "/FileSystem/Pictures/enfantsoleil2.jpg",
                IsHighlighted = true,
                Field = "Défense des droits"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 6,
                AssociationId = 2,
                Name = "Nouveau foyer d'adolescent",
                Description = "A l’adolescence, l’enfant peut entamer une formation professionnelle ou des études supérieures, le jeune intègrera les Foyers des Grands Adolescents Garçons ou Filles (FGAG/FGAF). Il y rejoindra d’autres jeunes de son âge, également en formation ou étudiants. Ces ainés l’aideront à s’impliquer dans sa formation ou sa recherche de premier emploi. Pour soutenir les jeunes dans la recherche de leur orientation, l’association a développé des activités éducatives qui leurs permettent de découvrir de nouveaux métiers.",
                IsActive = true,
                CurrentAmount = 3000,
                DesiredAmount = 10000,
                StartingDate = new DateTime(2022, 03, 15),
                EndingDate = new DateTime(2022, 04, 15),
                Image = "/FileSystem/Pictures/enfantsoleil3.jpg",
                IsHighlighted = true,
                Field = "Humanitaire"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 7,
                AssociationId = 3,
                Name = "Soutien CRCM Bordeaux",
                Description = "Depuis 1992, Vaincre la Mucoviscidose apporte son soutien aux centres de soins. Les subventions attribuées doivent permettre de mieux répondre aux attentes des patients et des familles quant à l’organisation, la qualité et la continuité des soins, en adéquation avec les recommandations des professionnels de santé.",
                IsActive = true,
                CurrentAmount = 50,
                DesiredAmount = 75000,
                StartingDate = new DateTime(2022, 03, 30),
                EndingDate = new DateTime(2022, 04, 30),
                Image = "/FileSystem/Pictures/muco2.jpg",
                IsHighlighted = true,
                Field = "Recherche"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 8,
                AssociationId = 3,
                Name = "Soutien CRCM Dijon",
                Description = "Depuis 1992, Vaincre la Mucoviscidose apporte son soutien aux centres de soins. Les subventions attribuées doivent permettre de mieux répondre aux attentes des patients et des familles quant à l’organisation, la qualité et la continuité des soins, en adéquation avec les recommandations des professionnels de santé.",
                IsActive = true,
                CurrentAmount = 74250,
                DesiredAmount = 100000,
                StartingDate = new DateTime(2022, 02, 28),
                EndingDate = new DateTime(2022, 04, 07),
                Image = "/FileSystem/Pictures/muco3.jpg",
                IsHighlighted = true,
                Field = "Humanitaire"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 9,
                AssociationId = 3,
                Name = "Soutien CRCM Caen",
                Description = "Depuis 1992, Vaincre la Mucoviscidose apporte son soutien aux centres de soins. Les subventions attribuées doivent permettre de mieux répondre aux attentes des patients et des familles quant à l’organisation, la qualité et la continuité des soins, en adéquation avec les recommandations des professionnels de santé.",
                IsActive = true,
                CurrentAmount = 2500,
                DesiredAmount = 10000,
                StartingDate = new DateTime(2022, 03, 30),
                EndingDate = new DateTime(2022, 04, 15),
                Image = "/FileSystem/Pictures/muco1.jpg",
                IsHighlighted = true,
                Field = "Culture"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 10,
                AssociationId = 11,
                Name = "Maison de Tom Pouce",
                Description = "Créée en 1987, la Maison de Tom Pouce qui héberge et accompagne les femmes enceintes a besoin d'équipement postnatale dont des tables à langer.",
                IsActive = false,
                CurrentAmount = 2350,
                DesiredAmount = 2500,
                StartingDate = new DateTime(2022, 02, 15),
                EndingDate = new DateTime(2022, 03, 15),
                Image = "/FileSystem/Pictures/petitprince.jpg",
                IsHighlighted = false,
                Field = "Humanitaire"
            });
            _bddContext.Fundraising.Add(new Fundraising
            {
                Id = 11,
                AssociationId = 22,
                Name = "Rénovation des locaux",
                Description = "La Maison du Bonheur est une association à but non lucratif travaillant à relever le défi de la pauvreté",
                IsActive = true,
                CurrentAmount = 2500,
                DesiredAmount = 15000,
                StartingDate = new DateTime(2022, 03, 21),
                EndingDate = new DateTime(2022, 05, 15),
                Image = "/FileSystem/Pictures/maison.jpg",
                IsHighlighted = false,
                Field = "Social"
            });
        }

        // ADVIVES
        public void InitializeDB_Advices()
        {
            // Advice requests
            _bddContext.AdviceRequest.Add(new AdviceRequest { Id = 1, AdviceRequestSubject = "Don UE", AdviceRequestText = "Bonjour, \n\nLes dons au profit d’organismes dont le siège est situé dans l’Union européenne donnent-ils droit à réduction fiscale ?", Date = new DateTime(2022, 01, 01), CompletedRequest = false, AssociationId = 1, AssociationName = "Petits Princes" });
            _bddContext.AdviceRequest.Add(new AdviceRequest { Id = 2, AdviceRequestSubject = "Allocation pré-retraite", AdviceRequestText = "Bonjour, \n\nConserve-t-on son allocation de pré-retraite si l’on fait du bénévolat ?", Date = new DateTime(2022, 02, 02), CompletedRequest = true, AssociationId = 2, AssociationName = "WWF" });

            //Advices

            _bddContext.Advice.Add(new Advice { Id = 1, AdviceSubject = "Réponse à : Allocation pré-retraite", AdviceText = "Bonjour, \n\nSi le versement de l’allocation de pré-retraite est suspendu en cas de reprise d’une activité professionnelle (Code du travail, art. R. 5123-18), les activités bénévoles auprès d’associations sont en revanche possibles. Quelques restrictions sont néanmoins détaillées dans la Circulaire interministérielle(CDE) n° 75 - 85 du 10 décembre 1985 - reprise d’une activité professionnelle réduite par les préretraités(BO TR 86 / 9 - 10) : \n -l’activité bénévole dans le cadre d’une association ne doit pas remplacer du personnel salarié \n -l’activité bénévole ne doit pas être effectuée dans une association dans laquelle le pré-retraité a auparavant été salarié.", Date = new DateTime(2022, 02, 01), AdviceRequestId = 1, MemberId = 1, AssociationId = 1 });
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
            _bddContext.Address.Add(new Address { Id = 20, RoadNumber = "66", Road = "Avenue du Maine", City = "Paris", PostalCode = "75014", Country = "France" });
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
            _bddContext.Address.Add(new Address { Id = 30, RoadNumber = "181", Road = "Rue de Tolbiac", City = "Paris", PostalCode = "75013", Country = "France" });
            // 31 -> 40
            _bddContext.Address.Add(new Address { Id = 31, RoadNumber = "5 bis", Road = "Rue du Louvre", City = "Paris", PostalCode = "75024", Country = "France" });
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
            _bddContext.Address.Add(new Address { Id = 51, RoadNumber = "2", Road = "Chemin de Ronde", City = "Croissy sur Seine", PostalCode = "78290", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 52, RoadNumber = "6", Road = "Place des pistes", City = "Courchevel", PostalCode = "73120 ", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 53, RoadNumber = "209", Road = "impasse de Champs Fleuris", City = "Saint-Jorioz ", PostalCode = "74410  ", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 54, RoadNumber = "703", Road = "Rue Joseph Vallot", City = "Chamonix-Mont-Blanc", PostalCode = "74400  ", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 55, RoadNumber = "211", Road = "Avenue Jean Jaurès,", City = "Paris", PostalCode = "75019", Country = "France" });
            _bddContext.Address.Add(new Address { Id = 56, RoadNumber = "6", Road = "Rue de Picardie", City = "Castelnau-le-Lez", PostalCode = "34170", Country = "France" });
        }

        // Commandes
        public void InitializeDB_Order()
        {
            _bddContext.Order.Add(new Order { Id = 1, MemberId = 10, TicketsNumber = 2, PurchaseDate = new DateTime(2022, 03, 30), Amount = 30 });
            _bddContext.Order.Add(new Order { Id = 2, MemberId = 10, TicketsNumber = 3, PurchaseDate = new DateTime(2022, 04, 02), Amount = 18 });
            _bddContext.Order.Add(new Order { Id = 3, MemberId = 11, TicketsNumber = 1, PurchaseDate = new DateTime(2022, 03, 30), Amount = 20 });
            _bddContext.Order.Add(new Order { Id = 4, MemberId = 12, TicketsNumber = 3, PurchaseDate = new DateTime(2022, 04, 02), Amount = 18 });
        }

        // Commandes
        public void InitializeDB_Ticket()
        {
            _bddContext.Ticket.Add(new Ticket { Id = 1, Position = 1, OrderId = 1, AssociationEventId = 8 });
            _bddContext.Ticket.Add(new Ticket { Id = 2, Position = 2, OrderId = 1, AssociationEventId = 8 });
            _bddContext.Ticket.Add(new Ticket { Id = 3, Position = 1, OrderId = 2, AssociationEventId =11 });
            _bddContext.Ticket.Add(new Ticket { Id = 4, Position = 2, OrderId = 2, AssociationEventId =11});
            _bddContext.Ticket.Add(new Ticket { Id = 5, Position = 3, OrderId = 2, AssociationEventId =11});
            _bddContext.Ticket.Add(new Ticket { Id = 6, Position = 1, OrderId = 3, AssociationEventId =1});
            _bddContext.Ticket.Add(new Ticket { Id = 7, Position = 1, OrderId = 4, AssociationEventId = 6 });
            _bddContext.Ticket.Add(new Ticket { Id = 8, Position = 2, OrderId = 4, AssociationEventId = 6 });
            _bddContext.Ticket.Add(new Ticket { Id = 9, Position = 3, OrderId = 4, AssociationEventId = 6 });
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
