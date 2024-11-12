namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (this.Suite.Capacidade >= hospedes.Count())
            {
                Hospedes = hospedes;
            }
            else
            {
                Console.WriteLine($"ERRO: A capacidade da suíte ({this.Suite.Capacidade}) é inferior ao número de hóspedes recebidos ({hospedes.Count}).");
                // Obs.: Removendo Exception para não interromper a execução
                //throw new Exception($"ERRO: A capacidade da suíte ({this.Suite.Capacidade}) é inferior ao número de hóspedes recebidos ({hospedes.Count}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count();
        }

        public decimal CalcularValorDiarias()
        {
            decimal valor = this.DiasReservados * this.Suite.ValorDiaria;

            if (this.DiasReservados >= 10)
            {
                valor = valor * 0.9m;
            }

            return valor;
        }
    }
}
