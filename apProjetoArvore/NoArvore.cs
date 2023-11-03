using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apProjetoArvore
{
    public class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>, IRegistro<Dado>, new()
    {
        Dado info;
        NoArvore<Dado> esquerda;
        NoArvore<Dado> direita;
        ListaDupla<Ligacao> caminhos;

        public NoArvore(Dado novo)
        {
            info = novo;
            caminhos = new ListaDupla<Ligacao>();
        }
        public Dado Info { get { return info; } set { info = value; } }
        public NoArvore<Dado> Esq { get { return esquerda; } set { esquerda = value; } }
        public NoArvore<Dado> Dir { get { return direita; } set { direita = value; } }
        public ListaDupla<Ligacao> Caminhos { get { return caminhos; } }

        public int CompareTo(NoArvore<Dado> other)
        {
            return info.CompareTo(other.info);
        }
        public bool Equals(NoArvore<Dado> other)
        {
            return info.Equals(other.info);
        }
    }
}
