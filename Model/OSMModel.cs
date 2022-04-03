using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoadExtract.Model
{
    public class OSMModel
    { 
        /// <summary>
        /// 坐标点(私有)
        /// </summary>
        private List<NodeModel> _nodes;
        /// <summary>
        /// 坐标点
        /// </summary>
        public List<NodeModel> nodes
        {
            set { _nodes = value; }
            get { return _nodes; }
        }

        /// <summary>
        /// 边界经纬度(私有)
        /// </summary>
        private List<BoundsModel> _bounds;
        
        /// <summary>
        /// 边界经纬度
        /// </summary>
        public List<BoundsModel> bounds
        {
            set { _bounds = value; }
            get { return _bounds; }
        }

        private List<WayModel> _ways;

        public List<WayModel> ways
        {
            get { return _ways; }
            set { _ways = value; }
        }
        public double version;
    }
}
