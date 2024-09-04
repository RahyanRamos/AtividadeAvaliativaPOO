using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativaPOO.Models
{
    internal class Venda
    {
        public int idVenda { get; set; }
        public DateOnly data { get; set; }
        public TimeOnly hora { get; set; }
        public double valor { get; set; }
        public double desconto { get; set; }
        public double valorFinal { get; set; }
        public string tipo { get; set; }
        public int fkCliente { get; set; }
    }
}
