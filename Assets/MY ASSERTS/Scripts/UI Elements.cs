using Unity.Netcode;


namespace Escapes.UIElements
{
    public class UIElements : NetworkBehaviour
    {
        public void OnHostingUI()
        {
            NetworkManager.Singleton.StartHost();
        }
        public void OnJoiningUI()
        {
            NetworkManager.Singleton.StartClient();
        }

    }
}