using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PSO2_DO_Bot
{
    class ExtraData
    {
        public string StartDate { get; set; }
        public List<ClientOrder> ExtraOrder { get; set; }
    }

    class OtherOrderCalculator
    {
        List<ExtraData> m_otherOrderDatas;
        public OtherOrderCalculator(string filename)
        {
            string input;
            using (StreamReader sr = new StreamReader(filename))
            {
                input = sr.ReadToEnd();
            }
            m_otherOrderDatas = JsonConvert.DeserializeObject<List<ExtraData>>(input);
        }
        ClientOrder GetOtherOrder()
        {
            return null;
        }

        public List<ClientOrder> GetTargetDateOtherOrder(DateTimeOffset targetDate, TimeSpan offset)
        {
            DateTimeOffset startDate = new DateTimeOffset(m_startDate, offset);
            int days = (targetDate - startDate).Days;

            List<DailyOrder> result = m_dailyOrders.FindAll(daily =>
            {
                return daily.Schedule.Contains((days % daily.cycle) + 1);
            });

            return result;
        }

        public List<ClientOrder> GetTargetDateDailyOrderJP(DateTimeOffset targetDate)
        {
            return GetTargetDateOtherOrder(targetDate, new TimeSpan(9, 0, 0));
        }

        public List<ClientOrder> GetTargetDateDailyOrderGlobal(DateTimeOffset targetDate)
        {
            return GetTargetDateOtherOrder(targetDate, new TimeSpan(-7, 0, 0));
        }
    }
}
