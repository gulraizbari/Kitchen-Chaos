using UnityEngine;

namespace KitchenChaos.UI.Utility
{
    public class LoaderCallback: MonoBehaviour
    {
        private bool isFirstUpdate = false;

        private void Update()
        {
            if (!isFirstUpdate)
            {
                isFirstUpdate = true;
                Loader.LoaderCallback();
            }
        }
    }
}