using UnityEngine;
using Unity.Netcode;
using StarterAssets;

public class NetworkSpawn : NetworkBehaviour
{
    
    public override void OnNetworkSpawn()
    {
        NetworkObject localPlayerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
        if (localPlayerObject != null)
        {
            Debug.Log("Local Object has Spawned");
            localPlayerObject.GetComponent<CharacterController>().enabled = true;
            localPlayerObject.GetComponent<ThirdPersonController>().enabled = true;
            localPlayerObject.GetComponent<StarterAssetsInputs>().enabled = true;
            localPlayerObject.transform.Find("FreeLookCamera")?.gameObject.SetActive(true);
        }
    }
}
