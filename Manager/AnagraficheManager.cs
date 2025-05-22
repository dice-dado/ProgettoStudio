using Engine;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Manager
{
    public class AnagraficheManager : ManagerBase
    {

        public AnagraficheManager() 
        { 
            Engine = new AnagraficheEngine();        
        }

        protected override EngineBase GetEngine()
        {
            throw new NotImplementedException();
        }
    }
}
