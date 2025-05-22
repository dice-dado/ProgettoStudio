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
            
            errorList.AddRange(CheckUpdate(entity));

            if (errorList.Count==0)
            {
                if (entity.IsValid())
                {
                    var dataLayer = DALFactory.Create();

                    dataLayer.Update(entity);
                }
                else
                    errorList.Add("IsValid() error");
            }

            return errorList;
        }
        public abstract List<string> CheckUpdate(EntityBase entity);        

    }
}
