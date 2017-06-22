/***********************************************************
 *
 *   Modified on:    3/29/2010
 *   by:            Kambiz Nazridoust
 * 
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XD.UWP.CurrencyExchanger.UWPAPP.Calculator.HelperModules
{
    public class Settings
    {
        public const string uMin = "u|Min";
        public const string uMax = "u|Max";
        public const string uGrid = "u|Grid";
        public const string vMin = "v|Min";
        public const string vMax = "v|Max";
        public const string vGrid = "v|Grid";
        public const string xMin = "x|min";
        public const string xMax = "x|max";
        public const string yMin = "y|min";
        public const string yMax = "y|max";
        public const string tMin2D = "t|Min";
        public const string tMax2D = "t|Max";
        public const string tStep2D = "t|Step";

        public const string uMinDefault = "-pi";
        public const string uMaxDefault = "pi";
        public const string uGridDefault = "24";
        public const string vMinDefault = "0";
        public const string vMaxDefault = "pi";
        public const string vGridDefault = "48";
        public const string xMinDefault = "-10";
        public const string xMaxDefault = "10";
        public const string yMinDefault = "-10";
        public const string yMaxDefault = "10";
        public const string xMin2DDefault = "-10";
        public const string xMax2DDefault = "10";
        public const string yMin2DDefault = "-10";
        public const string yMax2DDefault = "10";
        public const string tMin2DDefault = "0";
        public const string tMax2DDefault = "10pi";
        public const string tStep2DDefault = "pi/24";

        public const string fx = "x( u,v )=";
        public const string fy = "y( u,v )=";
        public const string fz = "z( u,v )=";
        public const string y = "y=";
        public const string xt = "x( t )=";
        public const string yt = "y( t )=";

        public static Function default2D = new Function("Wavelet", "(sin(2pi*x)-sin(pi*x))/pi/x");
        public static Function default2DP = new Function("Spiral", "sin(t)*t/pi", "cos(t)*t/pi");
        public static Function default3DP = new Function("Sphere", "cos(u)sin(v)", "-cos(v)", "sin(-u)sin(v)", "-pi", "pi", "0", "pi", "24", "48", 0);
    }
}
