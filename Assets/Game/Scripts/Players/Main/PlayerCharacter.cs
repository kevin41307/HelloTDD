using UnityEngine;

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour, IPlayerCharacter
    {
        private IPlayerCharacter player;

        public IPlayerCharacter Player
        {
            get 
            {
                if (player == null) player = new Player(this.transform);
                return player;
            }
        }

        public float MoveSpeed 
        { 
            get => player.MoveSpeed; 
            set => player.MoveSpeed = value;
        } 
        

        public Vector2 GetPos()
        {
            return player.GetPos();
        }

        public void SetPos(Vector2 newPos)
        {
            player.SetPos(newPos);
        }
    }

}