using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel hiển thị đoạn thoại
    public TextMeshProUGUI dialogueText; // TextMeshPro hiển thị đoạn thoại
    public Button acceptButton; // Nút chấp nhận nhiệm vụ
    public Button declineButton; // Nút từ chối nhiệm vụ
    public float wordSpeed = 0.05f; // Tốc độ hiển thị từ
    public float panelHideDelay = 1f; // Thời gian trì hoãn trước khi ẩn panel

    private int currentLine = 0; // Dòng thoại hiện tại
    private string[] currentDialogueLines; // Các dòng thoại hiện tại
    private bool dialogueFinished = false; // Kiểm tra trạng thái thoại đã kết thúc
    private bool isQuestDialogue = false; // Kiểm tra nếu đây là đoạn thoại nhiệm vụ

    void Start()
    {
        EndDialogue(); // Đảm bảo các UI bắt đầu ở trạng thái ẩn
    }

    void Update()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (dialogueFinished)
                {
                    EndDialogue();
                }
                // Không làm gì nếu đoạn thoại chưa hoàn tất
            }
        }
    }

    public void StartNormalDialogue(string[] dialogueLines)
    {
        isQuestDialogue = false;
        StartDialogue(dialogueLines);
    }

    public void StartQuestDialogue(string[] dialogueLines)
    {
        isQuestDialogue = true;
        StartDialogue(dialogueLines);
        acceptButton.gameObject.SetActive(true);
        declineButton.gameObject.SetActive(true);
    }

    private void StartDialogue(string[] dialogueLines)
    {
        currentDialogueLines = dialogueLines;
        currentLine = 0;
        dialogueFinished = false;
        dialoguePanel.SetActive(true);
        acceptButton.gameObject.SetActive(false);
        declineButton.gameObject.SetActive(false);
        StartCoroutine(DisplayDialogue(dialogueLines));
    }

    IEnumerator DisplayDialogue(string[] dialogueLines)
    {
        dialogueText.text = "";
        foreach (char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed); // Thay đổi tốc độ hiển thị chữ nếu cần
        }
        dialogueFinished = true; // Đánh dấu đoạn thoại đã hoàn tất

        if (!isQuestDialogue)
        {
            yield return new WaitForSeconds(panelHideDelay); // Đợi 1 giây trước khi ẩn panel cho thoại thường
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false); // Ẩn panel
        acceptButton.gameObject.SetActive(false); // Ẩn nút chấp nhận nhiệm vụ
        declineButton.gameObject.SetActive(false); // Ẩn nút từ chối nhiệm vụ
        currentLine = 0; // Reset lại dòng thoại
        dialogueFinished = false; // Reset lại trạng thái thoại
    }

    public void ShowQuestDialogue(string[] questDialogueLines)
    {
        StartQuestDialogue(questDialogueLines);
    }

    public void ShowAcceptQuestDialogue(string[] acceptDialogueLines)
    {
        StartNormalDialogue(acceptDialogueLines);
    }

    public void ShowDeclineQuestDialogue(string[] declineDialogueLines)
    {
        StartNormalDialogue(declineDialogueLines);
    }
}
