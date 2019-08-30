using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace BB.Poker.Common
{
    public class Logger : DisposableComponent
    {
        public string LogPath { get; protected set; }

        private TextWriterTraceListener Writer;

        public Logger(string filePath)
        {
            Writer = new TextWriterTraceListener(filePath); Writer.Dispose();
        }

        public void WriteLine(object obj)
        {
            Writer.WriteLine(obj);
            Writer.WriteLine(Environment.NewLine);
            Writer.Flush();
        }

        protected override void DisposeManagedResources()
        {
            Writer.Close();
        }

        protected override void DisposeUnmanagedResources()
        {
        }
    }
}
