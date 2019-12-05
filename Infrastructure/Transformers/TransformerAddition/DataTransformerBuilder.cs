using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure.Transformers.TransformerExtension
{
    class DataTransformerBuilder 
    {
        IDataTransformer dataTransformer;

        public DataTransformerBuilder WithCostSum()
        {
            dataTransformer = new CostSumReportTransformer(dataTransformer);
            return this;
        }

        public DataTransformerBuilder WithCountSum()
        {
            dataTransformer = new CountSumReportTransformer(dataTransformer);
            return this;
        }

        public DataTransformerBuilder WithVolumeSum()
        {
            dataTransformer = new VolumeSumReportTransformer(dataTransformer);
            return this;
        }

        public DataTransformerBuilder WithWeightSum()
        {
            dataTransformer = new WeightSumReportTransfomer(dataTransformer);
            return this;
        }

        public DataTransformerBuilder WithData()
        {
            dataTransformer = new WithDataReportTransformer(dataTransformer);
            return this;
        }

        public IDataTransformer Build()
        {
            return dataTransformer;
        }
    }
}
