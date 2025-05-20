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

        public override EntityBase Read(object pkValue)
        {
            var dataLayer = DALFactory.Create();

            return dataLayer.Read<AnagraficaEntity>(pkValue);
        }

        public override IEnumerable<EntityBase> ReadAll()
        {
            var dataLayer = DALFactory.Create();

            return dataLayer.ReadAll<AnagraficaEntity>();
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
