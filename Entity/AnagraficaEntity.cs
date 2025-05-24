using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private BindingList<RiferimentoEntity> mRiferimenti = [];
        public BindingList<RiferimentoEntity> Riferimenti
        {
            get { return mRiferimenti; }
            set
            {
                if (mRiferimenti != value)
                {
                    mRiferimenti = value ?? [];
                    RaiseNotifyPropertyChanged(nameof(Riferimenti));
                }
            }
        }

        public AnagraficaEntity( int idAnagrafica, string ragioneSociale, string partitaIVA, string indirizzo, string telefono)
        {
            mIdAnagrafica = idAnagrafica;
            mRagioneSociale = ragioneSociale;
            mPartitaIVA = partitaIVA;
            mIndirizzo = indirizzo;
            mTelefono = telefono;

        }

        public void AddRiferimento(RiferimentoEntity riferimento, bool unchanged)
        {
            Riferimenti.Add(riferimento);                        
        }


        public void SetRiferimenti(BindingList<RiferimentoEntity> riferimenti, bool unchanged)
        {
            Riferimenti = riferimenti;
        }

        public AnagraficaEntity()
        { 
        
        }

        private void Riferimenti_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                var newItem = mRiferimenti[e.NewIndex];
                if (newItem != null)
                {
                    newItem.IdAnagrafica = this.IdAnagrafica;
                    newItem.IdRiferimento = Riferimenti.OrderBy(r => r.IdRiferimento).FirstOrDefault()?.IdRiferimento?? 0 + 1;
                }
            }
        }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(RagioneSociale))
                throw new InvalidOperationException("La ragione sociale non può essere vuota.");

            return !string.IsNullOrWhiteSpace(PartitaIVA);
        }

    }

    
}
