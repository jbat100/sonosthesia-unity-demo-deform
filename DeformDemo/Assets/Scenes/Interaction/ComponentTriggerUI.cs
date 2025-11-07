using Sonosthesia.Trigger;
using UnityEngine;
using UnityEngine.UI;

namespace Sonosthesia.DeformDemo
{
    public class ComponentTriggerUI : MonoBehaviour
    {
        [SerializeField] private Slider _valueSlider;
        
        [SerializeField] private TriggerTest _triggerTest;

        public void Play()
        {
            _triggerTest.Trigger(_valueSlider.value);
        }
    }   
}
