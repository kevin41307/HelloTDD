
using Game.Scripts.Players.Main;
using Zenject;

namespace Game.Scripts.Battle.Main
{
    public class BattleState
    {
        [Inject]
        PlayerCharacter playerCharacter;
        public bool IsPlayerExist => playerCharacter != null;
    }
}