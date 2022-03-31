using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoadExtract.Model
{
    public class WayModel
    {
        public int id;
        private List<TagModel> _tags;
        public List<TagModel> tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public List<WayNode> waynode;

    }
    
    public class WayNode
    {
        int id;
    }
}