using System;
using UnityEngine;

namespace Effects
{
    [Serializable]
    public class StatusEffectData
    {
        public float baseValue;
        public float duration;
        public float tickRate;
        
        [Range(0.0f, 1.0f), Tooltip("Multiplier applied to the base value for each stack of the effect.")]
        public float stackMultiplier;
        
        public int Stacks { get; private set; } = 1;
        public float CreationTime { get; protected set; }
        public float NextTickTime { get; protected set; }

        public void SetInitData(int stacks)
        {
            Stacks = stacks;
            CreationTime = Time.time;
            NextTickTime = Time.time;
        }
        
        public bool GetIsExpired()
        {
            float expirationTime = CreationTime + duration;

            return Time.time > expirationTime;
        }

        public bool GetNextTickReady()
        {
            return Time.time > NextTickTime;
        }
        
        public void SetNextTickTime(float time)
        {
            NextTickTime = time;
        }
    }
}