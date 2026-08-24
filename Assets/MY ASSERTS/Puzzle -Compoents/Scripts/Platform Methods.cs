using UnityEngine;
using System.Collections.Generic;

namespace Escapes.PuzzleComponents.Platforms
{
    public class PlatformMethods : MonoBehaviour
    {

        public static void MovingPlatform(Transform platformTransform, Vector3 startPosition, Vector3 moveTowards, float travelTime)
        {
            platformTransform.position = Vector3.Lerp(startPosition, moveTowards, Mathf.PingPong(Time.time / travelTime, 1));
            Debug.Log(Mathf.PingPong(Time.time/travelTime, 1));
        }

        public static void OnwayMovingPlatform(Transform platformTransform, Vector3 moveTowards, float speed)
        {
            if (platformTransform.position == moveTowards) return;
            float step = speed * Time.deltaTime;  
            platformTransform.position = Vector3.MoveTowards(platformTransform.position, moveTowards, step);
        }

        public static bool IsBothAboard(List<GameObject> objects)
        {
            if(objects.Count < 2) return false;
            int players = 0;
            foreach(GameObject obj in objects)
            {
                if(obj.tag == "Player")
                {
                    players++;
                }
            }
            return players == 2;
        }

        public static bool IsOneAbord(List<GameObject> objects)
        {
            int players = 0;
            foreach(GameObject obj in objects)
            {
                if(IsPlayer(obj))
                {
                    players++;
                }
            }
            return players == 1;
        }

        public static bool IsPlayer(GameObject obj)
        {
            return obj.tag == "Player";
        }
    }
}