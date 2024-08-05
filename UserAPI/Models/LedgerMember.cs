namespace UserAPI.Models
{
    public class LedgerMember
    {
        public int LedgerMemberId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int LedgerId { get; set; }
        public Ledger Ledger { get; set; }
    }
}
