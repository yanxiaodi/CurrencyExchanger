/***********************************************************
 *
 *   Written on:    3/21/2010
 *   by:            Kambiz Nazridoust
 * 
 ************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YanSoft.CurrencyExchanger.Core.Calculator.HelperModules
{
    public enum FunctionType : int
    {
        TwoD = 0,
        TwoDP = 1,
        ThreeDP = 2,
        Polar = 3,
        IsoSurface = 4
    }


    /// <summary>
    /// The interface of Function
    /// </summary>
    public interface IFunction
    {
        string Name { get; set; }
        string xExpression { get; set; }
        string yExpression { get; set; }
        string zExpression { get; set; }

        string xMin { get; set; }
        string xMax { get; set; }

        string yMin { get; set; }
        string yMax { get; set; }

        string tMin { get; set; }
        string tMax { get; set; }
        string tStep { get; set; }

        string xGrid { get; set; }
        string yGrid { get; set; }
    }

    /// <summary>
    /// Functon to be plotted
    /// </summary>
    public class Function : IFunction
    {
        /// <summary>
        /// 2D XY Function
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="yExpression"></param>
        public Function(string Name, string yExpression)
        {
            this.Name = Name;
            this.yExpression = yExpression.ToLower();

            this.xMin = Settings.xMinDefault;
            this.xMax = Settings.xMaxDefault;

            this.yMin = Settings.yMinDefault;
            this.yMax = Settings.yMaxDefault;

            this.type = FunctionType.TwoD;
        }

        /// <summary>
        /// 2D XY Function
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="yExpression"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        public Function(string Name, string yExpression, string xMin, string xMax, string yMin, string yMax)
            : this(Name, yExpression)
        {
            this.xMin = xMin;
            this.xMax = xMax;

            this.yMin = yMin;
            this.yMax = yMax;

            this.type = FunctionType.TwoD;
        }

        /// <summary>
        /// 2D Parametric Function
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="xExpression"></param>
        /// <param name="yExpression"></param>
        public Function(string Name, string xExpression, string yExpression)
            : this(Name, yExpression)
        {
            this.xExpression = xExpression.ToLower();

            this.tMin = Settings.tMin2DDefault;
            this.tMax = Settings.tMax2DDefault;
            this.tStep = Settings.tStep2DDefault;

            this.type = FunctionType.TwoDP;
        }

        /// <summary>
        ///  2D Parametric Function
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="xExpression"></param>
        /// <param name="yExpression"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="tMin"></param>
        /// <param name="tMax"></param>
        /// <param name="tStep"></param>
        public Function(string Name, string xExpression, string yExpression, string xMin, string xMax, string yMin, string yMax, string tMin, string tMax, string tStep)
            : this(Name, yExpression, xMin, xMax, yMin, yMax)
        {
            this.xExpression = xExpression.ToLower();

            this.tMin = tMin;
            this.tMax = tMax;
            this.tStep = tStep;

            this.type = FunctionType.TwoDP;
        }

        /// <summary>
        ///  3D Parametric Function
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="xExpression"></param>
        /// <param name="yExpression"></param>
        /// <param name="zExpression"></param>
        public Function(string Name, string xExpression, string yExpression, string zExpression)
            : this(Name, xExpression, yExpression)
        {
            this.zExpression = zExpression.ToLower();
            this.xGrid = Settings.uGridDefault;
            this.yGrid = Settings.vGridDefault;

            this.type = FunctionType.ThreeDP;
        }

        /// <summary>
        ///  3D Parametric Function
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="xExpression"></param>
        /// <param name="yExpression"></param>
        /// <param name="zExpression"></param>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="xGrid"></param>
        /// <param name="yGrid">any number</param>
        public Function(string Name, string xExpression, string yExpression, string zExpression, string xMin, string xMax, string yMin, string yMax, string xGrid, string yGrid, int dummy)
            : this(Name, yExpression, xMin, xMax, yMin, yMax)
        {
            this.xExpression = xExpression.ToLower();
            this.zExpression = zExpression.ToLower();
            this.xGrid = xGrid;
            this.yGrid = yGrid;

            this.type = FunctionType.ThreeDP;
        }

        #region Properties


        public string Name { get; set; }

        public string xExpression { get; set; }
        public string yExpression { get; set; }
        public string zExpression { get; set; }

        public string xMin { get; set; }
        public string xMax { get; set; }

        public string yMin { get; set; }
        public string yMax { get; set; }

        public string tMin { get; set; }
        public string tMax { get; set; }
        public string tStep { get; set; }

        public string xGrid { get; set; }
        public string yGrid { get; set; }

        public FunctionType type { get; private set; }

        #endregion
    }
}
