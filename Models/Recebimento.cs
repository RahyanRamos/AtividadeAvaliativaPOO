using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativaPOO.Models
{
    internal class Recebimento
    {
        public int idRecebimento {  get; set; }
        public double valor {  get; set; }
        public DateOnly vencimento { get; set; }
        public DateOnly pagamento { get; set; }
        public string status { get; set; }
        public int fkCaixa { get; set; }
        public int fkVenda { get; set; }
    }
}
