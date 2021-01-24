using Domain;
using Editor.Tests.Mothers;
using NUnit.Framework;
using UnityEngine;

namespace Editor.Tests.Domain
{
    public class CatShould 
    {
        [Test]
        public void MoveOnDirectionWithSpeed()
        {
            var direction = Vector3.right;
            var speed = 2;
            var expectedPosition = new Vector3(2,0,0);
            var cat = CatMother.ACat(withSpeed: speed);
            var deltaTime = 1.0f;
        
            cat = cat.Move(direction, deltaTime);
        
            Assert.AreEqual(expectedPosition, cat.Position);
        }
    }
}