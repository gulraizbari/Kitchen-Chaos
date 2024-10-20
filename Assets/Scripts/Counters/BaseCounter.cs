using System;
using KitchenChaos.Feature.Player;
using UnityEngine;

namespace KitchenChaos.Feature.Interaction
{
    public class BaseCounter : MonoBehaviour, IKitchenObjectParent
    {
        public static event EventHandler OnAnyObjectPlacedHere;
        [SerializeField] private Transform _counterTopPoint;

        private KitchenObject _kitchenObject;
        
        public static void ResetStaticData()
        {
            OnAnyObjectPlacedHere = null;
        }

        
        public virtual void Interact(PlayerController playerController)
        {
        }

        public virtual void CuttingInteractInput()
        {
        }
        
        public Transform GetCounterTopTransform()
        {
            return _counterTopPoint;
        }

        public void SetKitchenObject(KitchenObject kitchenObject)
        {
            this._kitchenObject = kitchenObject;
            if (kitchenObject != null)
            {
                OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
            }
        }

        public KitchenObject GetKitchenObject()
        {
            return _kitchenObject;
        }

        public void ClearKitchenObject()
        {
            _kitchenObject = null;
        }

        public bool HasKitchenObject()
        {
            return _kitchenObject != null;
        }
    }
}