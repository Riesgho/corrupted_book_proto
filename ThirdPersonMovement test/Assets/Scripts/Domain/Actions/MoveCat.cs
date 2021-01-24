using Infrastructure;
using UnityEngine;

namespace Domain.Actions
{
    public class MoveCat
    {
        private readonly InGameCat _anInGameCat;
        private Cat _cat;
        public MoveCat(InGameCat anInGameCat)
        {
            _anInGameCat = anInGameCat;
        }

        public void Execute(Vector3 direction, float deltaTime)
        {
            var cat = _anInGameCat.Get();
            _anInGameCat.Update( cat.Move(direction,deltaTime));
        }
    }
}