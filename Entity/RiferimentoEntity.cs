using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RiferimentoEntity : BindableEntity
    {
        private int mIdAnagrafica;
        public int IdAnagrafica
        {
            get { return mIdAnagrafica; }
            set
            {
                if (mIdAnagrafica != value)
                {
                    mIdAnagrafica = value;
                    RaiseNotifyPropertyChanged(nameof(IdAnagrafica));
                }
            }
        }

        private int mIdRiferimento;
        public int IdRiferimento
        {
            get { return mIdRiferimento; }
            set
            {
                if (mIdRiferimento != value)
                {
                    mIdRiferimento = value;
                    RaiseNotifyPropertyChanged(nameof(IdRiferimento));
                }
            }
        }

        private string mNome;
        public string Nome
        {
            get { return mNome; }
            set
            {
                if (mNome != value)
                {
                    mNome = value;
                    RaiseNotifyPropertyChanged(nameof(Nome));
                }
            }
        }

        private string mCognome;
        public string Cognome
        {
            get { return mCognome; }
            set
            {
                if (mCognome != value)
                {
                    mCognome = value;
                    RaiseNotifyPropertyChanged(nameof(Cognome));
                }
            }
        }

        private string mTelefono;
        public string Telefono
        {
            get { return mTelefono; }
            set
            {
                if (mTelefono != value)
                {
                    mTelefono = value;
                    RaiseNotifyPropertyChanged(nameof(Telefono));
                }
            }
        }
    }
}
