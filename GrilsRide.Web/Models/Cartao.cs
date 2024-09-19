using System.ComponentModel.DataAnnotations;

namespace GirlsRide.Web.Models
{
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public string nrCartao { get; set; }
        public DateTime validade { get; set; }
        public int cvv { get; set; }
        public string nomeImpresso { get; set; }


        public IList<Cartao> Cartoes { get; set; }




    }
}
