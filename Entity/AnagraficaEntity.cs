using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AnagraficaEntity : EntityBase
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

        private string mRagioneSociale;
        public string RagioneSociale
        {
            get { return mRagioneSociale; }
            set
            {
                if (mRagioneSociale != value)
                {
                    mRagioneSociale = value;
                    RaiseNotifyPropertyChanged(nameof(RagioneSociale));
                }
            }
        }

        private string mPartitaIVA;
        public string PartitaIVA
        {
            get { return mPartitaIVA; }
            set
            {
                if (mPartitaIVA != value)
                {
                    mPartitaIVA = value;
                    RaiseNotifyPropertyChanged(nameof(PartitaIVA));
                }
            }
        }

        private string mIndirizzo;
        public string Indirizzo
        {
            get { return mIndirizzo; }
            set
            {
                if (mIndirizzo != value)
                {
                    mIndirizzo = value;
                    RaiseNotifyPropertyChanged(nameof(Indirizzo));
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

        private List<RiferimentoEntity> mRiferimenti;
        public List<RiferimentoEntity> Riferimenti
        {
            get { return mRiferimenti; }
            set
            {
                if (mRiferimenti != value)
                {
                    mRiferimenti = value;
                    RaiseNotifyPropertyChanged(nameof(Riferimenti));
                }
            }
        }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(RagioneSociale))
                throw new InvalidOperationException("La ragione sociale non può essere vuota (XX).");

            return !string.IsNullOrWhiteSpace(PartitaIVA);
        }
    }

    
}
