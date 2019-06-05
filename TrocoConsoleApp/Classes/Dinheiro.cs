using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocoConsoleApp.Classes
{
    class Dinheiro
    {
        public readonly TipoDinheiro tipoDinheiro;
        private readonly int _valor;
        private readonly string _valorDescritivo;

        public int Valor => _valor;

        public string ValorDescritivo => _valorDescritivo;

        public Dinheiro(TipoDinheiro tipoDinheiro, int valor, string valorDescritivo)
        {
            this.tipoDinheiro = tipoDinheiro;
            this._valor = valor;
            this._valorDescritivo = valorDescritivo;
        }
    }
}
