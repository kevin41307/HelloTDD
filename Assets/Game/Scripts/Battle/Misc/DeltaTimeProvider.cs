using UnityEngine;
namespace Game.Scripts.Battle.Misc
{
    public interface ITimeProvider
    {
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }

    public class TimeProvider : ITimeProvider
    {
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}
