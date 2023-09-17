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
using Game.Scripts.Misc;
using System.Collections.Generic;
using System.Linq;


public class PlayerCharacterTests : TestFixture_DI_Log
{
    [Test]
    public void MovePlayerCharacter_By_PlayerInput()
    {
        Container.Bind<PlayerCharacter>().FromNewComponentOnNewGameObject().AsSingle();
        float MoveSpeed = 1;
        Container.Bind<float>().WithId("MoveSpeed").FromInstance(MoveSpeed);
        var playerCharacter = Container.Resolve<PlayerCharacter>();

        //var GamePauseState = ScriptableObject.CreateInstance<GamePauseState>();
        //Container.Bind<GamePauseState>().FromInstance(GamePauseState);
        var inputState = BindAndResolve<PlayerInputState>();
        inputState.SetMoveDirection(1, 1);

        var press = BindAndResolve<UserPressPauseAction>();
        var pauseState = BindAndResolve<GamePauseState>();
        pauseState.Setup();

        pauseState.actions.ForEach(action => Debug.Log(action) );
        Debug.Log("Evaluate()" + pauseState.Evaluate());

        //IStateEvaluator stateEvaluator = BindMockAndResolve<IStateEvaluator>();
        //pauseState.evaluator = stateEvaluator;

        //stateEvaluator.Evaluate(pauseState.actions).Returns(false);
        //Container.Bind<GamePauseState>().FromInstance(pauseState);

        var player = playerCharacter.Trans;
        //playerCharacter.MoveSpeed = 1;
        //var player = new GameObject().transform;
        //var mover = BindMockAndResolve<IPlayerMover>();
        //mover.GetPos().Returns((Vector2)player.transform.position);
        //mover.MoveSpeed = 1;

        var timeProvider = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(10);

        //Container.Bind<PlayerMoveHandler>().AsSingle().WithArguments(mover);
        Container.Bind<PlayerMoveHandler>().AsSingle().WithArguments(playerCharacter);
        var moveHandler = Container.Resolve<PlayerMoveHandler>();

        //var movement = moveHandler.CalMovement();
        //Debug.Log("movement" + movement);
        //mover.When(x => x.SetPos(movement)).Do(x => {player.position += (Vector3)movement; });
        moveHandler.Tick();
        player.ShouldTransformPositionBe(10, 10);
        moveHandler.Tick();
        player.ShouldTransformPositionBe(20, 20);
    }

    [Test]
    public void UserPressGamePauseBtn_Then_PlayerCannotMove()
    {
        Container.Bind<PlayerCharacter>().FromNewComponentOnNewGameObject().AsSingle();
        float MoveSpeed = 1;
        Container.Bind<float>().WithId("MoveSpeed").FromInstance(MoveSpeed);
        var playerCharacter = Container.Resolve<PlayerCharacter>();

        var inputState = BindAndResolve<PlayerInputState>();
        inputState.SetMoveDirection(1, 1);

        var press = BindAndResolve<UserPressPauseAction>();
        var pauseState = BindAndResolve<GamePauseState>();
        pauseState.Setup();

        pauseState.actions.ForEach(action => Debug.Log(action) );
        Debug.Log("Evaluate()" + pauseState.Evaluate());

        var player = playerCharacter.Trans;

        var timeProvider = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(10);

        Container.Bind<PlayerMoveHandler>().AsSingle().WithArguments(playerCharacter);
        var moveHandler = Container.Resolve<PlayerMoveHandler>();

        player.ShouldTransformPositionBe(0, 0);
        moveHandler.Tick();   
        player.ShouldTransformPositionBe(10, 10);

        moveHandler.Tick();  
        moveHandler.Tick();  
        player.ShouldTransformPositionBe(30, 30);
        //GamePause
        
        //pauser.Evaluate().Returns(true);
        inputState.isPressPauseBtn = true;
        moveHandler.Tick();  
        moveHandler.Tick();  
        player.ShouldTransformPositionBe(30, 30);
        
        //GamePause
        inputState.isPressPauseBtn = false;
        moveHandler.Tick();   
        player.ShouldTransformPositionBe(40, 40);

    }
}
