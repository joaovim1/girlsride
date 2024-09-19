namespace GirlsRide.Web.Models
{
    public class Agendamento
    {

        public int Id {get; set;}
        public DateTime AgendamentoNo {get; set;}

        //Relacionamento N:M

        public IList<ClienteAgendamento> clienteAgendamentos {get; set;}
    }
}
