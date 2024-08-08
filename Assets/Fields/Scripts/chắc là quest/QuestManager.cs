using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public bool questAccepted = false;
    public NPCInteraction npcInteraction; // Tham chiếu đến NPCInteraction
    public TextMeshProUGUI questInfoText; // Tham chiếu đến TextMeshProUGUI hiển thị thông tin nhiệm vụ
    public QuestLog questLog; // Tham chiếu đến QuestLog
    public Quest currentQuest; // Nhiệm vụ hiện tại


    public void AcceptQuest()
    {
        if (currentQuest != null && !questAccepted) 
        {
            npcInteraction.OnAcceptQuest(); // Gọi phương thức chấp nhận nhiệm vụ

            // Cập nhật thông tin nhiệm vụ và danh sách
            UpdateQuestInfo(currentQuest.questDescription); // Cập nhật thông tin nhiệm vụ trên UI
            questLog.AddQuest(currentQuest.questDescription); // Thêm nhiệm vụ vào danh sách

            questAccepted = true; // Đánh dấu nhiệm vụ đã được chấp nhận
        }
    }


    public void DeclineQuest()
    {
        npcInteraction.OnDeclineQuest(); // Gọi phương thức từ chối nhiệm vụ
    }

    private void UpdateQuestInfo(string questInfo)
    {
        questInfoText.text = questInfo; // Cập nhật thông tin nhiệm vụ trên UI
    }
}
