using System.Collections.Generic;

namespace Projet2.Models.BL.Interface
{
    public interface IAdviceService
    {
        // A CHANGER
        //public int CreateAdvice(AdviceViewModel viewModel);
        public void DeleteAdvice(int id);

        public int CreateAdvice(Advice advice);

        public Advice GetAdvice(int id);

        public List<Advice> GetReadAdvice(int id);

        public List<Advice> GetNewAdvice(int id);

        public void IsRead(int id);

    }
}
