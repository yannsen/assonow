using Projet2.Models.BL.Interface;

namespace Projet2.Models.BL.Service
{
    public class AssociationMemberService : IAssociationMemberService
    {
        private BddContext _bddContext;
        public AssociationMemberService()
        {
            _bddContext = new BddContext();
        }

        public int CreateAssociationMember(int idAssociation, int idMember)
        {
            AssociationMember associationMember = new AssociationMember() { AssociationId = idAssociation, MemberId = idMember };
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
    }
}
