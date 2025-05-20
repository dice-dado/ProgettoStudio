﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AreeEntity : EntityBase
    {        
        private string mCodice;
        public string Codice 
        {
            get { return mCodice; }
            set
            {
                if (mCodice != value)
                {
                    mCodice = value;
                    RaiseNotifyPropertyChanged(nameof(Codice));
                }
            }
        
        }

        private string mDescrizione;
        public string Descrizione 
        {
            get { return mDescrizione; }
            set
            {
                if (mDescrizione != value)
                {
                    mDescrizione = value;
                    RaiseNotifyPropertyChanged(nameof(Descrizione));
                }
            }
        
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
