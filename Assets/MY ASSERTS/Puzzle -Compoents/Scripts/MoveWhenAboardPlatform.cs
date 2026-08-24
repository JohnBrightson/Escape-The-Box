using Unity.VisualScripting;
using UnityEngine;

namespace Escapes.PuzzleComponents.Platforms
{
    public class MoveWhenAboardPlatform : MonoBehaviour
    {
        [SerializeField] private Vector3 _moveTowards;
        [SerializeField] private float _travelTime;
        private bool _canMove;
        private Vector3 _startPosition;
        public void Awake()
        {
            _startPosition = transform.position;
        }
        public void Update()
        {
            if (_canMove)
            {
                PlatformMethods.MovingPlatform(transform, _startPosition, _moveTowards, _travelTime);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("TriggerEntered");
            if(PlatformMethods.IsPlayer(other.gameObject)) _canMove = true;
        }
        public void OnTriggerExit(Collider other)
        {
            if(PlatformMethods.IsPlayer(other.gameObject)) _canMove = false; 
        }
    }
}