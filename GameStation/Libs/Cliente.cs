using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    public class Cliente
    {
        public int codigo, codigo_cidade, codigo_estado;
        public string nome, sobrenome, email;

        public override string ToString()
        {
            return nome + " " + sobrenome;
        }
    }
}
