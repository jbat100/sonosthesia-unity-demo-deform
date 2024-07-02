using System;
using Sonosthesia.Timeline;
using UnityEngine;

namespace Sonosthesia
{
    public class PolarAnimationProxy : AnimationProxy
    {
        [Serializable]
        public struct Drums
        {
            [SerializeField] private Proxy _lows;   
            [SerializeField] private Proxy _mids;
            [SerializeField] private Proxy _highs;

            public void Update()
            {
                _lows.Update();
                _mids.Update();
                _highs.Update();
            }
        }

        [SerializeField] private Drums _drums;

        protected virtual void Update()
        {
            _drums.Update();
        }
    }

}

