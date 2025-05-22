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
      
        public AreeManager(IDialogService dialogService) : base(dialogService) 
        {
            //Entity = new AreeEntity();
            Engine = new AreeEngine();
        }


        protected override EngineBase GetEngine()
        {
            throw new NotImplementedException();
        }

        protected override void OnDataChanged(string property)
        {
            switch (property)
            {
                case "Codice":
                    if(String.IsNullOrEmpty(((AreeEntity)base.Entity).Descrizione))
                        ((AreeEntity)base.Entity).Descrizione = $"Area: {((AreeEntity)base.Entity).Codice}";
                    break;
            
            }
        }

    }
}
