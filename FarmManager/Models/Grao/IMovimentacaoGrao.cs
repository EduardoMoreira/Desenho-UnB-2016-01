using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManager.Models
{
    interface IMovimentacaoGrao
    {
        void attach(Grao grao);

        void detach(Grao grao);

        void notify(int quantidade);
    }
}
