using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoStudio
{
    public interface ICardForm
    {
        IEnumerable<T> ReadAll<T>() where T : EntityBase;

        void ReadAllAsync<T>(Action<IEnumerable<T>> callback, Action<Exception> excCallback) where T : EntityBase;  

        void ShowModal(EntityBase entity);

    }
}
