using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trabalhows.Models
{
    public class Pessoa
    {
        public int Id {get; set;}
        public string nome {get; set;}
        public string cpf {get; set;}
        public int idade {get; set;}
        public Pessoa(string nome, string cpf, int idade)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.idade = idade;
        }


    }
}