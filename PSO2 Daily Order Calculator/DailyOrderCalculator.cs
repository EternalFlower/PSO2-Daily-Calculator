using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PSO2_DailyOrderCalculator
{
    class DailyOrderData
    {
        public string StartDate { get; set; }
        public List<DailyOrder> DailyOrders { get; set; }
    }

    class DailyOrderCalculator
    {
        DateTime m_startDate;
        List<DailyOrder> m_dailyOrders;
        public DailyOrderCalculator(string filename)
        {
            string input;
            using (StreamReader sr = new StreamReader(filename))
            {
                input = sr.ReadToEnd();
            }
            DailyOrderData data = JsonConvert.DeserializeObject<DailyOrderData>(input);
            m_startDate = DateTime.Parse(data.StartDate);
            m_dailyOrders = data.DailyOrders;
        }

        public List<DailyOrder> GetTargetDateDailyOrder(DateTimeOffset targetDate, TimeSpan offset)
        {
            DateTimeOffset startDate = new DateTimeOffset(m_startDate, offset);
            int days = (targetDate - startDate).Days;

            List<DailyOrder> result = m_dailyOrders.FindAll(daily =>
            {
                return daily.Schedule.Contains((days % daily.cycle) + 1);
            });

            return result;
        }

        public List<DailyOrder> GetTargetDateDailyOrderJP(DateTimeOffset targetDate)
        {
            return GetTargetDateDailyOrder(targetDate, new TimeSpan(9, 0, 0));
        }

        public List<DailyOrder> GetTargetDateDailyOrderGlobal(DateTimeOffset targetDate)
        {
            return GetTargetDateDailyOrder(targetDate, new TimeSpan(-7, 0, 0));
        }
    }
}
