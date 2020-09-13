using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CorruptedBook.Presentation
{
    public class EssencePresenter
    {
        private IEssenceView view;

        public EssencePresenter(IEssenceView view)
        {
            this.view = view;
        }

        public void OnStart()
        {
            view.ShowEssence();
        }
    }
}
