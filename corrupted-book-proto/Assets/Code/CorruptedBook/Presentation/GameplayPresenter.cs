﻿namespace CorruptedBook.Presentation
{
    public class GameplayPresenter
    {
        private IGamePlayView view;
        public GameplayPresenter(IGamePlayView view)
        {
            this.view = view;
        }

        public void SetPlayerOnStartPosition()
        {
            view.ShowPlayerAtPosition(0,0,0);
        }
        
    }
}