using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestLog : MonoBehaviour
{
    public GameObject questListPanel;
    public TextMeshProUGUI questListText;
    public Button questListButton;

    private List<string> acceptedQuests = new List<string>(); // Danh sách nhiệm vụ đã nhận

    void Start()
    {
        questListPanel.SetActive(false);
        questListButton.onClick.AddListener(ToggleQuestList); // Thêm sự kiện click cho nút
    }

    public void AddQuest(string quest)
    {
        acceptedQuests.Add(quest); // Thêm nhiệm vụ vào danh sách
    }

    private void ToggleQuestList()
    {
        questListPanel.SetActive(!questListPanel.activeSelf); // Hiển thị/Ẩn panel
        if (questListPanel.activeSelf)
        {
            DisplayQuests();
        }
    }

    private void DisplayQuests()
    {
        questListText.text = ""; // Xóa nội dung cũ
        foreach (string quest in acceptedQuests)
        {
            questListText.text += quest + "\n"; // Hiển thị từng nhiệm vụ
        }
    }
}
