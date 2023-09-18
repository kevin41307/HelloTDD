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

        var inputState = BindAndResolve<PlayerInputState>();
        inputState.SetMoveDirection(1, 1);

        var pauseStateEvaluator = Substitute.For<IStateEvaluator>();
        Container.BindInstance(pauseStateEvaluator);
        /*
        var press = BindAndResolve<UserPressPauseAction>();
        var pauseState = BindAndResolve<GamePauseState>();
        pauseState.Setup();
        pauseState.actions.ForEach(action => Debug.Log(action) );
        Debug.Log("Evaluate()" + pauseState.Evaluate());
        */

        var timeProvider = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(10);

        Container.Bind<PlayerMoveHandler>().AsSingle().WithArguments(playerCharacter);
        var moveHandler = Container.Resolve<PlayerMoveHandler>();

        pauseStateEvaluator.Evaluate().Returns(false);
        moveHandler.Tick();
        playerCharacter.Trans.ShouldTransformPositionBe(10, 10);
        moveHandler.Tick();
        playerCharacter.Trans.ShouldTransformPositionBe(20, 20);
    }

    [Test]
    public void GamePause_Then_PlayerCannotMove()
    {
        Container.Bind<PlayerCharacter>().FromNewComponentOnNewGameObject().AsSingle();
        float MoveSpeed = 1;
        Container.Bind<float>().WithId("MoveSpeed").FromInstance(MoveSpeed);
        var playerCharacter = Container.Resolve<PlayerCharacter>();

        var inputState = BindAndResolve<PlayerInputState>();
        inputState.SetMoveDirection(1, 1);

        var stateEvaluator = Substitute.For<IStateEvaluator>();
        Container.BindInstance(stateEvaluator);

        /*
        IStateEvaluator stateEvaluator = BindMockAndResolve<IStateEvaluator>();
        var press = BindAndResolve<UserPressPauseAction>();
        var pauseState = BindAndResolve<GamePauseState>();
        pauseState.Setup();
        pauseState.actions.ForEach(action => Debug.Log(action) );
        Debug.Log("Evaluate()" + pauseState.Evaluate());
        */

        var timeProvider = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(10);

        Container.Bind<PlayerMoveHandler>().AsSingle().WithArguments(playerCharacter);
        var moveHandler = Container.Resolve<PlayerMoveHandler>();

        stateEvaluator.Evaluate().Returns(false);
        moveHandler.Tick();   
        playerCharacter.ShouldTransformPositionBe(10, 10);

        moveHandler.Tick();  
        moveHandler.Tick();  
        playerCharacter.ShouldTransformPositionBe(30, 30);
        //GamePause
        
        stateEvaluator.Evaluate().Returns(true);
        //inputState.isPressPauseBtn = true;
        moveHandler.Tick();  
        moveHandler.Tick();  
        playerCharacter.ShouldTransformPositionBe(30, 30);
        
        //GamePause
        stateEvaluator.Evaluate().Returns(false);
        //inputState.isPressPauseBtn = false;
        moveHandler.Tick();   
        playerCharacter.ShouldTransformPositionBe(40, 40);

    }
}
