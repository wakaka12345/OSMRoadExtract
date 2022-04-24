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
        private static LineCollect instance = new LineCollect();
        public static LineCollect Instance
        { get { return instance; } }
        public Dictionary<long, List<PointF[]>> LineGet(OSMModel model,bool flag)
        {
            Dictionary<long, List<PointF[]>> result = new Dictionary<long, List<PointF[]>>();
            if (model.Equals(null))
            {
                return result;
            }
            
            (var lineList,var bound) = LineExtract.Instance.GetLine(model);
            if(flag == true)
                result = LineExtract.Instance.FixPointFaggregate(lineList, model, bound);
            else 
                result = LineExtract.Instance.UnFixPointFaggregate(lineList, model, bound);
            return result;
        }
    }
}
