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
        /// <summary>
        /// 单例模式
        /// </summary>
        private static LineCollect instance = new LineCollect();
        public static LineCollect Instance
        { get { return instance; } }
        /// <summary>
        /// 获取线路并转换为所需要的类型
        /// </summary>
        /// <param name="model"></param>
        /// <param name="flag", 选择是否为修正图层></param>
        /// <returns></returns>
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
