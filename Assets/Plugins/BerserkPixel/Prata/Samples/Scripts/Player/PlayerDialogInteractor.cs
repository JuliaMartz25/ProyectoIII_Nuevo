using BerserkPixel.Prata;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerDialogInteractor : MonoBehaviour
    {
        private Interaction interaction;

        private PlayerInput playerInput;
        private float coolDown;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            coolDown += 2 * Time.deltaTime;
            if (interaction != null && playerInput.Interact && coolDown >= 1)
            {
                Interact();
                coolDown = 0;
            }
        }

        public void ReadyForInteraction(Interaction newInteraction)
        {
            interaction = newInteraction;
        }

        public void Interact()
        {
            if (interaction != null)
            {
                DialogManager.Instance.Talk(interaction);
            }
        }
    }
}