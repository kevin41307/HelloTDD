using FluentAssertions;
using Game.Scripts.Battle.Misc;
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
   
        var player = new GameObject().transform;
        var mover = BindMockAndResolve<IPlayerMover>();
        mover.GetPos().Returns((Vector2)player.transform.position);
        mover.MoveSpeed = 1;
        
        var inputState = BindAndResolve<PlayerInputState>();
        inputState.SetMoveDirection(1, 1);

        var timeProvider = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(10);

        //var moveHandler =  BindAndResolve<PlayerMoveHandler>()
        Container.Bind<PlayerMoveHandler>().AsSingle().WithArguments(mover);
        var moveHandler = Resolve<PlayerMoveHandler>();

        //moveHandler.mover = mover;

        var movement = moveHandler.CalMovement();
        Debug.Log("movement" + movement);
        mover.When(x => x.SetPos(movement)).Do(x => {player.position += (Vector3)movement; });
        moveHandler.Tick();
        player.ShouldTransformPositionBe(10, 10);
        moveHandler.Tick();
        player.ShouldTransformPositionBe(20, 20);
    }
}
