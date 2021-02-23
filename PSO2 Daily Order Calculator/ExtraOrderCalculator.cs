using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PSO2_DailyOrderCalculator
{
    class ExtraData
    {
        public string StartDate { get; set; }
        public List<ClientOrder> ExtraOrders { get; set; }
    }

    public class ExtraOrderCalculator
    {
        List<ExtraData> m_extraOrderData;
        public ExtraOrderCalculator(string filename)
        {
            string input;
            using (StreamReader sr = new StreamReader(filename))
            {
                input = sr.ReadToEnd();
            }
            m_extraOrderData = JsonConvert.DeserializeObject<List<ExtraData>>(input);
        }
        private ClientOrder GetExtraOrderFromSet(ExtraData extraData, DateTimeOffset targetDate, TimeSpan offset)
        {
            DateTimeOffset startDate = new DateTimeOffset(DateTime.Parse(extraData.StartDate), offset);
            int days = (targetDate - startDate).Days;
            return extraData.ExtraOrders[days % extraData.ExtraOrders.Count]; ;
        }

        public List<ClientOrder> GetTargetDateAllExtraOrders(DateTimeOffset targetDate, TimeSpan offset)
        {
            List<ClientOrder> result = new List<ClientOrder>();
            foreach (ExtraData extraData in m_extraOrderData)
            {
                result.Add(GetExtraOrderFromSet(extraData, targetDate, offset));
            }

            return result;
        }

        public List<ClientOrder> GetTargetDateAllExtraOrdersJP(DateTimeOffset targetDate)
        {
            return GetTargetDateAllExtraOrders(targetDate, new TimeSpan(9, 0, 0));
        }

        public List<ClientOrder> GetTargetDateAllExtraOrdersGlobal(DateTimeOffset targetDate)
        {
            return GetTargetDateAllExtraOrders(targetDate, new TimeSpan(-7, 0, 0));
        }
    }
}
