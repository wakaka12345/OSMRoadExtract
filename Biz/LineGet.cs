using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSMRoadExtract.Model;

namespace OSMRoadExtract.Biz
{
    public class LineExtract
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private static LineExtract instance = new LineExtract();
        public static LineExtract Instance
        { get { return instance; } }
       
        /// <summary>
        /// 获取XML中points与Line对应的实际值
        /// 转换为 wayid - nodeList的Dictionary
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Dictionary<long, List<NodeModel>> GetLine(OSMModel model)
        {
            var line = new Dictionary<long, List<NodeModel>>();
            if(model.Equals(null))
                return line; 
            var nodes = new Dictionary<long, NodeModel>();
            //node.id-NodeModel的Dictionary方便快速查找
            foreach(var node in model.nodes)
            {
                if(!nodes.ContainsKey(node.id))
                {
                    nodes.Add(node.id, node);
                }
            }
            //获取wayid - nodeList的Dictionary
            foreach (var way in model.ways)
            {
                List<NodeModel> nodeList = new List<NodeModel>();
                foreach(var roadId in way.waynode)
                {
                    if(nodes.ContainsKey(roadId.id))
                    {
                        nodeList.Add(nodes[roadId.id]);
                    }
                }
                line.Add(way.id,nodeList);
            }
            return line;
        }
    }
}
