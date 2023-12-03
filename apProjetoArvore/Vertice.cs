using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apProjetoArvore
{
    class Vertice<Dado> : IComparable<Vertice<Dado>> where Dado : IComparable<Dado>, IRegistro<Dado>, new()
    {
        public bool foiVisitado;
        public Dado rotulo;

        public Vertice(Dado rotulo)
        {
            this.rotulo = rotulo;
            foiVisitado = false;
        }

        public int CompareTo(Vertice<Dado> other)
        {
            return rotulo.CompareTo(other.rotulo);
        }
        public bool Equals(Vertice<Dado> other)
        {
            return rotulo.Equals(other.rotulo);
        }
    }
}
