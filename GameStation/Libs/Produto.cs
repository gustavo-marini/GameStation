using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    class Produto
    {
        public int codigo, codigo_desenvolvedor, codigo_disponibilidade, estoque;
        public double preco;
        public string nome, descricao;

        public override string ToString()
        {
            return nome;
        }
    }
}
