using UnityEngine;
namespace Game.Scripts.Players.Handlers
{
    public interface IDeltaTimeProvider
    {
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}
