using UnityEngine;
namespace Game.Scripts.Players.Main
{
    public interface IPlayerMover
    {
        public float MoveSpeed { get; set; }
        public void SetPos(Vector2 newPos);
        public Vector2 GetPos();

    }
    
}