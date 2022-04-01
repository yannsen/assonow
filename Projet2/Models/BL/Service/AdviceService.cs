using Projet2.Models.BL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AdviceService : IAdviceService
    {
        private BddContext _bddContext;

        public AdviceService()
        {
            _bddContext = new BddContext();
        }
        
        public int CreateAdvice(Advice advice)
        {
            _bddContext.Advice.Add(advice);
            _bddContext.SaveChanges();
            return advice.Id;
        }

        public void DeleteAdvice(int id)
        {
            Advice advice = _bddContext.Advice.Find(id);
            if (advice != null)
            {
                _bddContext.Advice.Remove(advice);
                _bddContext.SaveChanges();
            }
        }

        public Advice GetAdvice(int id)
        {
            return _bddContext.Advice.Find(id);
        }

        public List<Advice> GetReadAdvice (int id)
        {
            return _bddContext.Advice.Where(a => a.IsRead == true & a.AssociationId == id).ToList();
        }

        public List<Advice> GetNewAdvice (int id)
        {
            return _bddContext.Advice.Where(a => a.IsRead == false & a.AssociationId == id).ToList();
        }

        public void IsRead(int id)
        {
            Advice advice = _bddContext.Advice.Find(id);
            advice.IsRead = true;
            _bddContext.Advice.Update(advice);
            _bddContext.SaveChanges();
        }

    }
}
