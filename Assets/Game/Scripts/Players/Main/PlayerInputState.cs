using System;
using UnityEngine;
namespace Game.Scripts.Players.Main
{
    public class PlayerInputState
    {

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public Vector2 MoveDirection => new Vector2(Horizontal, Vertical);

        public bool isPressPauseBtn = false;
        public void SetHorizontal(float horizontal)
        {
            this.Horizontal = horizontal;
        }

        public void SetVertical(float vertical)
        {
            this.Vertical = vertical;
        }

        public void SetMoveDirection(float horizontal, float vertical)
        {
            SetHorizontal(horizontal);
            SetVertical(vertical);
        }
    }
}