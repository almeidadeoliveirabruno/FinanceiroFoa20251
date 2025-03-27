using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Cliente Cliente { get; set; }
        public Conta(int numero, double saldo, Cliente cliente)
        {
            Numero = numero;
            Saldo = saldo;
            Cliente = cliente;
        }
        public void Depositar(double valor)
        {
            Saldo += valor;
        }
        public void Sacar(double valor)
        {
            Saldo -= valor;
        }
        public void Transferir(double valor, Conta contaDestino)
        {
            Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }
}
