using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public bool Interact => interact;
        private bool interact;
        private void Update()
        {
            interact = Input.GetMouseButtonDown(0);
        }
    }
}