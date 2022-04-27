using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSMRoadExtract.Model;
using OSMRoadExtract.Biz;

namespace OSMRoadExtract.Provider
{
    internal class LineSelect
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        private static LineSelect instance = new LineSelect();
        public static LineSelect Instance
        { get { return instance; } }
        /// <summary>
        /// 路径筛选
        /// </summary>
        /// <param name="model"></param>
        public List<WayModel> WaysClean(OSMModel model)
        {
            List<WayModel> result = model.ways;
            bool hasClean = false;
            if (GlobalConstant.REMOVEBUILDING)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                result = WayClear.Instance.RemoveBuilding(model);
            }
            if (GlobalConstant.ONLYROADWAY)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                result = WayClear.Instance.OnlyRoadWay(model);
            }
            if (GlobalConstant.PRIMARYWAY)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                if (result == null)
                {
                    result = WayClear.Instance.PrimaryWay(model);
                }
                else
                    result = result.Concat(WayClear.Instance.PrimaryWay(model)).ToList();
            }
            if (GlobalConstant.SECONDARYWAY)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                if (result == null)
                {
                    result = WayClear.Instance.SecondaryWay(model);
                }
                else
                    result = result.Concat(WayClear.Instance.SecondaryWay(model)).ToList();
            }
            if (GlobalConstant.TERTIARYWAY)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                if (result == null)
                {
                    result = WayClear.Instance.TertiaryWay(model);
                }
                else
                    result = result.Concat(WayClear.Instance.TertiaryWay(model)).ToList();
            }
            if (GlobalConstant.RESIDENTIALWAY)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                if (result == null)
                {
                    result = WayClear.Instance.ResidentialWay(model);
                }
                else
                    result = result.Concat(WayClear.Instance.ResidentialWay(model)).ToList();
            }
            if (GlobalConstant.OTHERWAY)
            {
                if (hasClean == false)
                {
                    hasClean = true;
                    result = null;
                }
                if (result == null)
                {
                    result = WayClear.Instance.OtherWay(model);
                }
                else
                    result = result.Concat(WayClear.Instance.OtherWay(model)).ToList();
            }
            return result;
        }
    }
}
