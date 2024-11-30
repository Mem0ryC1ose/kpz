using System;
using System.Collections.Generic;
using System.Linq;
using Robot.Common;


namespace Hnativ.Ostap.RobotChallange
{
    public class HnativAlgorithm: IRobotAlgorithm
    {
        public HnativAlgorithm()
        {
            Logger.OnLogRound += Logger_OnRound;
        }

        void Logger_OnRound(object sender, LogRoundEventArgs e)
        {
            RoundCount++;
        }
        

        public int RoundCount { get; set; }

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            var robotToMove = robots[robotToMoveIndex];
            var pos = robotToMove.Position;
            var stations = map.GetNearbyResources(pos, 25);
            //Створення нового робота
            if (robotToMove.Energy >= 556 
                && Functions.IsOnStation(pos,map) 
                && robots.Count(robot => robot.OwnerName == Author) < 100
                && RoundCount < 50)
            {
                var newRobot = new CreateNewRobotCommand();
                newRobot.NewRobotEnergy = 300;
                return newRobot;
            }
            //Збір енергії
            if (Functions.IsOnStation(pos,map))
            {
                return new CollectEnergyCommand();
            }
            
            //Пошук станції і переміщення
            Position bestStationPosition;
            if (!Functions.StaticRobotsPosition.Exists(kvp => kvp.Key == robotToMoveIndex))
            { 
                bestStationPosition = Functions.FindBestStation(robotToMove, stations, robotToMoveIndex);
            }
            else
            {
                bestStationPosition = Functions.StaticRobotsPosition[robotToMoveIndex].Value;
            }
            
            if(bestStationPosition != null){
            if (robotToMove.Energy >= Functions.DistanceCost(pos, bestStationPosition))
            {
                return new MoveCommand()
                {
                    NewPosition = new Position(bestStationPosition.X, bestStationPosition.Y)
                };
            }
            if (robotToMove.Energy < Functions.DistanceCost(pos, bestStationPosition))
            {
                    var directionX = Math.Sign(bestStationPosition.X - pos.X);
                    var directionY = Math.Sign(bestStationPosition.Y - pos.Y);
                    int i = 2;
                    while (robotToMove.Energy < Functions.DistanceCost(pos, new Position(pos.X + directionX*i, pos.Y + directionY*i)) 
                           && i != 1)
                    {
                        i--;
                    }
                    return new MoveCommand()
                    {
                        NewPosition = new Position()
                        {
                            X = pos.X+directionX * i,
                            Y = pos.Y+directionY * i
                        }
                    };
            }
            }

            return new MoveCommand()
            {
                NewPosition = robotToMove.Position
            };
        }

        public string Author => "Hnativ Ostap";
    }
}