using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAdviceRequestService
    {
        // à changer
        public int CreateAdviceRequest(AdviceRequest adviceRequest);
        public void DeleteAdviceRequeste(int id);

        // List of Advice Request
        List<AdviceRequest> GetAllAdviceRequests();
    }
}
