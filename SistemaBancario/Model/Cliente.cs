using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Model
{
    public class Cliente
    {
        public string Email { get; set; }
        public string Nome { get; private set; }
        public int AnoNascimento { get; private set; }
        public string Cpf { get; private set; }
        public Cliente(string nome, string cpf, int anoNascimento) 
        {
            if (int.Parse(DateTime.Now.ToString("yyyy")) - anoNascimento < 18)
                throw new ArgumentException("O cliente deve ter mais de 18 anos!");
            if (cpf.Length != 11)
                throw new ArgumentException("O CPF deve possuir 11 digitos");
            Nome = nome;
            AnoNascimento = anoNascimento;
            Cpf = cpf;
        }
    }

}
