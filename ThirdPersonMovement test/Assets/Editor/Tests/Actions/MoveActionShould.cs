using System.Collections.Generic;
using Domain;
using Domain.Actions;
using Infrastructure;
using NUnit.Framework;
using UnityEngine;
using static Editor.Tests.Mothers.CatMother;
using static Editor.Tests.Mothers.InGameCatMother;

namespace Editor.Tests.Actions
{
    public class MoveActionShould
    {
        private static readonly List<PositionByDeltaTime> TestCases = new List<PositionByDeltaTime>()
        {
            new PositionByDeltaTime(new Vector3(1,0,0), 1,new Vector3(1,0,0),1 ),
            new PositionByDeltaTime(new Vector3(2,0,0), 2,new Vector3(8,0,0), 2 ),
            new PositionByDeltaTime(new Vector3(3,0,2), 4,new Vector3(36,0,24),3 )
        };
        
        [TestCaseSource(nameof(TestCases))]
        public void MoveTheCat(PositionByDeltaTime testCase)
        {
            var cat = ACat(withPosition: Vector3.zero, withSpeed: testCase.CatSpeed);
            var anInGameCat = AnInGameCat(withCat: cat);
            var moveCommander = new MoveCat(anInGameCat);

            moveCommander.Execute(testCase.Direction, testCase.DeltaTime);
            
            Assert.AreEqual(testCase.ExpectedPosition, anInGameCat.GetPosition());
        }
    }

    public class PositionByDeltaTime
    {
        public Vector3 Direction { get; }
        public int DeltaTime { get; }
        public Vector3 ExpectedPosition { get; }
        public int CatSpeed { get; }


        public PositionByDeltaTime(Vector3 direction, int deltaTime, Vector3 expectedPosition, int catSpeed)
        {
            Direction = direction;
            DeltaTime = deltaTime;
            ExpectedPosition = expectedPosition;
            CatSpeed = catSpeed;
        }
    }
}