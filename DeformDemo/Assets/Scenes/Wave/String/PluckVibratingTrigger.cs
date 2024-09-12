using System.Collections.Generic;
using Sonosthesia.Generator;
using Sonosthesia.Trigger;
using UnityEngine;

namespace Sonosthesia
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(PluckVibratingTrigger))]
    public class PluckVibratingTriggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PluckVibratingTrigger trigger = (PluckVibratingTrigger)target;
            if(GUILayout.Button("Trigger"))
            {
                trigger.Trigger();
            }
        }
    }
#endif
    
    public class PluckVibratingTrigger : MonoBehaviour
    {
        [SerializeField] private float _valueScale = 1f;
        
        [SerializeField] private float _timeScale = 1f;
        
        [SerializeField] private List<GeneratorSignal<float>> _generators;
        
        [SerializeField] private List<Triggerable> _triggerables;
        
        public void Trigger()
        {
            foreach (Triggerable triggerable in _triggerables)
            {
                triggerable.Trigger(_valueScale, _timeScale);
            }
        }
    }    
}


