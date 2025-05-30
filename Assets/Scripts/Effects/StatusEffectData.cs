using Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "StatusEffectData", menuName = "Scriptable Objects/StatusEffectData", order = 1)]
    public class StatusEffectData : SerializedScriptableObject
    {
        public float baseValue;
        public float duration;
        public float tickRate;
        
        [Range(0.0f, 1.0f), Tooltip("Multiplier applied to the base value for each stack of the effect.")]
        public float stackMultiplier;
    }
}