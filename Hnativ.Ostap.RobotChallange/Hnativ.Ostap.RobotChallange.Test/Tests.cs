using System;
using System.Collections.Generic;
using NUnit.Framework;
using Robot.Common;

namespace Hnativ.Ostap.RobotChallange.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestDistanceCost()
        {
            var p1 = new Position(1, 1);
            var p2 = new Position(2, 3);
            Assert.AreEqual(5, Functions.DistanceCost(p1, p2));
            
            p1 = new Position(1, 1);
            p2 = new Position(9, 6);
            Assert.AreEqual(89, Functions.DistanceCost(p1, p2));
        }
        
        [Test]
        public void TestIsOnStation()
        {
            var pos = new Position(0, 0);
            var robot = new Robot.Common.Robot();
            var station = new EnergyStation();
            var map = new Map();
            map.Stations.Add(station);
            
            robot.Position = pos;
            station.Position = pos;
            
            Assert.True(Functions.IsOnStation(robot.Position,map));
        }
        
        [Test]
        public void TestCollectEnergy()
        {
            var algorithm = new HnativAlgorithm();
            var robot = new Robot.Common.Robot();
            var robots = new List<Robot.Common.Robot>();
            var station = new EnergyStation();
            var map = new Map();
            
            var pos = new Position(0, 0);
            station.Position = pos;
            robot.Position = pos;
            
            map.Stations.Add(station);
            robots.Add(robot);
            
            Assert.AreEqual(new CollectEnergyCommand().GetType(),
                algorithm.DoStep(robots, 0, map).GetType());
        }


        [Test]
        public void TestCreateNewRobot()
        {
            var algorithm = new HnativAlgorithm();
            var robot = new Robot.Common.Robot();
            var robots = new List<Robot.Common.Robot>();
            var station = new EnergyStation();
            var map = new Map();
            
            var pos = new Position(0, 0);
            station.Position = pos;
            robot.Position = pos;
            robot.Energy = 556;
            
            map.Stations.Add(station);
            robots.Add(robot);
            
            Assert.AreEqual(new CreateNewRobotCommand().GetType(),
                algorithm.DoStep(robots, 0, map).GetType());
        }


        [Test]
        public void TestFindBestStation()
        {
            var algorithm = new HnativAlgorithm();
            var robot = new Robot.Common.Robot();
            var stations = new List<EnergyStation>();
            var s1 = new EnergyStation();
            var s2 = new EnergyStation();
            
            var pos = new Position(50, 50);
            robot.Position = pos;
            
            s1.Position = new Position(pos.X+3, pos.Y+3);
            s2.Position = new Position(pos.X-4, pos.Y-4);
            stations.Add(s1);
            stations.Add(s2);
            
            Assert.AreEqual(s1.Position, Functions.FindBestStation(robot,stations,0));

        }
    }
}