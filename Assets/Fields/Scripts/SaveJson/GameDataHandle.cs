using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataHandle : MonoBehaviour
{
    private string filename = "data.json";
    private string filePath;

    public GameDataManager manager;
    public InventoryManager inventory;

    private string previousScene; // Scene hiện tại

    private void Awake()
    {
        LoadData();
    }
    private void Start()
    {
 
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, filename);
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }

        manager = JsonUtility.FromJson<GameDataManager>(File.ReadAllText(filePath));
        Debug.Log("Data Loaded!!");
    }

    public void SaveData()
    {
        filePath = Path.Combine(Application.persistentDataPath, filename);
        string json = JsonUtility.ToJson(manager,true);
        string jsonn = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(filePath, jsonn);
        Debug.Log("Path: " + filePath);
    }

    public void Update()
    {   
        if (previousScene != SceneManager.GetActiveScene().name)
        {
            // Lưu dữ liệu trước khi chuyển scene
            SaveData();
            LoadData();
        }

        // Cập nhật scene trước
        //previousScene = SceneManager.GetActiveScene().name;
    }
}