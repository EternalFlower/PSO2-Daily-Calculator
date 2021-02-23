using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PSO2_DailyOrderCalculator
{
    public class ExplorationData
    {
        public string StartDate { get; set; }
        public List<Exploration> Explorations { get; set; }
    }

    class ExplorationCalculator
    {
        DateTime m_startDate;
        List<Exploration> m_explorations;
        public ExplorationCalculator(string filename)
        {
            string input;
            using (StreamReader sr = new StreamReader(filename))
            {
                input = sr.ReadToEnd();
            }
            ExplorationData data = JsonConvert.DeserializeObject<ExplorationData>(input);
            m_startDate = DateTime.Parse(data.StartDate);
            m_explorations = data.Explorations;
        }

        public Exploration GetTargetDateExploration(DateTimeOffset targetDate, TimeSpan offset)
        {
            DateTimeOffset startDate = new DateTimeOffset(m_startDate, offset);
            int days = (targetDate - startDate).Days;

            return m_explorations[days % m_explorations.Count];
        }

        public Exploration GetTargetDateExplorationJP(DateTimeOffset targetDate)
        {
            return GetTargetDateExploration(targetDate, new TimeSpan(9, 0, 0));
        }

        public Exploration GetTargetDateExplorationGlobal(DateTimeOffset targetDate)
        {
            return GetTargetDateExploration(targetDate, new TimeSpan(-7, 0, 0));
        }
    }
}
