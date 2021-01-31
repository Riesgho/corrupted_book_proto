using Domain.Actions;
using Editor.Tests.Actions;
using Infrastructure;
using JetBrains.Annotations;

namespace Editor.Tests.Mothers
{
    public static class BiteMother
    {
        public static Bite ABite([CanBeNull] InGameThings withInGameThings = null,
            [CanBeNull] InGameCat withAnInGameCat = null) =>
            new Bite(withInGameThings, withAnInGameCat);
    }
}