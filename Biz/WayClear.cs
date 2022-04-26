using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSMRoadExtract.Model;

namespace OSMRoadExtract.Biz
{
    internal class WayClear
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private static WayClear instance = new WayClear();
        public static WayClear Instance
        { get { return instance; } }
        public List<WayModel> RemoveBuilding( OSMModel model)
        {     
            List<WayModel> cleanWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                int flag = 0;
                foreach (var tag in way.tags)
                {
                    if (tag.key.Equals("building"))
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                    cleanWay.Add(way);

            }
            return cleanWay;
            
        }
        public List<WayModel> OnlyRoadWay( OSMModel model)
        {
            List<WayModel> needWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                bool flag = false;
                foreach (var tag in way.tags)
                {
                    if (tag.key.Equals("highway"))
                    {
                        needWay.Add(way);
                    }
                    
                }
            }
            return needWay;
        }
    }
}
