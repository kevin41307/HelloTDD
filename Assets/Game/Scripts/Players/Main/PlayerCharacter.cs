using UnityEngine;
using Zenject;
namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour, IPlayerMover
    {
        public Transform Trans { get => transform; }
        public float MoveSpeed { get ; set; } = 50f;

        public Vector2 GetPos()
        {
            return Trans.position;
        }

        public void SetPos(Vector2 newPos)
        {
            Trans.position = newPos;
        }

    }

}