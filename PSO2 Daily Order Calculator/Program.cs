using System;

namespace PSO2_DO_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            DailyOrderCalculator dailyOrderCalculator = new DailyOrderCalculator("C:\\Users\\Jimmy\\Desktop\\Daily Order.json");
            dailyOrderCalculator.GetTargetDateDailyOrder(DateTime.Now, new TimeSpan(9, 0, 0));

            ExplorationCalculator explorationCalculator = new ExplorationCalculator("C:\\Users\\Jimmy\\Desktop\\Exploration.json");
            explorationCalculator.GetTargetDateExploration(DateTime.Now, new TimeSpan(9, 0, 0));

            FeatureQuestCalculator featureQuestCalculator = new FeatureQuestCalculator("C:\\Users\\Jimmy\\Desktop\\FeatureQuest.json");
            featureQuestCalculator.GetTargetDateFeatureQuest(DateTime.Now, new TimeSpan(9, 0, 0));
        }
    }
}
