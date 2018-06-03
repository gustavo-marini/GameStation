using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    class CarrinhoItem
    {
        private int codigo, quantidade;

        public int getCodigo()
        {
            return codigo;
        }

        public CarrinhoItem setCodigo(int cod)
        {
            codigo = cod;
            return this;
        }

        public int getQuantidade()
        {
            return quantidade;
        }

        public CarrinhoItem setQuantidade(int qtd)
        {
            quantidade = qtd;
            return this;
        }
    }
}
