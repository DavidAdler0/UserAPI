using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserAPI.Models
{
    public class Ledger
    {
        public int LedgerId { get; set; }
        public string Name { get; set; }
     
        public ICollection<LedgerMember> Members { get; set; }
    }
}
