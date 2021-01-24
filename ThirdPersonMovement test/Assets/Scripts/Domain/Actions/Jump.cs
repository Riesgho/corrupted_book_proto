using Domain;
using Infrastructure;
using UnityEngine;

namespace Domain.Actions
{
    public class Jump
    {
        private readonly InGameCat _inGameCat;

        public Jump(InGameCat inGameCat)
        {
            _inGameCat = inGameCat;
        }

        public void Execute(Vector3 airForce)
        {
            var cat = _inGameCat.Get();
            if (airForce.y > 0 && cat.Status != Cat.CatStatus.Jumping)
            {
                _inGameCat.Update(cat.Jump(airForce));
            }
          
        }
    }
}