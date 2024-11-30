using System.Collections.Generic;
using System.Linq;
using Robot.Common;

namespace Hnativ.Ostap.RobotChallange
{
    public class Functions
    {
        public static List<KeyValuePair<int, Position>> StaticRobotsPosition { get; set; } = new List<KeyValuePair<int, Position>>();
        
        public static int DistanceCost(Position center, Position distant) => 
            (center.X - distant.X) * (center.X - distant.X) + (center.Y - distant.Y) * (center.Y - distant.Y);
        
        public static bool IsOnStation(Position robotPosition, Map map)
        {
            return map.GetResource(robotPosition) != null; ;
        }
        
        public static Position FindBestStation(Robot.Common.Robot robotToMove, List<EnergyStation> stations, int robotToMoveIndex)
        {
            var bestStation = new Position();
            var costDictionary = stations.ToDictionary(
                station => station,
                station => Functions.DistanceCost(robotToMove.Position, station.Position)
            );
           
            
            var sortedStations = stations.OrderBy(station => costDictionary[station]).ToList();
            int numberToPick = 0;
            bool isChanged = false;
            int maxRecoveryRate = 0;
            for (int i = 0; i < sortedStations.Count; i++)
            {
                int cost = Functions.DistanceCost(robotToMove.Position,sortedStations[i].Position);
                if (sortedStations[i].RecoveryRate > maxRecoveryRate &&
                    cost < robotToMove.Energy &&
                !StaticRobotsPosition.Any(kvp => kvp.Value.Equals(sortedStations[i].Position)))
                {
                    maxRecoveryRate = sortedStations[i].RecoveryRate;
                    numberToPick = i;
                }
                isChanged = true;
            }

            if (!isChanged)
            {
                for (int i = 0; i < sortedStations.Count; i++)
                {
                    if(!StaticRobotsPosition.Any(kvp => kvp.Value.Equals(sortedStations[i].Position)))
                    {
                        numberToPick = i;
                    }
                }
            }
            
            if (sortedStations.Count > 0)
            {
                StaticRobotsPosition.Add(new KeyValuePair<int, Position>(robotToMoveIndex, sortedStations[numberToPick].Position));
                return sortedStations[numberToPick].Position;
            }

            return robotToMove.Position;
        }
    }
}