using UnityEngine;

[System.Serializable]
public class Reward
{
    public string rewardName; // Tên phần thưởng
    public int rewardAmount; // Số lượng phần thưởng
    public GameObject rewardPrefab; // Prefab phần thưởng
}

[System.Serializable]
public class CollectibleItem
{
    public string itemName; // Tên vật phẩm cần thu thập
    public int itemAmount; // Số lượng vật phẩm cần thu thập
    public GameObject itemPrefab; // Prefab vật phẩm cần thu thập
}

[System.Serializable]
public class Quest
{
    public enum QuestType { Kill, Collect }
    public QuestType questType; // Loại nhiệm vụ

    public string questName;
    public string questDescription;
    public string[] dialogueLines;
    public string[] postAcceptDialogueLines; // Đoạn thoại xuất hiện sau khi nhiệm vụ được chấp nhận
    public Reward[] rewards; // Mảng phần thưởng

    // Nhiệm vụ tiêu diệt
    public GameObject enemyToKill; // Kẻ thù cần tiêu diệt
    public int killCount; // Số lượng kẻ thù cần tiêu diệt

    // Nhiệm vụ thu thập
    public CollectibleItem[] itemsToCollect; // Mảng vật phẩm cần thu thập
}


