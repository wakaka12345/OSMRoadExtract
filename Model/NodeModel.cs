using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoadExtract.Model
{
    public class NodeModel
    {
        private List<TagModel> _tag = new List<TagModel>(); 
        /// <summary>
        /// 标签
        /// </summary>
        public List<TagModel> Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        /// <summary>
        /// 坐标点id
        /// </summary>
        public long id;
        /// <summary>
        /// 坐标点纬度
        /// </summary>
        public double lat;
        /// <summary>
        /// 坐标点经度
        /// </summary>
        public double lon;

        public TagModel TagModel
        {
            get => default;
            set
            {
            }
        }
    }
}
