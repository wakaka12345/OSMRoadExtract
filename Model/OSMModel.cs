﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoadExtract.Model
{
    internal class OSMModel
    { 
        /// <summary>
        /// 坐标点(私有)
        /// </summary>
        private List<NodeModel> _node;
        /// <summary>
        /// 坐标点
        /// </summary>
        public List<NodeModel> node
        {
            set { _node = value; }
            get { return _node; }
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

        private List<WayModel> ways;
    }
}