using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoStudio
{
    internal interface ICardForm
    {
        IEnumerable<T> ReadAll<T>() where T : EntityBase;

        void ShowModal(EntityBase entity);
    }
}
