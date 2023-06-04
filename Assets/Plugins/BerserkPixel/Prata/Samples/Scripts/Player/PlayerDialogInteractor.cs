using BerserkPixel.Prata;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerDialogInteractor : MonoBehaviour
    {
        private Interaction interaction;
        private PlayerInput playerInput;
        private float coolDown;
        public static Collider2D col;
        public static bool pararInteraccionHastaPulsarBoton;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            pararInteraccionHastaPulsarBoton = true;
        }

        private void Update()
        {
            coolDown += 2 * Time.deltaTime;
            if (interaction != null && playerInput.Interact && coolDown >= 1&& pararInteraccionHastaPulsarBoton)
            {
                Interact(); // meter aqui algo para las opciones
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
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 6 && col == null)
            {
                col = collision;
            }
        }
        public void destroyDialogue()
        {  
            Destroy(col);
        }
        //quitar luego de las pruebas
        public void Reinicio()
        {
            print("reinicio");
        }//quitar luego de las pruebas
        public void Cancelado()
        {
            print("cancelaod");
        }
        public void interactuado()
        {
            pararInteraccionHastaPulsarBoton = true;
        }
    }
}