using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMRoadExtract.Model
{
    public class PathModel
    {
        private List<GraphicsPath> _path;
        
        public List<GraphicsPath> path
        {
            get { return _path; }
            set { _path = value; }
        }

        private long _id;
        public long id
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<PointF[]> _pointlist;
        public List<PointF[]> pointlist
        {
            get { return _pointlist; }
            set { _pointlist = value; }
        }

        public PathModel(List<GraphicsPath> path,  long id,  List<PointF[]> pointlist)
        {
            this.path = path;
            this.id = id;
            this.pointlist = pointlist;
        }

    }
}
