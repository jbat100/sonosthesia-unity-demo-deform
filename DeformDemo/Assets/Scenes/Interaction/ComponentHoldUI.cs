using Sonosthesia.Trigger;
using UnityEngine;
using UnityEngine.UI;

namespace Sonosthesia.DeformDemo
{
    public class ComponentHoldUI : MonoBehaviour
    {
        [SerializeField] private TrackedTriggerTest _trackedTriggerTest;
        
        [SerializeField] private Slider _valueSlider;

        public void StartTrigger()
        {
            _trackedTriggerTest.StartTrigger(_valueSlider.value, 1f);
        }

        public void EndTrigger()
        {
            _trackedTriggerTest.EndTrigger();
        }
    }   
}
