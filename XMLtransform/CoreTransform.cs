using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using OSMRoadExtract.Model;

namespace OSMRoadExtract.XMLtransform
{
    public class CoreTransform
    {
        public List<OSMModel> TransformXML()
        {
            List<OSMModel> models = new List<OSMModel>();
            var getXml = XDocument.Load("E:\\project\\OSMRoadExtract\\Data\\map.osm");
            var t= getXml.Root;
            models = (from osm in getXml.Descendants("osm")
                                       select new OSMModel
                                       {
                                           version = (double)osm.Attribute("version"),
                                           bounds = (from bound in osm.Descendants("bounds")
                                                     select new BoundsModel
                                                     {
                                                         maxLat = (double)bound.Attribute("maxlat"),
                                                         minLat = (double)bound.Attribute("minlat"),
                                                         maxLon = (double)bound.Attribute("maxlon"),
                                                         minLon = (double)bound.Attribute("minlon")
                                                     }).ToList(),
                                            nodes = (from node in osm.Descendants("node")
                                                      select new NodeModel
                                                      {
                                                          id = (int)node.Attribute("id"),
                                                          lat = (double)node.Attribute("lat"),
                                                          lon = (double)node.Attribute("lon"),
                                                          Tag = (from tag in node.Descendants("tag")
                                                                  select new TagModel
                                                                  {
                                                                      key = (string)tag.Attribute("k"),
                                                                      value = (string)tag.Attribute("v")
                                                                  }).ToList()
                                                      }).ToList(),
                                           ways = (from way in osm.Descendants("way")
                                                    select new WayModel
                                                    {
                                                        id = (int)way.Attribute("id"),
                                                        waynode = (from nd in way.Descendants("nd")
                                                                   select new WayNode
                                                                   {
                                                                       id = (int)nd.Attribute("ref"),
                                                                   }).ToList(),
                                                        tags = (from tag in way.Descendants("tag")
                                                                select new TagModel
                                                                {
                                                                    key = (string) tag.Attribute("k"),
                                                                    value = (string) tag.Attribute("v")
                                                                }).ToList()
                                                    }).ToList()
                                       }).ToList();
            //models = (
            //    from OSMModel in xmlDoc.Descendants())
            return models;
        }
    }
}
