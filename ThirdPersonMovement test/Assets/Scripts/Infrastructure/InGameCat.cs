using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class InGameCat
    {
        private  Cat _cat;

        public InGameCat(Cat cat) => _cat = cat;

        public Vector3 GetPosition() => _cat.Position;

        public void Update(Cat cat) => _cat = cat;

        public Cat Get() => _cat;
    }
}