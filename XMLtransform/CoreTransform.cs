using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OSMRoadExtract.Model;

namespace OSMRoadExtract.XMLtransform
{
    internal class CoreTransform
    {
        public List<OSMModel> TransformXML()
        {
            List<OSMModel> models = new List<OSMModel>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\project\\OSMRoadExtract\\Data\\map.osm");
            return models;
        }
    }
}
