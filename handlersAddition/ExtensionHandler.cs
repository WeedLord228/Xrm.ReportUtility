using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.handlers
{
    public class ExtensionHandler//Был реализован COR для обработки расширения файла, таким образом будет проще добавлять новые расширения
        //На обработчике возвращается объект, так что цепочка прервется в нужный момент
    {
        private static ExtensionHandler extensionHandler;

        public static ExtensionHandler GetInstance()//
        {
            if (extensionHandler != null)
                return extensionHandler;
            else
                extensionHandler = new ExtensionHandler();
            return extensionHandler;
        }

        AbstractExtensionHandler _handler;
        private ExtensionHandler()
        {

            _handler = new XlsxHandler(null);
            _handler = new TxtHandler(_handler);
            _handler = new CsvHandler(_handler);
        }

        public IReportService GetReportService(string[] args)
        {
            return _handler.GetReportService(args);
        }
    }
}
