using System;
using Sonosthesia.Timeline;

namespace Sonosthesia
{
    public class PollenAnimationProxy : AnimationProxy
    {
        [Serializable]
        public struct Sphere
        {
            public Proxy spin;
            public Proxy brownianRotation;
            public Proxy colorIntensity;
            public Proxy colorIntensityBoost;
            public Proxy turbulenceIntensity;

            public void Update()
            {
                spin.Update();
                brownianRotation.Update();
                colorIntensity.Update();
                colorIntensityBoost.Update();
                turbulenceIntensity.Update();
            }
        }
        
        [Serializable]
        public struct Swirl
        {
            public Proxy colorIntensity;
            public Proxy scrollSpeed;
            public Proxy noiseSize;
            public Proxy noiseSpeed;
            public Proxy noiseMultiplier;
            public Proxy brownianRotation;

            public void Update()
            {
                colorIntensity.Update();
                scrollSpeed.Update();
                noiseSize.Update();
                noiseSpeed.Update();
                noiseMultiplier.Update();
                brownianRotation.Update();
            }
        }

        public Sphere sphere1;
        public Sphere sphere2;
        public Sphere sphere3;
        public Swirl swirl1;

        protected virtual void Update()
        {
            sphere1.Update();
            sphere2.Update();
            sphere3.Update();
            swirl1.Update();
        }
    }    
}


