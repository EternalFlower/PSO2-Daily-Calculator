using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace PSO2_DailyOrderCalculator
{
    public class LevelQuestData
    {
        public string StartDate { get; set; }
        public List<Quest> LevelQuest { get; set; }
    }

    class LevelQuestCalculator
    {
        DateTime m_startDate;
        List<Quest> m_levelQuests;
        public LevelQuestCalculator(string filename)
        {
            string input;
            using (StreamReader sr = new StreamReader(filename))
            {
                input = sr.ReadToEnd();
            }
            LevelQuestData data = JsonConvert.DeserializeObject<LevelQuestData>(input);
            m_startDate = DateTime.Parse(data.StartDate);
            m_levelQuests = data.LevelQuest;
        }

        public Quest GetTargetDateLevelQuest(DateTimeOffset targetDate, TimeSpan offset)
        {
            DateTimeOffset startDate = new DateTimeOffset(m_startDate, offset);
            int days = (targetDate - startDate).Days;

            return m_levelQuests[days % m_levelQuests.Count];
        }

        public Quest GetTargetDateLevelQuestJP(DateTimeOffset targetDate)
        {
            return GetTargetDateLevelQuest(targetDate, new TimeSpan(9, 0, 0));
        }

        public Quest GetTargetDateLevelQuestGlobal(DateTimeOffset targetDate)
        {
            return GetTargetDateLevelQuest(targetDate, new TimeSpan(-7, 0, 0));
        }
    }
}
