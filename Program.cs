using AtividadeAvaliativaPOO.Dao;
using AtividadeAvaliativaPOO.Models;

try
{
    //Venda v = new Venda();
    //VendaDAO vDAO = new VendaDAO();

    //v.data = new DateOnly(2024, 11, 11);
    //v.hora = new TimeOnly(10, 20, 00);
    //v.valor = 100;
    //v.desconto = 20;
    //v.valorFinal = 80;
    //v.tipo = "A Vista";
    //v.fkCliente = 1;
    //vDAO.Insert(v);

    VendaDAO vendaDAO = new VendaDAO();
    RecebimentoDAO recebimentoDAO = new RecebimentoDAO();
    bool continuar = true;

    while (continuar)
    {
        Console.Clear();
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Inserir Venda");
        Console.WriteLine("2 - Atualizar Venda");
        Console.WriteLine("3 - Deletar Venda");
        Console.WriteLine("4 - Listar Vendas");
        Console.WriteLine("0 - Sair");
        Console.Write("Opção: ");
        string opcao = Console.ReadLine();
        Console.Clear();

        switch (opcao)
        {
            case "1":
                {
                    Venda v = new Venda();

                    Console.Write("Data da Venda (yyyy-mm-dd): ");
                    v.data = DateOnly.Parse(Console.ReadLine());

                    Console.Write("Hora da Venda (HH:mm:ss): ");
                    v.hora = TimeOnly.Parse(Console.ReadLine());

                    Console.Write("Valor Total: ");
                    v.valor = double.Parse(Console.ReadLine());

                    Console.Write("Desconto: ");
                    v.desconto = double.Parse(Console.ReadLine());

                    Console.Write("Valor Final: ");
                    v.valorFinal = double.Parse(Console.ReadLine());

                    Console.Write("Tipo da Venda: ");
                    v.tipo = Console.ReadLine();

                    Console.Write("ID do Cliente: ");
                    v.fkCliente = int.Parse(Console.ReadLine());

                    vendaDAO.Insert(v);

                    Console.Write("Quantas parcelas serão pagas? ");
                    int parcelas = int.Parse(Console.ReadLine());
                    double valorParcela = v.valorFinal / parcelas;
                    for (int i = 1; i <= parcelas; i++)
                    {
                        Recebimento r = new Recebimento();
                        r.valor = valorParcela;

                        Console.Write($"Data de vencimento da parcela {i} (yyyy-mm-dd): ");
                        r.vencimento = DateOnly.Parse(Console.ReadLine());

                        Console.Write($"Data de pagamento da parcela {i} (yyyy-mm-dd), ou deixe em branco se ainda não foi pago: ");
                        string pagamentoInput = Console.ReadLine();
                        r.pagamento = string.IsNullOrWhiteSpace(pagamentoInput) ? DateOnly.MinValue : DateOnly.Parse(pagamentoInput);

                        Console.Write($"Status da parcela {i} (ex: Pendente, Pago): ");
                        r.status = Console.ReadLine();

                        Console.Write($"ID do Caixa para a parcela {i}: ");
                        r.fkCaixa = int.Parse(Console.ReadLine());

                        r.fkVenda = v.idVenda;

                        recebimentoDAO.Insert(r);
                    }

                    Console.ReadKey();
                    break;
                }
            case "2":
                {
                    Venda v = new Venda();

                    Console.Write("ID da Venda a ser atualizada: ");
                    v.idVenda = int.Parse(Console.ReadLine());

                    Console.Write("Nova Data da Venda (yyyy-mm-dd): ");
                    v.data = DateOnly.Parse(Console.ReadLine());

                    Console.Write("Nova Hora da Venda (HH:mm:ss): ");
                    v.hora = TimeOnly.Parse(Console.ReadLine());

                    Console.Write("Novo Valor Total: ");
                    v.valor = double.Parse(Console.ReadLine());

                    Console.Write("Novo Desconto: ");
                    v.desconto = double.Parse(Console.ReadLine());

                    Console.Write("Novo Valor Final: ");
                    v.valorFinal = double.Parse(Console.ReadLine());

                    Console.Write("Novo Tipo da Venda: ");
                    v.tipo = Console.ReadLine();

                    Console.Write("Novo ID do Cliente: ");
                    v.fkCliente = int.Parse(Console.ReadLine());

                    vendaDAO.Update(v);

                    Console.ReadKey();
                    break;
                }
            case "3":
                {
                    Venda v = new Venda();

                    Console.Write("ID da Venda a ser deletada: ");
                    v.idVenda = int.Parse(Console.ReadLine());

                    vendaDAO.Delete(v);

                    Console.ReadKey();
                    break;
                }
            case "4":
                {
                    List<Venda> vendas = vendaDAO.List();

                    foreach (var venda in vendas)
                    {
                        Console.WriteLine("ID: " + venda.idVenda);
                        Console.WriteLine("Data: " + venda.data.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Hora: " + venda.hora.ToString("HH:mm"));
                        Console.WriteLine("Valor Total: " + venda.valor);
                        Console.WriteLine("Desconto: " + venda.desconto);
                        Console.WriteLine("Valor Final: " + venda.valorFinal);
                        Console.WriteLine("Tipo: " + venda.tipo);
                        Console.WriteLine("Cliente ID: " + venda.fkCliente);
                        Console.WriteLine("=======");
                    }

                    Console.ReadKey();
                    break;
                }
            case "0":
                continuar = false;
                break;
            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                Console.ReadKey();
                break;
        }
        Console.WriteLine();
    }
}
catch (Exception)
{

	throw;
}