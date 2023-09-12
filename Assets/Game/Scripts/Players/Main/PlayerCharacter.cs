using UnityEngine;
using Zenject;
namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour
    {
        private IPlayerMover player;

        public IPlayerMover Player
        {
            get 
            {
                if (player == null) player = new PlayerMover(this.transform);
                return player;
            }
        }
        
    }

}