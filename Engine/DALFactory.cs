using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class DALFactory
    {
        private static string mfullQualifiedName { get; set; }

        static DALFactory()
        {
            var config = (NameValueCollection)ConfigurationManager.GetSection("DALSettings");

            mfullQualifiedName = config["fullQualifiedName"];
        }

        public static IDAL Create() 
        {
            return (IDAL)Activator.CreateInstance(Type.GetType(mfullQualifiedName));        
        }


    }
}
