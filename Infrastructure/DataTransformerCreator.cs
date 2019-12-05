using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Infrastructure.Transformers.TransformerExtension;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {

        public static IDataTransformer CreateTransformer(ReportConfig config) //decorator, наследники ReportServiceTransformer - конкретные декораторы
            //Был написан билдер на декоратор, в планах можно маппить стринг из конфига в мтод билдера, чтобы удобнее добавлять команды
        {
            IDataTransformer service = new DataTransformer(config);

            DataTransformerBuilder builder = new DataTransformerBuilder();

            if (config.WithData)
            {
                builder = builder.WithData();
            }

            if (config.VolumeSum)
            {
                builder = builder.WithVolumeSum();
            }

            if (config.WeightSum)
            {
                builder = builder.WithWeightSum();
            }

            if (config.CostSum)
            {
                builder = builder.WithCostSum();
            }

            if (config.CountSum)
            {
                builder.WithCountSum();
            }

            return builder.Build();
        }
    }
}