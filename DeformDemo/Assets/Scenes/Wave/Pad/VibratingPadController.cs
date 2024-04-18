using System;
using System.Collections.Generic;
using Sonosthesia.Utils;
using UnityEngine;

namespace Sonosthesia
{
    public class VibratingPadController : MonoBehaviour
    {
        [Serializable]
        public class Configuration
        {
            [SerializeField] private AnimationCurve _amplitudeCurve;
            public AnimationCurve AmplitudeCurve => _amplitudeCurve;
            
            [SerializeField] private AnimationCurve _offsetCurve;
            public AnimationCurve OffsetCurve => _offsetCurve;
            
            [SerializeField] private AnimationCurve _intensityCurve;
            public AnimationCurve IntensityCurve => _intensityCurve;
            
            [SerializeField] private AnimationCurve _falloffCurve;
            public AnimationCurve FalloffCurve => _falloffCurve;

            [SerializeField] private AnimationCurve _abortCurve;
            public AnimationCurve AbortCurve => _abortCurve;
        }

        public readonly struct Scale
        {
            public readonly float Time;
            public readonly float Amplitude;
            public readonly float Offset;
            public readonly float Intensity;
            public readonly float Falloff;

            public Scale(float time, float amplitude, float offset, float intensity, float falloff)
            {
                Time = time;
                Amplitude = amplitude;
                Offset = offset;
                Intensity = intensity;
                Falloff = falloff;
            }
        }

        [SerializeField] private Renderer _target;
        
        [SerializeField] private Configuration _configuration;

        private class PadController
        {
            private enum Phase
            {
                Idle,
                Ongoing,
                Aborting
            }
            
            private static float Time => UnityEngine.Time.time;
            
            private readonly int _amplitudeID;
            private readonly int _offsetID;
            private readonly int _centerID;
            private readonly int _intensityID;
            private readonly int _falloffID;
            private readonly Configuration _configuration;
            private readonly Material _material;

            private Phase _phase;
            private float _startTime;
            private float _abortTime;
            private Scale _scale;

            public PadController(Material material, Configuration configuration, 
                int amplitudeID, int offsetID, int centerID, int intensityID, int falloffID)
            {
                _phase = Phase.Idle;
                _configuration = configuration;
                _material = material;
                _amplitudeID = amplitudeID;
                _offsetID = offsetID;
                _centerID = centerID;
                _intensityID = intensityID;
                _falloffID = falloffID;
            }
            
            public PadController(Material material, Configuration configuration, int index)
            {
                _phase = Phase.Idle;
                _configuration = configuration;
                _material = material;
                _amplitudeID = Shader.PropertyToID($"_Amplitude{index}");
                _offsetID = Shader.PropertyToID($"_Offset{index}");
                _centerID = Shader.PropertyToID($"_Center{index}");
                _intensityID = Shader.PropertyToID($"_Intensity{index}");
                _falloffID = Shader.PropertyToID($"_Falloff{index}");
            }

            public void Trigger(Vector3 center, Scale scale)
            {
                _material.SetVector(_centerID, center);
                _phase = Phase.Ongoing;
                _startTime = Time;
                _scale = scale;
            }

            public void Abort()
            {
                _phase = Phase.Aborting;
                _abortTime = Time;
            }

            public void Update()
            {
                if (_phase == Phase.Idle)
                {
                    return;
                }
                
                float time = (Time - _startTime) * _scale.Time;
                float amplitude = _configuration.AmplitudeCurve.Evaluate(time) * _scale.Amplitude;
                if (_phase == Phase.Aborting)
                {
                    amplitude *= _configuration.AbortCurve.Evaluate(Time - _abortTime);
                }
                
                float offset = _configuration.OffsetCurve.Evaluate(time) * _scale.Offset;
                float intensity = _configuration.IntensityCurve.Evaluate(time) * _scale.Intensity;
                float falloff = _configuration.FalloffCurve.Evaluate(time) * _scale.Falloff;
                
                _material.SetFloat(_amplitudeID, amplitude);
                _material.SetFloat(_offsetID, offset);
                _material.SetFloat(_intensityID, intensity);
                _material.SetFloat(_falloffID, falloff);

                bool ended = _phase switch
                {
                    Phase.Ongoing => _configuration.AmplitudeCurve.Duration() < time,
                    Phase.Aborting => _configuration.AbortCurve.Duration() < Time - _abortTime,
                    _ => false
                };

                if (ended)
                {
                    _phase = Phase.Ongoing;
                }

            }

            public void Reset()
            {
                _material.SetFloat(_amplitudeID, 0f);
                _material.SetFloat(_offsetID, 0f);
                _material.SetFloat(_intensityID, 0f);
                _material.SetFloat(_falloffID, 0f);
            }
        }

        private List<PadController> _controllers = new ();
        private int _index = 0;

        protected virtual void Awake()
        {
            if (_target)
            {
                _target = GetComponent<Renderer>();
            }

            // don't use shared material, we want a separate instance
            Material material = _target.material;
            
            _controllers = new List<PadController>()
            {
                new PadController(material, _configuration, 1),
                new PadController(material, _configuration, 2),
            };
        }

        protected virtual void OnEnable()
        {
            foreach (PadController controller in _controllers)
            {
                controller.Reset();
            }
        }
        
        protected virtual void OnDisable()
        {
            foreach (PadController controller in _controllers)
            {
                controller.Reset();
            }
        }

        protected virtual void Update()
        {
            foreach (PadController controller in _controllers)
            {
                controller.Update();
            }
        }
        
        public void Trigger(Vector3 center, Scale scale)
        {
            _index = (_index + 1) % _controllers.Count;
            PadController controller = _controllers[_index];
            controller.Trigger(center, scale);
        }
    }    
}


