using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSMRoadExtract.Model;

namespace OSMRoadExtract.Provider
{
    public class LineSearchProvider
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private static LineSearchProvider instance = new LineSearchProvider();
        public static LineSearchProvider Instance
        { get { return instance; } }
        
        /// <summary>
        /// 获取路径的名称
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLineName(OSMModel model ,long id)
        {
            string name ="";
            var ws = model.ways.Where(
                w => w.id.Equals(id)).Select(d=>d.tags.Where(
                    t=>t.key.Equals("name")).Select(n => n.value).ToList()).ToList();
            if(ws.Count()!=0&&ws[0].Count!=0)
                return ws[0][0];
            return name;
        }
    }
}
