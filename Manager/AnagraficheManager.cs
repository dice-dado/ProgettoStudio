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

        public AnagraficheManager(IDialogService dialogService) : base(dialogService)
        { 
            Engine = new AnagraficheEngine();        
        }


        protected override void OnDataChanged(string property)
        {
            switch (property)
            {
                case "RagioneSociale":
                    ((AnagraficaEntity)Entity).Telefono = "1111111111";
                    break;

                default:
                    break;
            }
        }


        protected override EngineBase GetEngine()
        {
            throw new NotImplementedException();
        }
    }
}
