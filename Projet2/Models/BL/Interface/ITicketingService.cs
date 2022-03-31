namespace Projet2.Models.BL.Interface
{
    public interface ITicketingService
    {
        public void CreateTicket(Ticket ticket);

        public void DeleteTicket(int id);

    }
}
