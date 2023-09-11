using FluentAssertions;
using Game.Scripts.Players.Handlers;
using Game.Scripts.Players.Main;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using UnityEngine;
using Zenject;
public class PlayerCharacterTests : TestFixture_DI_Log
{
    [Test]
    public void MovePlayerCharacter_By_PlayerInput()
    {
        //Container.Bind<PlayerCharacter>().FromNewComponentOnNewGameObject().AsSingle();
        //var playerCharacter = Container.Resolve<PlayerCharacter>();
        
        var trans = new GameObject().transform;
        var player = new Player(trans.transform);

        var inputState = BindAndResolve<PlayerInputState>();
        var timeProvider = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(10);
        var moveHandler = BindAndResolve<PlayerMoveHandler>();
        moveHandler.character = player;

        inputState.SetMoveDirection(1, 1);
        moveHandler.Tick();
        Debug.Log("MoveDirection" + inputState.MoveDirection);
        Debug.Log("GetDeltaTime" + timeProvider.GetDeltaTime());

        player.Trans.ShouldTransformPositionBe(10, 10);
    }
}
