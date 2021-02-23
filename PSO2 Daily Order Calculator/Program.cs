using System;

namespace PSO2_DailyOrderCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DailyOrderCalculator dailyOrderCalculator = new DailyOrderCalculator("Daily Order.json");
            var daily = dailyOrderCalculator.GetTargetDateDailyOrder(DateTime.Now, new TimeSpan(9, 0, 0));

            ExplorationCalculator explorationCalculator = new ExplorationCalculator("Exploration.json");
            var explore = explorationCalculator.GetTargetDateExploration(DateTime.Now, new TimeSpan(9, 0, 0));

            FeatureQuestCalculator featureQuestCalculator = new FeatureQuestCalculator("FeatureQuest.json");
            var feature = featureQuestCalculator.GetTargetDateFeatureQuest(DateTime.Now, new TimeSpan(9, 0, 0));

            ExtraOrderCalculator extraOrderCalculator = new ExtraOrderCalculator("ExtraOrder.json");
            var extra = extraOrderCalculator.GetTargetDateAllExtraOrders(DateTime.Now, new TimeSpan(9, 0, 0));
        }
    }
}
