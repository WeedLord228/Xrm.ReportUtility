using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.handlers
{
    public abstract class AbstractExtensionHandler
    {
        protected abstract string Ext { get; }

        AbstractExtensionHandler nextHandler;

        protected AbstractExtensionHandler(AbstractExtensionHandler handler)
        {
            nextHandler = handler;
        }

        public virtual IReportService GetReportService(string[] args)
        {
            if (!args[0].EndsWith($"{Ext}"))
                return nextHandler.GetReportService(args);
            throw new NotSupportedException("this extension not supported");
        }
    }

    public class TxtHandler : AbstractExtensionHandler
    {
        protected override string Ext => ".txt";
        public override IReportService GetReportService(string[] args)
        {
            if (args[0].EndsWith(Ext))
                return new TxtReportService(args);
            return base.GetReportService(args);
        }
        public TxtHandler(AbstractExtensionHandler handler) : base(handler) { }
    }

    public class CsvHandler : AbstractExtensionHandler
    {
        protected override string Ext => ".csv";
        public override IReportService GetReportService(string[] args)
        {
            if (args[0].EndsWith(Ext))
                return new CsvReportService(args);
            return base.GetReportService(args);
        }
        public CsvHandler(AbstractExtensionHandler handler) : base(handler) { }
    }

    public class XlsxHandler : AbstractExtensionHandler
    {
        protected override string Ext => ".xlsx";
        public override IReportService GetReportService(string[] args)
        {
            if (args[0].EndsWith(Ext))
                return new XlsxReportService(args);
            return base.GetReportService(args);
        }
        public XlsxHandler(AbstractExtensionHandler handler) : base(handler) { }
    }
}
