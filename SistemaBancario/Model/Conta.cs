using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class Conta
    {
        //caso o valor do saque seja maior que o saldo, o método deve lançar uma exceção
        //caso o valor do saque seja menor ou igual a zero, o método deve lançar uma exceção
        //caso o valor do deposito seja menor ou igual a zero, o método deve lançar uma exceção
        public long Numero { get; private set; }
        public decimal Saldo { get; protected set; }
        public Cliente Titular { get; protected set; }
        public Conta(decimal saldo)
        {
            if (saldo < 0)
            {
                throw new ArgumentException("O saldo inicial não pode ser negativo.");
            }
            Saldo = saldo;
        }
        public Conta(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");
            }
            Titular = cliente;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }
            Saldo += valor;
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do saque deve ser maior que zero.");
            }
            if (valor > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
            }
            Saldo -= valor;
        }
        public virtual void Transferir(decimal valor, Conta contaDestino)
        {
            if (contaDestino == null)
            {
                throw new ArgumentNullException(nameof(contaDestino), "Conta de destino não pode ser nula.");
            }
            if(valor <= 0)
                throw new ArgumentException("O valor da transferência deve ser maior que zero.");
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");
            Saldo -= valor;
            contaDestino.Depositar(valor);
        }
    }
}
