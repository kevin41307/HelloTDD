using UnityEngine;
using Zenject;
namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour, IPlayerMover
    {
        public Transform Trans { get => transform; }

        [Inject(Id = "MoveSpeed")]
        public float MoveSpeed { get ; set; } 

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