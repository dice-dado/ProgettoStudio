using Engine;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class AreeManager : ManagerBase
    {

        public AreeManager() 
        {
            //Entity = new AreeEntity();
            Engine = new AreeEngine();
        }

        protected override EngineBase GetEngine()
        {
            throw new NotImplementedException();
        }
    }
}
