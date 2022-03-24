using Projet2.Models.BL.Interface;

namespace Projet2.Models.BL.Service
{
    public class AdviceService : IAdviceService
    {
        private BddContext _bddContext;

        public AdviceService()
        {
            _bddContext = new BddContext();
        }
        
        // add an advice in db
        public int CreateAdvice(AdviceViewModel viewModel)
        {
            // A COMPLETER 
            Advice advice = new Advice {/* AdviceRequestId = , AdviceRequest =,*/ AdviceSubject = , AdviceText = , Date = /*, Id =*/, Member = /*,MemberId = */}; 
            _bddContext.Advice.Add(advice);
            _bddContext.SaveChanges();
            return advice.Id;
        }

        // delete an advice in db
        public void DeleteAdvice(int id)
        {
            Advice advice = _bddContext.Advice.Find(id);
            if (advice != null)
            {
                _bddContext.Advice.Remove(advice);
                _bddContext.SaveChanges();
            }
        }

    }
}
