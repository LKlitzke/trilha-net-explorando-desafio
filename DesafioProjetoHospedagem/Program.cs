using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("-------- Hospedagem em Hotel v2 --------\n");
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Hóspede");
    Console.WriteLine("2 - Remover Hóspede");
    Console.WriteLine("3 - Listar Hóspedes");
    Console.WriteLine("4 - Cadastrar Suíte");
    Console.WriteLine("5 - Remover Suíte");
    Console.WriteLine("6 - Listar Suítes");
    Console.WriteLine("7 - Nova Reserva");
    Console.WriteLine("0 - Encerrar");

    switch (Console.ReadLine())
    {
        // Cadastrar Hóspede
        case "1":
            Console.WriteLine("Digite o nome do hóspede: ");
            var nomeToAdd = Console.ReadLine();
            Pessoa pessoa = new Pessoa(nome: nomeToAdd);
            hospedes.Add(pessoa);

            Console.WriteLine($"Hóspede {pessoa.Nome} cadastrada com sucesso.");
            break;

        // Remover Hóspede
        case "2":
            if (!hospedes.Any())
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
                break;
            }

            Console.WriteLine("Digite o nome do hóspede: ");
            var nomeToRemove = Console.ReadLine();

            var foundHospede = hospedes.Find(x => x.Nome.ToUpper() == nomeToRemove.ToUpper());
            if (foundHospede != null)
            {
                hospedes.Remove(foundHospede);
                Console.WriteLine($"Hóspede {nomeToRemove} removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Hóspede {nomeToRemove} não encontrado.");
            }
            break;

        // Listar Hóspedes
        case "3":
            if (hospedes.Any())
            {
                Console.WriteLine("Hóspedes cadastrados:");
                foreach (var hospede in hospedes)
                {
                    Console.WriteLine("- " + hospede.Nome);
                }
            }
            else
                Console.WriteLine("Não existem hóspedes cadastrados.");
            break;

        // Cadastrar Suíte
        case "4":
            var suiteToAdd = new Suite().CadastrarSuite();
            suites.Add(suiteToAdd);

            Console.WriteLine($"Suíte cadastrada com sucesso.");
            break;

        // Remover Suíte
        case "5":
            if (!suites.Any())
            {
                Console.WriteLine("Nenhuma suíte cadastrada.");
                break;
            }

            Console.WriteLine("Digite o tipo da suíte: ");
            var suiteToRemove = Console.ReadLine();

            var foundSuite = suites.Find(x => x.TipoSuite.ToUpper() == suiteToRemove.ToUpper());
            if (foundSuite != null)
            {
                suites.Remove(foundSuite);
                Console.WriteLine($"Suíte {suiteToRemove} removida com sucesso.");
            }
            else
            {
                Console.WriteLine($"Suíte {suiteToRemove} não encontrada.");
            }
            break;

        // Listar Suítes
        case "6":
            if (suites.Any())
            {
                Console.WriteLine("Suítes cadastradas:");
                foreach (var suiteItem in suites)
                {
                    Console.WriteLine(suiteItem.ToString());
                }
            }
            else
                Console.WriteLine("Não existem suítes cadastradas.");
            break;

        // Realizar Reserva
        case "7":
            if (!suites.Any())
            {
                Console.WriteLine("Nenhuma suíte cadastrada para reservar");
                break;
            }
            if (!hospedes.Any())
            {
                Console.WriteLine("Nenhum hóspede cadastrado para reservar.");
                break;
            }

            Console.WriteLine("Digite a quantidade de dias para reserva:");
            var diasReserva = int.Parse(Console.ReadLine());
            Reserva reserva = new Reserva(diasReservados: diasReserva);

            Console.WriteLine("Digite qual suíte reservar (selecione pelo número):");

            for(int i = 0; i < suites.Count; i++)
            {
                Console.WriteLine($"{i+1} - {suites[i].ToString()}");
            }

            var suiteNum = int.Parse(Console.ReadLine());
            reserva.CadastrarSuite(suites[suiteNum-1]);

            Console.WriteLine("Digite quais hóspedes alocar (selecione pelo número, separando apenas por vírgula):");
            for (int i = 0; i < hospedes.Count; i++)
            {
                Console.WriteLine($"{i+1} - {hospedes[i].Nome}");
            }
            Console.WriteLine("\n");
            int[] hospedesToReserve = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();

            var listHospedesToAdd = new List<Pessoa>();
            foreach (int i in hospedesToReserve)
            {
                listHospedesToAdd.Add(hospedes[i-1]);
            }
            reserva.CadastrarHospedes(listHospedesToAdd);
            Console.WriteLine($"Reserva cadastrada com sucesso.");
            Console.WriteLine($"Valor total das diárias: R$ {reserva.CalcularValorDiarias()}");
            break;

        case "0":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadLine();
}