namespace GirlsRide.Web.Models
{
    public class ClienteAgendamento
    {
        //relacionamento 1:N (Cliente)
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        //relacionamento 1:N (Agendamento)

        public int AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; }
    }
}
