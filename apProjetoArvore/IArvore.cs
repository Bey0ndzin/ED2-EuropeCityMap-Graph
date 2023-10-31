using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apProjetoArvore
{
    public enum Situacao
    {
        navegando, incluindo, pesquisando, editando, excluindo
    }
    interface IArvore<Dado> where Dado : IComparable<Dado>, IRegistro<Dado>, new()
    {
    }
}
