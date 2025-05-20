using Engine;
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
            throw new NotImplementedException();
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
            else return Enumerable.Empty<T>();                  
        }

        public List<string> Update(EntityBase entity)
        {
            var list = new List<string>();

            if (entity is AreeEntity areeEntity)
            {
                List<AreeEntity> areeEntities = new List<AreeEntity>();
                var aree = mDoc.Root.Element("Aree")?.Elements("Area");

                if (aree != null)
                {
                    foreach (var area in aree)
                    {
                        string codice = area.Attribute("Codice")?.Value;
                        if (codice == areeEntity.Codice)
                            area.SetAttributeValue("Descrizione", areeEntity.Descrizione);
                    }
                }

                mDoc.Save("path.xml");
                return list;

            }
            else return list;
        }
    }
}
