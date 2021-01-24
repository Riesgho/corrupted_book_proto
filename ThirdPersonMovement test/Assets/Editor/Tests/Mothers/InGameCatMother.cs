using Domain;
using Infrastructure;
using UnityEngine;
using static Domain.Cat;

namespace Editor.Tests.Mothers
{
    public static class InGameCatMother
    {
        public static InGameCat AnInGameCat(Cat? withCat = default)
        {
            return new InGameCat(withCat ?? default);
        }
    }
}