using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace Gnss
{
    public class ReceiverInfoParams
    {
        public string UpTime { get; set; } = string.Empty;
        public Dictionary<char, string> RecFiles { get; set; } = new Dictionary<char, string>();

        //public string FileA { get; set; } = string.Empty;

        //public string FileB { get; set; } = string.Empty;

        public string MemUsed { get; set; } = "-";

        public string MemTot { get; set; } = "-";

        //public string Cpu
        //{
        //    get { return _cpu; }
        //    set
        //    {
        //        _cpu = value;
        //    }
        //}

        public string CurMem { get; set; } = string.Empty;

        public int FileCount { get; set; }
        public float Soc { get; set; } = -1;
        public float SocB { get; set; } = -1;
        public string Mem
        {
            get
            {
                return MemUsed == "-" || MemTot == "?" ? "-" : ConvertUtils.BytesProgress(MemUsed, MemTot);
            }
        }
        public string UsedFreeTotalMem
        {
            get
            {
                return MemUsed == "-" || MemTot == "?" ? "-" : ConvertUtils.BytesProgressFreeUsedTot(MemUsed, MemTot);
            }
        }
        public string FreeMem
        {
            get
            {
                if (MemUsed == "-" || MemTot == "?")
                {
                    return "-";
                }

                long memUsed = 0;
                if (!long.TryParse(MemUsed, out memUsed))
                {
                    return "-";
                }

                long memTot = 0;
                return !long.TryParse(MemTot, out memTot) ? "-" : ConvertUtils.BytesProgress((memTot - memUsed).ToString(), MemTot);
            }
        }

        public int Dc { get; internal set; }
        public int DcB { get; internal set; }
        public int LockElm { get; internal set; }
        public int PosElm { get; internal set; }

        public Dictionary<string, string> RawParams { get; internal set; }
        //    = new Dictionary<string, string>
        //{
        //    {"test123", "456" },
        //    {"md_RTK_mode", "cd" },
        //    {"md_Heading_mode", "on" },
        //    {"md_INS/Tilt_mode", "poi" },
        //    {"md_INS/Tilt_status", "fail" },
        //    {"md_INS/Tilt_Pole", "0.123" },
        //    {"testq", "123" },
        //    {"md_AFRM_mode", "on" },
        //    {"md_AJM_mode", "on" },
        //    {"md_Spoofing_mode", "on" },
        //    {"md_Spoofing_Use in Pos.", "off" },
        //    {"test3", "test" },

        //};
        public IEnumerable<RecMode> RecModes
        {
            get
            {
                var modes = new List<RecMode>();
                if (RawParams == null || RawParams.Count == 0)
                {
                    return modes;
                }

                foreach(var d in RawParams.Where(k => k.Key.StartsWith("md_")))
                {
                    var toks = d.Key.Split('_');
                    var mod = modes.FirstOrDefault(m => m.Name == toks[1]);
                    if (mod == null)
                    {
                        mod = new RecMode() { Name = toks[1], RawParams = new Dictionary<string, string>()};
                        modes.Add(mod);
                    }
                    mod.RawParams.Add(toks[2], d.Value);
                }
                return modes;
            }
        }

            
            //new List<RecMode>()
        //{
        //        new RecMode() { Name = "RTK", Mode = true, ModeRaw = "pd"},
        //        new RecMode() { Name = "Heading", Mode = true},
        //        new RecMode()
        //{
        //    Name = "INS/Tilt", Mode = true, ModeRaw = "ins", Status = "ok", Params = new Dictionary<string, string>()
        //        {
        //            { "Pole", "0.000" },
        //        }},

        //        new RecMode() { Name = "AFRM", Mode = false},
        //        new RecMode() { Name = "AJM", Mode = true},
        //        new RecMode()
        //{
        //    Name = "Spoofing", Mode = false, Params = new Dictionary<string, string>()
        //        {
        //            { "Use in pos", "on" },
        //        }},
        //    };

    }

}
