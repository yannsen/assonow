using Projet2.Models.BL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models.BL.Service
{
    public class AdviceRequestService : IAdviceRequestService
    {
        private BddContext _bddContext;

        public AdviceRequestService()
        {
            _bddContext = new BddContext();
        }

        // add an advice in db
        public int CreateAdviceRequest(AdviceRequest adviceRequest)
        {
            _bddContext.AdviceRequest.Add(adviceRequest);
            _bddContext.SaveChanges();
            return adviceRequest.Id;
        }

        // delete an advice in db
        public void DeleteAdviceRequeste(int id)
        {
            AdviceRequest adviceRequest = _bddContext.AdviceRequest.Find(id);
            if (adviceRequest != null)
                _bddContext.AdviceRequest.Remove(adviceRequest);
                _bddContext.SaveChanges();
        }

        // get all requests for advice in the form of a list 
        public List<AdviceRequest> GetAllAdviceRequests()
        {
            return _bddContext.AdviceRequest.Where(a => a.CompletedRequest == false).ToList();
        }

        public AdviceRequest GetAdviceRequest(int id)
        {
            return _bddContext.AdviceRequest.Find(id);
        }

        public void Validate(int id)
        {
            AdviceRequest toUpdate = GetAdviceRequest(id);
            toUpdate.CompletedRequest = true;
            _bddContext.AdviceRequest.Update(toUpdate);
            _bddContext.SaveChanges();
        }
    }
}
