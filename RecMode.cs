using System.Collections.Generic;
using System.Linq;

namespace Gnss
{
    public class RecMode
    {
        private const string mode = "mode";
        private const string status = "status";
        private const string rtk = "RTK";
        private const string pd = "pd";
        //private const string off = "off";
        //private const string on = "on";

        public string Name { get; set; }
        public bool Mode => RawParams != null && RawParams.TryGetValue(mode, out string val) && (Name == rtk ? val == pd : !Constants.OffVal.Contains(val));
        public string ModeRaw => RawParams != null && RawParams.TryGetValue(mode, out string val) && !Constants.OnVal.Contains(val) && !Constants.OffVal.Contains(val) ? val : null;
        public string Status => RawParams != null && RawParams.TryGetValue(status, out string val) ? val : null;
        public Dictionary<string, string> AuxParams => RawParams.Where(d => d.Key != mode && d.Key != status).ToDictionary(d => d.Key, d => d.Value);
        public Dictionary<string, string> RawParams { get; set; }
    }

}
