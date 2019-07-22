using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FarmAutomatorServer.Utils
{
    public static class AppSettings
    {
        // =========================== System Settings ===========================
        #region Integration Settings

        public static bool IsDebugging
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["IsDebugging"]);
            }
        }

        public static string DebugPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["DebugPassword"];
            }
        }

        public static int AuthenticationTokenMinutes
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["AuthenticationTokenMinutes"]);
            }
        }

        public static double AuthenicationTokenHours
        {
            get
            {
                return (double)AuthenticationTokenMinutes / 60;
            }
        }

        public static string[] GeneralDirSaleNo
        {
            get
            {
                var items =
                    ConfigurationManager.AppSettings["GeneralDirSaleNo"].Split(new[] {' ', ','},
                        StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());

                return items.ToArray();
            }
        }
        
        public static Dictionary<string, string> SupportingDirs
        {
            get
            {
                // Parse: 0042:0002 0062:0002 0015:00041
                // Dir segments
                var dirSegments = ConfigurationManager.AppSettings["SupportingDirs"].Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                // Dir brands
                // segment: 0042:0002
                var segments =
                    dirSegments.Select(seg => seg.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))
                        .Where(seg => seg.Length == 2);

                // segment2: {0042, 0002}
                return segments.ToDictionary(seg => seg[0], seg => seg[1]);
            }
        }

        /// <summary>
        /// Return dict of {sale: [brands]}
        /// </summary>
        public static Dictionary<string, string[]> SupportingDirBrands
        {
            get
            {
                // Parse: 0042:1,5 0062:5 0015:3
                // Dir segments
                var dirSegments = ConfigurationManager.AppSettings["SupportingDirBrands"].Split(new[] {' '},
                    StringSplitOptions.RemoveEmptyEntries);

                // Dir brands
                // segment: 0042:1,2
                var segments =
                    dirSegments.Select(seg => seg.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries))
                        .Where(seg => seg.Length == 2);

                // segment2: {0042, [1, 2]}
                var segments2 =
                    segments.Select(
                        segment2 =>
                            new
                            {
                                SaleNo = segment2[0],
                                BrandNos = segment2[1].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                            });

                return segments2.ToDictionary(kv => kv.SaleNo, kv => kv.BrandNos);
            }
        }

        #endregion Integration Settings

    }
}