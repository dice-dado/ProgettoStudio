using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine
{
    public abstract class EngineBase 
    {
        public virtual EntityBase Read()
        {         
            return default; 
        }
        public abstract T Read<T>(object pkValue) where T : EntityBase;
        public abstract IEnumerable<T> ReadAll<T>() where T : EntityBase;        
        public virtual List<string> Update(EntityBase entity)
        {
            var errorList = new List<string>();

            //Prima controllo validità entity (nel contesto client-server, la faccio due volte: una lato manager, prima dell'invio, e una lato server alla ricezione)
            if (entity.IsValid())
            {
                errorList.AddRange(CheckUpdate(entity));

                if (errorList.Count == 0)
                {
                    var dataLayer = DALFactory.Create();
                    errorList.AddRange(dataLayer.Update(entity));
                }                
            }
            else
            {
                errorList.Add("IsValid() error");
            }

            return errorList;
        }
        public abstract List<string> CheckUpdate(EntityBase entity);        

    }
}
