using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoadExtract.Model
{
    public class BoundsModel
    {
        /// <summary>
        /// 最小纬度
        /// </summary>
        public double minLat;
        
        /// <summary>
        /// 最大纬度
        /// </summary>
        public double maxLat;

        /// <summary>
        /// 最小经度
        /// </summary>
        public double minLon;

        /// <summary>
        /// 最大经度
        /// </summary>
        public double maxLon;
    }
}