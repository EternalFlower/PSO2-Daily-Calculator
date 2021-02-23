# PSO2-Daily-Calculator

PSO2 Daily Calculator is divided into 5 parts.

Daily Orders - DailyOrder.json

Daily Orders are repeated in a 93 day cycle. 

The orders are calculated by calculating the difference between the input date and start date mod 93 (plus 1 since schedule starts on day 1) and searches for all orders that appears on that day.

Exploration Quest + Orders - Exploration.json

Calculates which Exploration Quest is active. Also contains the daily orders associated with the exploration. 16 day cycle.

Feature Quest

Calculates which 2 feature quests appears on that date. 21 day cycle

Level Quest

Calculates the level quests. 5 day cycle.

Extra Order

Calculates any daily orders not part of the 93 day cycle.

Currently it is between Buster, Ultimate and Emergency/Urgent.
