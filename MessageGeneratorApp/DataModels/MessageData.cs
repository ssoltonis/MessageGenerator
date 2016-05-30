using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageGeneratorApp.DataModels
{
    public class MessageData
    {
        public int ThreadID { get; set; }

        public DateTime Time { get; set; }

        public string Message { get; set; }
    }
}
