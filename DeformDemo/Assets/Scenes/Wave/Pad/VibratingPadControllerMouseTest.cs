using UnityEngine;

namespace Sonosthesia
{
    public class VibratingPadControllerMouseTest : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        
        [SerializeField] private Vector3 _hitOffset = Vector3.up * 0.01f;
        
        [SerializeField] private float _timeScale = 1f;
        
        [SerializeField] private float _amplitudeScale = 1f;
        
        [SerializeField] private float _offsetScale = 1f;
        
        [SerializeField] private float _intensityScale = 1f;
        
        [SerializeField] private float _falloffScale = 1f;

        protected virtual void Awake()
        {
            if (!_camera)
            {
                _camera = Camera.main;
            }
        }
        
        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                AttemptTrigger();
            }
        }

        private void AttemptTrigger()
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                return;
            }
            VibratingPadController controller = hit.transform.GetComponent<VibratingPadController>();
            if (!controller)
            {
                return;
            }
            Vector3 center = hit.point + _hitOffset;
            VibratingPadController.Scale scale = new VibratingPadController.Scale(
                _timeScale, _amplitudeScale, _offsetScale, _intensityScale, _falloffScale);
            controller.Trigger(center, scale);
        }
    }    
}


