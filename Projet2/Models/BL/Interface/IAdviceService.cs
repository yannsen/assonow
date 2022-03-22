namespace Projet2.Models.BL.Interface
{
    public interface IAdviceService
    {
        // A CHANGER
        public int CreateAdvice(AdviceViewModel viewModel);
        public void DeleteAdvice(int id);

    }
}
