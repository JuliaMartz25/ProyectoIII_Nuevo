using BerserkPixel.Prata;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Plugins.BerserkPixel.Prata.Samples.Scripts
{
    public class TestDialogTextMeshRenderer : DialogRenderer
    {
        [SerializeField] private GameObject container;
        [SerializeField] private TextMeshProUGUI authorText;
        [SerializeField] private TextMeshProUGUI dialogText;
        [SerializeField] private Image dialogLeftImage;
        [SerializeField] private Image dialogRightImage;
        [SerializeField] private Transform choicesContainer;
        [SerializeField] private GameObject choiceButtonPrefab;
        [SerializeField] private float typewriterSpeed = 30;

        public static bool CanSpace = true;

        public void Update()
        {
            if (CanSpace == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    typewriterSpeed = 40f;
                }
                if (Input.GetMouseButtonUp(1))
                {
                    typewriterSpeed = 30f;
                }
            }
            if (CanSpace == false)
            {
                typewriterSpeed = 30f;
            }
        }
        private IEnumerator TypeText(string textToType, TMP_Text textLabel)
        {
            textLabel.text = string.Empty;
            float t = 0;
            int charIndex = 0;
            int endIndex = 0;
            Color tagColor = new Color(0, 0, 0, 0);
            int currentIndex = 0;
            endIndex = textToType.IndexOf('>', currentIndex);
            int tagLength = endIndex - currentIndex + 1;
            textLabel.text = textToType.Substring(0, charIndex);
            while (charIndex < textToType.Length)
            {
                t += Time.deltaTime * typewriterSpeed;
                charIndex = Mathf.FloorToInt(t);
                charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
                char currentChar = textToType[currentIndex];
                if (currentChar == '<')
                {
                    typewriterSpeed = 500;
                    currentIndex += tagLength;
                }
                if (currentChar == '>')
                {
                    typewriterSpeed = 30f;
                    currentIndex++;
                }
                textLabel.text = textToType.Substring(0, charIndex);
                yield return null;
            }
            if (CanSpace == true)
            {
                textLabel.text = textToType;
            }
        }
        public override void Show()
        {
            container.SetActive(true);
        }

        public override void Render(Dialog dialog)
        {
            authorText.text = dialog.character.characterName;
            StartCoroutine(TypeText(dialog.text, dialogText));
            /*dialogLeftImage.preserveAspect = true;
            dialogRightImage.preserveAspect = true;*/
           /* if (dialog.character.isPlayer)
            {
                dialogLeftImage.gameObject.SetActive(true);
                dialogLeftImage.sprite = dialog.GetImage();
                dialogRightImage.gameObject.SetActive(false);
            }
            else
            {
                dialogRightImage.gameObject.SetActive(true);
                dialogRightImage.sprite = dialog.GetImage();
                dialogLeftImage.gameObject.SetActive(false);
            }*/

            if (dialog.choices.Count > 1)
            {
                RemoveChoices();
                foreach (var choice in dialog.choices)
                {
                    GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
                    choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice;
                    choiceButton.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        DialogManager.Instance.MakeChoice(dialog.guid, choice);
                    });
                }

                choicesContainer.gameObject.SetActive(true);
            }
            else
            {
                choicesContainer.gameObject.SetActive(false);
            }
        }

        public override void Hide()
        {
            RemoveChoices();
            container.SetActive(false);
        }

        private void RemoveChoices()
        {
            if (choicesContainer.childCount > 0)
            {
                foreach (Transform child in choicesContainer)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}