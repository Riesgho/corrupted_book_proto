using CorruptedBook.Core.Providers;

namespace CorruptedBook.Presentation
{
    public class GameplayPresenter
    {
        private IGamePlayView view;
        private IEssenceProvider itemProvider;
        public GameplayPresenter(IGamePlayView view)
        {
            this.view = view;
            this.itemProvider = itemProvider;
        }

        public void SetPlayerOnStartPosition()
        {
            view.ShowPlayerAtPosition(0,0,0);
        }
        
    }
}