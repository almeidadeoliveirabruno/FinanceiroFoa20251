using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    class ContaCaixinha : Conta
    {
        public ContaCaixinha(decimal saldo, Cliente cliente) : base(saldo, cliente)
        {
        }

        public ContaCaixinha(Cliente cliente) : base(cliente)
        {
        }

        public override void Depositar(decimal valor)
        {
            if (valor < 1)
            {
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }
            base.Depositar(valor);
            Saldo += 1;
        }
        public override void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            }
            valor += 5;
            base.Sacar(valor);
        }
    }
}
