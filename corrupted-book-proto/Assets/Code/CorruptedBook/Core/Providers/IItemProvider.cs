using System.Collections.Generic;

namespace CorruptedBook.Core.Providers
{
    public interface IItemProvider
    {
        List<Item> GenerateItems(int id);
    }
}