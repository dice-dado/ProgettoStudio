using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class EntityBase : BindableEntity
    {
        public EntityBase() 
        {
            //TBD gestire il cambio sul manager
            base.PropertyChanged += (sender, e) => { 
                
                if(EntityState != EntityState.Added)
                    EntityState = EntityState.Modified; 
            };
        
        } 
   
        public EntityState EntityState { get; set; }

        public abstract bool IsValid();

    }
}
