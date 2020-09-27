using CorruptedBook.Core.Providers;

namespace CorruptedBook.Presentation
{
    public class StashPresenter
    {
        private IStashView view;
        private IItemProvider itemProvider;
        private IRandomProvider randomProvider;

        public StashPresenter(IStashView view, IItemProvider itemProvider, IRandomProvider randomProvider)
        {
            this.view = view;
            this.itemProvider = itemProvider;
            this.randomProvider = randomProvider;
        }

        public void Open()
        {
            view.DisplayItems(itemProvider.GenerateItems(2));
        }
    }
}