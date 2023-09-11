using UnityEngine;
namespace Game.Scripts.Players.Main
{
    public interface IPlayerCharacter
    {
        public float MoveSpeed { get; set; }

        public void SetPos(Vector2 newPos);

        public Vector2 GetPos();

    }

    public class Player : IPlayerCharacter
    {
        public Player(Transform playerCharacter)
        {
            Trans = playerCharacter;
        }
        public Transform Trans { get; private set;}
        public float MoveSpeed { get; set; } = 1f;


        public void SetPos(Vector2 newPos)
        {
            Trans.position = (Vector3)newPos;
        }

        public Vector2 GetPos()
        {
            return (Vector2) Trans.position;
        }
    }
}