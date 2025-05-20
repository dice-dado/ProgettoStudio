using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine
{
    public class EngineBase<T> where T : EntityBase
    {
        public T Read()
        {
            T result = default(T);

            return result;
        }
        public T Read(object pkValue)
        {
            T result = default(T);

            return result;
        }


        public IEnumerable<T> ReadAll()
        {
            IEnumerable<T> result = Enumerable.Empty<T>();

            var dataLayer = DALFactory.Create();

            return dataLayer.ReadAll<T>();
        }

        public List<string> Update(EntityBase entity)
        {
            var dataLayer = DALFactory.Create();

            dataLayer.Update(entity);

            return new List<string>();
        }

        public List<string> CheckUpdate(EntityBase entity)
        { 
            return new List<string>();
        }

    }
}
