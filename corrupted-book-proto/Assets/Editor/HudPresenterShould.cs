using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;

public class HudPresenterShould
{
    [Test]
    public void ShowPlayersHealthAInit()
    {
        var view = Substitute.For<IHudView>();
        var presenter = new HudPresenter(view);
        presenter.Init();
        view.Received(1).ShowPlayersHealth();
    }
}
