using TMPro;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueManager dialogueManager; // Tham chiếu đến DialogueManager
    public string[] questDialogueLines; // Các dòng thoại nhiệm vụ
    public string[] acceptQuestDialogueLines; // Các dòng thoại khi chấp nhận nhiệm vụ
    public string[] declineQuestDialogueLines; // Các dòng thoại khi từ chối nhiệm vụ
    public string[] postAcceptQuestDialogueLines; // Các dòng thoại xuất hiện sau khi chấp nhận nhiệm vụ
    private bool playerIsClose = false;
    private bool questAccepted = false;

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player is close and E key pressed");
            if (!questAccepted)
            {
                Debug.Log("Showing quest dialogue");
                dialogueManager.ShowQuestDialogue(questDialogueLines);
            }
            else
            {
                Debug.Log("Showing post-accept quest dialogue");
                dialogueManager.StartNormalDialogue(postAcceptQuestDialogueLines);
            }
        }
    }

    public void OnAcceptQuest()
    {
        questAccepted = true;
        dialogueManager.ShowAcceptQuestDialogue(acceptQuestDialogueLines);
        // Cập nhật dòng thoại và thông tin nhiệm vụ
        //dialogueManager.StartQuestDialogue(postAcceptQuestDialogueLines); // Hiển thị dòng thoại sau khi chấp nhận nhiệm vụ
    }


    public void OnDeclineQuest()
    {
        dialogueManager.ShowDeclineQuestDialogue(declineQuestDialogueLines);
        // Đảm bảo panel và button bị ẩn ngay lập tức
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
