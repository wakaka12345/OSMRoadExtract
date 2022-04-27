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
        /// <summary>
        /// 主要道路
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WayModel> PrimaryWay(OSMModel model)
        {
            List<WayModel> needWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                bool flag = false;
                foreach (var tag in way.tags)
                {
                    if (tag.value.Equals("primary")|| tag.value.Equals("primary_link")|| tag.value.Equals("trunk")|| tag.value.Equals("trunk_link"))
                    {
                        flag = true;
                    }
                }
                if(flag)
                    needWay.Add(way);
            }
            return needWay;
        }
        /// <summary>
        /// 次要道路
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WayModel> SecondaryWay(OSMModel model)
        {
            List<WayModel> needWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                bool flag = false;
                foreach (var tag in way.tags)
                {
                    if (tag.value.Equals("secondary") || tag.value.Equals("secondary_link"))
                    {
                        flag = true;
                    }
                }
                if (flag)
                    needWay.Add(way);
            }
            return needWay;
        }
        /// <summary>
        /// 城市支路
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WayModel> TertiaryWay(OSMModel model)
        {
            List<WayModel> needWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                bool flag = false;
                foreach (var tag in way.tags)
                {
                    if (tag.value.Equals("tertiary") || tag.value.Equals("tertiary_link"))
                    {
                        flag = true;
                    }
                }
                if (flag)
                    needWay.Add(way);
            }
            return needWay;
        }
        /// <summary>
        /// 居住区道路
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WayModel> ResidentialWay(OSMModel model)
        {
            List<WayModel> needWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                bool flag = false;
                foreach (var tag in way.tags)
                {
                    if (tag.value.Equals("residential"))
                    {
                        flag = true;
                    }
                }
                if (flag)
                    needWay.Add(way);
            }
            return needWay;
        }
        /// <summary>
        /// 其他道路
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WayModel> OtherWay(OSMModel model)
        {
            List<WayModel> needWay = new List<WayModel>();
            foreach (var way in model.ways)
            {
                bool flag = false;
                foreach (var tag in way.tags)
                {
                    if (tag.value.Equals("unclassified")||tag.value.Equals("track"))
                    {
                        flag = true;
                    }
                }
                if (flag)
                    needWay.Add(way);
            }
            return needWay;
        }
    }
}
