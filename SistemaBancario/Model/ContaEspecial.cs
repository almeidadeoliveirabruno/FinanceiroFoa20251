using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class ContaEspecial : Conta
    {
        public decimal Limite { get; private set; }
        public ContaEspecial(decimal saldo) : base(saldo)
        {
        }

        public ContaEspecial(Cliente cliente) : base(cliente)
        {
        }

        public ContaEspecial(decimal saldo, decimal limite) : base(saldo)
        {
            if (limite < 0)
            {
                throw new ArgumentException("O limite não pode ser negativo.");
            }
            Limite = limite;
        }

        public override void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            }
            if (valor > Saldo + Limite)
            {
                throw new InvalidOperationException("Saldo e limite insuficientes para realizar o saque.");
            }
            Saldo -= valor;
        }
        public override void Transferir(decimal valor, Conta contaDestino)
        {
            if (valor > Saldo + Limite)
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            base.Transferir(valor, contaDestino);
        }
    }
}
