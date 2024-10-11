using System;
using Sonosthesia.Trigger;
using UnityEngine;
using UnityEngine.UI;

namespace Sonosthesia 
{
    public class TriggerHoldUI : MonoBehaviour
    {
        [SerializeField] private Slider _valueScaleSlider;
        
        [SerializeField] private Triggerable _trigger;
        [SerializeField] private TrackedTriggerable _hold;

        private Guid _holdId;
        
        public void Trigger()
        {
            Debug.Log($"{this} {nameof(Trigger)}");
            if (!_trigger)
            {
                return;
            }
            float valueScale = _valueScaleSlider ? _valueScaleSlider.value : 1f;
            _trigger.Trigger(valueScale, 1f);
        }

        public void StartHold()
        {
            Debug.Log($"{this} {nameof(StartHold)}");
            if (!_hold)
            {
                return;
            }
            float valueScale = _valueScaleSlider ? _valueScaleSlider.value : 1f;
            _hold.EndTrigger(_holdId);
            _holdId = _hold.StartTrigger(valueScale, 1f);
        }

        public void EndHold()
        {
            Debug.Log($"{this} {nameof(EndHold)}");
            if (!_hold)
            {
                return;
            }
            _hold.EndTrigger(_holdId);
        }
    }

}


