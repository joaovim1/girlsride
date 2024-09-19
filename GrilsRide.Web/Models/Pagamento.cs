using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GirlsRide.Web.Models
{
    public class Pagamento
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string metodoPagamento { get; set; }
        public double Total { get; set; }

    }
}
