using UnityEngine;
namespace Game.Scripts.Battle.Misc
{
    public interface IDeltaTimeProvider
    {
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }

    public class DeltaTimeProvider : IDeltaTimeProvider
    {
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}
