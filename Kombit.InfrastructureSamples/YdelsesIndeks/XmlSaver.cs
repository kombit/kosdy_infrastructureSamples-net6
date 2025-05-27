using Kombit.InfrastructureSamples.YdelseIndeksService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kombit.InfrastructureSamples.YdelsesIndeks
    {
    public class XmlSaver
        {
        public static void SaveRequestAsXml(fremsoegRequest request, string filePath)
            {
            XmlSerializer serializer = new XmlSerializer(typeof(fremsoegRequest));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                serializer.Serialize(fs, request);
                }
            }
        }
    }
