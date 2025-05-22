﻿using Engine;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlDal
{
    public class XmlDAL : IDAL
    {   

        XDocument mDoc;

        public XmlDAL()
        {
            CaricaXML();        
        }

        private void CaricaXML()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XMLData.xml");

            mDoc = XDocument.Load(path);
        }

        public T Read<T>()
        {
            throw new NotImplementedException();
        }

        public T Read<T>(object pkValue)
        {
            if (typeof(T) == typeof(AreeEntity))
            {
                var aree = mDoc.Root.Element("Aree")?.Elements("Area");

                if (aree != null)
                {
                    foreach (var area in aree)
                    {
                        string codice = area.Attribute("Codice")?.Value;
                        string descrizione = area.Attribute("Descrizione")?.Value;
                        if(codice == pkValue.ToString())
                            return (T)(object)new AreeEntity { Codice = codice, Descrizione = descrizione };
                    }
                }

                return default;
            }
            if (typeof(T) == typeof(AnagraficaEntity))
            {

                var anagrafiche = mDoc.Root.Element("Anagrafiche")?.Elements("Anagrafica");

                if (anagrafiche != null)
                {
                    foreach (var anagrafica in anagrafiche)
                    {
                        if (anagrafica.Attribute("IdAnagrafica").Value != pkValue.ToString())
                            continue;

                        var anagraficaCorrente = new AnagraficaEntity
                        {
                            IdAnagrafica = (int?)anagrafica.Attribute("IdAnagrafica") ?? 0,
                            RagioneSociale = anagrafica.Attribute("RagioneSociale")?.Value,
                            PartitaIVA = anagrafica.Attribute("PartitaIva")?.Value,
                            Indirizzo = anagrafica.Attribute("Indirizzo")?.Value,
                            Telefono = anagrafica.Attribute("Telefono")?.Value                            
                        };

                        var riferimenti = anagrafica.Elements("Riferimento");

                        foreach (var riferimento in riferimenti)
                        {
                            var riferimentoCorrente = new RiferimentoEntity
                            {
                                Nome = riferimento.Attribute("Nome")?.Value,
                                Cognome = riferimento.Attribute("Cognome")?.Value,
                                Telefono = riferimento.Attribute("Telefono")?.Value
                            };

                            anagraficaCorrente.Riferimenti.Add(riferimentoCorrente);
                        }

                        return (T)(object)anagraficaCorrente;
                    }
                }

                return default;

            }

            else return default;
        }

        public IEnumerable<T> ReadAll<T>()
        {
            if (typeof(T) == typeof(AreeEntity))
            {
                List<AreeEntity> areeEntities = new List<AreeEntity>();

                var aree = mDoc.Root.Element("Aree")?.Elements("Area");

                if (aree != null)
                {

                    foreach (var area in aree)
                    {
                        string codice = area.Attribute("Codice")?.Value;
                        string descrizione = area.Attribute("Descrizione")?.Value;

                        areeEntities.Add(new AreeEntity { Codice = codice, Descrizione = descrizione });    
                    }
                }

                return areeEntities.Cast<T>();
            }
            if (typeof(T) == typeof(AnagraficaEntity))
            {
                List<AnagraficaEntity> anagraficheEntities = new List<AnagraficaEntity>();

                var anagrafiche = mDoc.Root.Element("Anagrafiche")?.Elements("Anagrafica");

                if (anagrafiche != null)
                {

                    foreach (var anagrafica in anagrafiche)
                    {
                        var anagraficaCorrente = new AnagraficaEntity
                        {
                            IdAnagrafica = (int?)anagrafica.Attribute("IdAnagrafica") ?? 0,
                            RagioneSociale = anagrafica.Attribute("RagioneSociale")?.Value,
                            PartitaIVA = anagrafica.Attribute("PartitaIva")?.Value,
                            Indirizzo = anagrafica.Attribute("Indirizzo")?.Value,
                            Telefono = anagrafica.Attribute("Telefono")?.Value
                        };

                        var riferimenti = anagrafica.Elements("Riferimento");

                        foreach (var riferimento in riferimenti)
                        {
                            var riferimentoCorrente = new RiferimentoEntity
                            {
                                Nome = riferimento.Attribute("Nome")?.Value,
                                Cognome = riferimento.Attribute("Cognome")?.Value,
                                Telefono = riferimento.Attribute("Telefono")?.Value
                            };

                            anagraficaCorrente.Riferimenti.Add(riferimentoCorrente);
                        }
                        
                        anagraficheEntities.Add(anagraficaCorrente);
                    }
                }

                return anagraficheEntities.Cast<T>();

            }

            else return Enumerable.Empty<T>();                  
        }

        public List<string> Update(EntityBase entity)
        {
            var list = new List<string>();

            if (entity is AreeEntity areeEntity)
            {
                var areeContainer = mDoc.Root.Element("Aree");
                var aree = areeContainer?.Elements("Area");

                if (aree != null)
                {
                    bool found = false;
                    foreach (var area in aree)
                    {
                        string codice = area.Attribute("Codice")?.Value;
                        if (codice == areeEntity.Codice)
                        { 
                            area.SetAttributeValue("Descrizione", areeEntity.Descrizione);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        var areaElement = new XElement("Area",
                                    new XAttribute("Codice", areeEntity.Codice ?? string.Empty),
                                    new XAttribute("Descrizione", areeEntity.Descrizione ?? string.Empty)
                                );

                        areeContainer.Add(areaElement);
                    }
                    
                }

                mDoc.Save("XMLData.xml");
                return list;

            }
            else if (entity is AnagraficaEntity anagraficaEntity)
            {
                var anagraficheContainer = mDoc.Root.Element("Anagrafiche");
                var anagrafiche = anagraficheContainer?.Elements("Anagrafica");

                if (anagrafiche != null)
                {
                    bool found = false;

                    foreach (var anagrafica in anagrafiche)
                    {
                        string id = anagrafica.Attribute("IdAnagrafica")?.Value;

                        if (id == anagraficaEntity.IdAnagrafica.ToString())
                        {
                            found = true;

                            anagrafica.SetAttributeValue("IdAnagrafica", anagraficaEntity.IdAnagrafica);
                            anagrafica.SetAttributeValue("RagioneSociale", anagraficaEntity.RagioneSociale);
                            anagrafica.SetAttributeValue("PartitaIva", anagraficaEntity.PartitaIVA);
                            anagrafica.SetAttributeValue("Indirizzo", anagraficaEntity.Indirizzo);
                            anagrafica.SetAttributeValue("Telefono", anagraficaEntity.Telefono);

                            anagrafica.Elements("Riferimento").Remove();

                            foreach (var riferimento in anagraficaEntity.Riferimenti)
                            {
                                var riferimentoElement = new XElement("Riferimento",
                                    new XAttribute("Nome", riferimento.Nome ?? string.Empty),
                                    new XAttribute("Cognome", riferimento.Cognome ?? string.Empty),
                                    new XAttribute("Telefono", riferimento.Telefono ?? string.Empty)
                                );

                                anagrafica.Add(riferimentoElement);
                            }

                            break; 
                        }

                        
                    }
                    if (!found)
                    {                      
                        var anagraficaElement = new XElement("Anagrafica",
                                    new XAttribute("IdAnagrafica", anagraficaEntity.IdAnagrafica),
                                    new XAttribute("RagioneSociale", anagraficaEntity.RagioneSociale ?? string.Empty),
                                    new XAttribute("PartitaIva", anagraficaEntity.PartitaIVA ?? string.Empty),
                                    new XAttribute("Indirizzo", anagraficaEntity.Indirizzo ?? string.Empty),
                                    new XAttribute("Telefono", anagraficaEntity.Telefono ?? string.Empty)
                                );

                        foreach (var riferimento in anagraficaEntity.Riferimenti)
                        {
                            var riferimentoElement = new XElement("Riferimento",
                                new XAttribute("Nome", riferimento.Nome ?? string.Empty),
                                new XAttribute("Cognome", riferimento.Cognome ?? string.Empty),
                                new XAttribute("Telefono", riferimento.Telefono ?? string.Empty)
                            );

                            anagraficaElement.Add(riferimentoElement);
                        }

                        anagraficheContainer.Add(anagraficaElement);
                    }
                }

                mDoc.Save("XMLData.xml");
                return list;
            }

            else return list;
        }
    }
}
