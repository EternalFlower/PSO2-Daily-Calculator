using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PSO2_DailyOrderCalculator
{
    public class FeatureQuestData
    {
        public string StartDate { get; set; }
        public List<List<Quest>> FeatureQuests { get; set; }
    }

    public class FeatureQuestCalculator
    {
        DateTime m_startDate;
        List<List<Quest>> m_FeatureQuests;
        public FeatureQuestCalculator(string filename)
        {
            string input;
            using (StreamReader sr = new StreamReader(filename))
            {
                input = sr.ReadToEnd();
            }
            FeatureQuestData data = JsonConvert.DeserializeObject<FeatureQuestData>(input);
            m_startDate = DateTime.Parse(data.StartDate);
            m_FeatureQuests = data.FeatureQuests;
        }

        public List<Quest> GetTargetDateFeatureQuest(DateTimeOffset targetDate, TimeSpan offset)
        {
            DateTimeOffset startDate = new DateTimeOffset(m_startDate, offset);
            int days = (targetDate - startDate).Days;

            return m_FeatureQuests[days % m_FeatureQuests.Count];
        }

        public List<Quest> GetTargetDateFeatureQuestJP(DateTimeOffset targetDate)
        {
            return GetTargetDateFeatureQuest(targetDate, new TimeSpan(9, 0, 0));
        }

        public List<Quest> GetTargetDateFeatureQuestGlobal(DateTimeOffset targetDate)
        {
            return GetTargetDateFeatureQuest(targetDate, new TimeSpan(-7, 0, 0));
        }
    }
}
