using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class AnagraficheEngine : EngineBase
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
           
            return result;
        }

        public override List<string> Update(EntityBase entity)
        {
            return base.Update(entity);
        }
    }
}
