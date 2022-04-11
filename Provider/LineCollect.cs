using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OSMRoadExtract.Model;
using OSMRoadExtract.Biz;

namespace OSMRoadExtract.Provider
{
    internal class LineCollect
    {
        public Dictionary<string,List<Point>> LineGet(OSMModel model)
        {
            Dictionary<string, List<Point>> result = new Dictionary<string, List<Point>>();
            if (model.Equals(null))
            {
                return result;
            }
            
            var lineList = LineExtract.Instance.GetLine(model);
            return result;
        }
    }
}
