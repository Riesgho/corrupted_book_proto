using System.Collections.Generic;
using CorruptedBook.Core;

namespace CorruptedBook.Presentation
{
    public interface IStashView
    {
        void DisplayItems(List<Item> itemsToDisplay);
        void Open();
    }
}