namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public Suite CadastrarSuite()
        {
            Console.WriteLine("Digite o tipo da suíte: ");
            var tipoSuite = Console.ReadLine();

            Console.WriteLine("Digite a capacidade: ");
            var capacidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da diária (R$): ");
            var valorDiaria = decimal.Parse(Console.ReadLine());

            Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

            return suite;
        }

        public override string ToString()
        {
            return $"Suíte: {this.TipoSuite} | Capacidade: {this.Capacidade} | Valor Diária: {this.ValorDiaria}";
        }
    }
}