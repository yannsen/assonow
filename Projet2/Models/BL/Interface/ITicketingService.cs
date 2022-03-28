namespace Projet2.Models.BL.Interface
{
    public interface ITicketingService
    {
        public int CreateTicket(Ticket ticket);

        public void DeleteTicket(int id);

    }
}
