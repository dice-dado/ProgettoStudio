using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public static class FilterExtensions
    {
        public static List<T> Filter<T>(this IEnumerable<T> instance, string text) where T : class
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (typeof(AreeEntity).IsAssignableFrom(typeof(T)))
                {
                    return instance.Cast<AreeEntity>().Where(r => r.Descrizione.StartsWith(text)).Cast<T>().ToList();
                }
                if (typeof(AnagraficaEntity).IsAssignableFrom(typeof(T)))
                {
                    return instance.Cast<AnagraficaEntity>().Where(r => r.RagioneSociale.StartsWith(text)).Cast<T>().ToList();
                }

            }
            return instance.ToList();        
        }

    }
}
