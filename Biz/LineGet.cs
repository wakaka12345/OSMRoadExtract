using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void Compared(ref List<float> vs , NodeModel node)
        {
            if (vs[0] < node.lat)
                vs[0] = (float)node.lat;
            if(vs[1] > node.lat)
                vs[1] = (float)node.lat; 
            if(vs[2]<node.lon)
                vs[2] = (float)node.lon;
            if (vs[3] > node.lon)
                vs[3] = (float)node.lon;
        }
       
        /// <summary>
        /// 获取XML中points与Line对应的实际值
        /// 转换为 wayid - nodeList的Dictionary
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public (Dictionary<long, List<NodeModel>>,List<float>) GetLine(OSMModel model)
        {
            var line = new Dictionary<long, List<NodeModel>>();
            List<float> bound = new List<float>() {0,90,0,180 };
            if (model.Equals(null))
                return (line, bound); 
            var nodes = new Dictionary<long, NodeModel>();  
            //node.id-NodeModel的Dictionary方便快速查找
            foreach(var node in model.nodes)
            {
                if(!nodes.ContainsKey(node.id))
                {
                    nodes.Add(node.id, node);
                    Compared(ref bound, node);
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
            return (line, bound);
        }
        /// <summary>
        /// 转换为Graphics所需的PoinF  (处理后)
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="models"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public Dictionary<long,List<PointF[]>> FixPointFaggregate(Dictionary<long, List<NodeModel>> lines,OSMModel models,List<float> bounds)
        {
            Dictionary<long, List<PointF[]>> result = new Dictionary<long, List<PointF[]>>();
            float YSize = ((float)(models.bounds[0].maxLat-models.bounds[0].minLat));
            float XSize = ((float)(models.bounds[0].maxLon - models.bounds[0].minLon));
            float YMax = (float)(models.bounds[0].maxLat);
            float XMIN = (float)(models.bounds[0].minLon);
            var radixX = GlobalConstant.DRAW_X_SIZE / XSize;
            var radixY = GlobalConstant.DRAW_Y_SIZE / YSize;
            foreach(var line in lines)
            {
                int i = 0;
                List<PointF[]> pointList = new List<PointF[]>();
                List<PointF> listPoint = new List<PointF>();
                foreach(var node in line.Value)
                {
                    float X = (float)(node.lon-XMIN)*radixX+GlobalConstant.START_X;
                    float Y = (float)(YMax - node.lat)*radixY+GlobalConstant.START_Y;
                    if(X<0||Y<0)
                    {
                        if(i!=0)
                        {
                            PointF[] points = new PointF[listPoint.Count];
                            int k = 0;
                            foreach (var point in listPoint)
                            {
                                points[k] = point;
                                k++;
                            }
                            i = 0;
                            pointList.Add(points);
                            listPoint.Clear();
                        }
                        continue;
                    }
                    listPoint.Add(new PointF(X, Y));
                     i++;
                }
                if(i != 0)
                {
                    PointF[] points = new PointF[listPoint.Count];
                    int k = 0;
                    foreach (var point in listPoint)
                    {
                        points[k] = point;
                        k++;
                    }
                    i = 0;
                    listPoint.Clear();
                    pointList.Add(points);
                }
                result.Add(line.Key, pointList);
            }
            return result;
        }

        /// <summary>
        /// 转换为Graphics所需的PoinF  (处理前)
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="models"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public Dictionary<long, List<PointF[]>> UnFixPointFaggregate(Dictionary<long, List<NodeModel>> lines, OSMModel models, List<float> bounds)
        {
            Dictionary<long, List<PointF[]>> result = new Dictionary<long, List<PointF[]>>();
            float YSize = ((float)(models.bounds[0].maxLat - models.bounds[0].minLat));
            float XSize = ((float)(models.bounds[0].maxLon - models.bounds[0].minLon));
            float YMax = (float)(models.bounds[0].maxLat);
            float XMIN = (float)(models.bounds[0].minLon);
            var radixX = GlobalConstant.DRAW_X_SIZE / XSize;
            var radixY = GlobalConstant.DRAW_Y_SIZE / YSize;
            foreach (var line in lines)
            {
                int i = 0;
                List<PointF[]> pointList = new List<PointF[]>();
                List<PointF> listPoint = new List<PointF>();
                foreach (var node in line.Value)
                {
                    float X = (float)(node.lon - XMIN) * radixX + GlobalConstant.START_X;
                    float Y = (float)(YMax - node.lat) * radixY + GlobalConstant.START_Y;
                    if (X < 0 || Y < 0)
                    {
                        continue;
                    }
                    listPoint.Add(new PointF(X, Y));
                    i++;
                }
                if (i != 0)
                {
                    PointF[] points = new PointF[listPoint.Count];
                    int k = 0;
                    foreach (var point in listPoint)
                    {
                        points[k] = point;
                        k++;
                    }
                    i = 0;
                    listPoint.Clear();
                    pointList.Add(points);
                }
                result.Add(line.Key, pointList);
            }
            return result;
        }
    }
}
