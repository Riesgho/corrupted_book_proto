using Assets.CorruptedBook.Presentation;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Editor.Presentation
{
    class EssencePresenterShould
    {
        [Test]
        public void ShowEssenceAtStart()
        {
            IEssenceView view = Substitute.For<IEssenceView>();
            EssencePresenter presenter = new EssencePresenter(view);
            presenter.OnStart();
            view.Received(1).ShowEssence();
        }
    }
}
