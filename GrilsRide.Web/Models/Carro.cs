using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GirlsRide.Web.Models
{
    public class Carro
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        public string ModeloCarro { get; set; }
        public string Placa { get; set; }
        public string SenhaPorta { get; set; }


        // relacionamento 1:N

        public IList<Carro> Carros { get; set; }

    }

}
