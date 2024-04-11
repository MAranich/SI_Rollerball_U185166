#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using UnityEngine;

namespace UnityTemplateProjects
{
    public class SimpleCameraController : MonoBehaviour
    {

        [SerializeField] private Transform player_transform;
        private Vector3 displacement; 

        private void Start()
        {
            displacement = transform.position - player_transform.position;
        }

        private void Update()
        {
            transform.position = player_transform.position + displacement;
        }

    }

}