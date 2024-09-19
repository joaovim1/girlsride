using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GirlsRide.Web.Models
{
    public class Cliente
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone, Required]
        public string Telefone { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string partida { get; set; }
        [Required]
        public string chegada { get; set; }

        //Relacionamento 1:N
        public Carro Carros { get; set; }
        public int CarroId { get; set; }

        public Cartao Cartoes { get; set; }
        public int CartaoId { get; set; }

        //Relacionamento 1:1
        public Pagamento Pagamentos {get; set; }
        public int PagamentosId { get; set; }

        //relacionamento N:M
        public IList<ClienteAgendamento> clienteAgendamentos { get; set; }







    }
}
