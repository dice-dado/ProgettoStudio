using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class AreeEngine : EngineBase
    {
        public override EntityBase Read()
        {
            return base.Read();
        }

        public override T Read<T>(object pkValue)
        {
            var dataLayer = DALFactory.Create();

            return dataLayer.Read<T>(pkValue);
        }

        public override IEnumerable<T> ReadAll<T>()
        {
            var dataLayer = DALFactory.Create();

            return dataLayer.ReadAll<T>();
        }

        public override List<string> CheckUpdate(EntityBase entity)
        {
            List<string> result = new List<string>();
            var dataLayer = DALFactory.Create();

            //if(dataLayer.ReadAll<AreeEntity>().Where(a => a.Codice.Substring(0, 1) == "N").Count() >= 2 && ((AreeEntity)entity).Codice.Substring(0, 1) == "N") 
            //{
            //    result.Add("Numero di N superiore al consentito");
            //}

            return result;
        }

        public override List<string> Update(EntityBase entity)
        {
            return base.Update(entity);
        }
    }
}
