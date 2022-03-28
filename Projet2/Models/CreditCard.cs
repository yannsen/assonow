using System;

namespace Projet2.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        
        public int MemberId { get; set; }

        public Member Member { get; set; }

        public string CardNumber { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Cvc { get; set; }

        public DateTime DateTime { get; set; }
    }
}