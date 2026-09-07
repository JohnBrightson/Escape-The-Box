
using UnityEngine;
using Unity.Netcode;

namespace Escapes.PuzzleComponents.Platforms
{
    public class MoveWhenAboardPlatform : NetworkBehaviour
    {
        [SerializeField] private NetworkObject platform ;
        [SerializeField] private Vector3 _moveTowards;
        [SerializeField] private float _travelTime;

        private Vector3 _startPosition;

        private int PlayerInTrigger;

        private float _startTime;
        private float _evalTime;
        private bool Triggering = false;
        private bool _isPlayerOnPlatform = false;

        public override void OnNetworkSpawn()
        {
            _startPosition = platform.transform.position;
        }

        public void Update()
        {
            if(!IsServer) return;

            bool atStart = ApproximatelyEqual(platform.transform.position, _startPosition);
            bool atEnd = ApproximatelyEqual(platform.transform.position, _moveTowards);

            if((atStart || atEnd) && !_isPlayerOnPlatform) Triggering = false;

            if (Triggering)
            {
                MovePlatform(platform.transform.position); 
            }

        }

        public void OnTriggerEnter(Collider other)
        {
            if(!IsServer) return;
            Debug.Log("Triggered");
           _startTime = Time.time;
           if(other.gameObject.tag == "Player") 
            {
                PlayerInTrigger++;
                _isPlayerOnPlatform = true;
                Triggering = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if(!IsServer) return;
            PlayerInTrigger--;
            if(PlayerInTrigger <= 0)
            {
                _isPlayerOnPlatform = false;
            }
        }

        // [Rpc(SendTo.Server)]
        private void MovePlatform(Vector3 transfrompos)
        {
        _evalTime = Time.time - _startTime;
        platform.transform.position = Vector3.Lerp(_startPosition, _moveTowards, Mathf.PingPong(_evalTime / _travelTime, 1));
        }

        private bool ApproximatelyEqual(Vector3 a, Vector3 b, float tolerance = 0.05f)
        {
            return (a - b).sqrMagnitude <= tolerance * tolerance;
        }
    }
}