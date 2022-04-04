using Projet2.Models.BL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AssociationMemberService : IAssociationMemberService
    {
        private BddContext _bddContext;
        private IAssociationService associationService;
        private IMemberService memberService;

        public AssociationMemberService()
        {
            _bddContext = new BddContext();
            this.associationService = new AssociationService();
            this.memberService = new MemberService();
        }

        public int CreateAssociationMember(int associationId, int memberId)
        {
            AssociationMember associationMember = new AssociationMember() { AssociationId = associationId, MemberId = memberId };
            _bddContext.AssociationMember.Add(associationMember);
            _bddContext.SaveChanges();
            return associationMember.Id;
        }

        public void DeleteAssociationMember(int id)
        {
            AssociationMember associationMember = _bddContext.AssociationMember.Find(id);
            if (associationMember != null)
            {
                _bddContext.AssociationMember.Remove(associationMember);
                _bddContext.SaveChanges();
            }
        }

        public AssociationMember GetAssociationMember(int MemberId, int AssociationId)
        {
            return _bddContext.AssociationMember.FirstOrDefault(a => a.MemberId == MemberId && a.AssociationId == AssociationId);
        }

        public bool DoMembershipExist(int associationId, int memberId)
        {
            return _bddContext.AssociationMember.Any(a => a.AssociationId == associationId && a.MemberId == memberId);
        }

        public List<Association> GetAssociationsForMember(int id)
        {
            List<AssociationMember> associationsMembers = _bddContext.AssociationMember.Where(a => a.MemberId == id).ToList();
            List<Association> associations = new List<Association>();
            foreach (AssociationMember associationMember in associationsMembers)
                associations.Add(associationService.GetAssociation(associationMember.AssociationId));
            return associations;
        }

        public List<Member> GetMembersForAssociation(int id)
        {
            List<AssociationMember> associationsMembers = _bddContext.AssociationMember.Where(a => a.AssociationId == id).ToList();
            List<Member> members = new List<Member>();
            foreach (AssociationMember associationMember in associationsMembers)
                members.Add(memberService.GetMember(associationMember.MemberId));
            return members;
        }
    }
}
