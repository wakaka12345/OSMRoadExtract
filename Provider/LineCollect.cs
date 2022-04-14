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
        public Dictionary<long, PointF[]> LineGet(OSMModel model)
        {
            Dictionary<long, PointF[]> result = new Dictionary<long, PointF[]>();
            if (model.Equals(null))
            {
                return result;
            }
            
            (var lineList,var bound) = LineExtract.Instance.GetLine(model);
            result = LineExtract.Instance.PointFaggregate(lineList, model, bound);
            return result;
        }
    }
}
