//using System;
//using System.IO;
//using UnityEngine;
//using TMPro;
//using UnityEngine.SceneManagement;

//public class Memory : MonoBehaviour
//{
//    GameData gameData;
//    GameManagerr gameManagerr;
//    PlayerManger playerManger;
//    SceneChange1 sceneChange1;

//    [SerializeField]
//    private TextMeshProUGUI heathPlayer;

//    [SerializeField]
//    private TextMeshProUGUI levelPlayer;

//    private string previousScene; // Scene hiện tại

//    void Start()
//    {
//        playerManger = FindObjectOfType<PlayerManger>();
//        sceneChange1 = FindObjectOfType<SceneChange1>();

//        // Lấy scene hiện tại
//        previousScene = SceneManager.GetActiveScene().name;
//    }

//    void Update()
//    {
//        // Kiểm tra khi chuyển scene
//        if (previousScene != SceneManager.GetActiveScene().name)
//        {
//            // Lưu dữ liệu trước khi chuyển scene
//            SavePreviousData();
//        }

//        // Cập nhật scene trước
//        previousScene = SceneManager.GetActiveScene().name;
//    }

//    public void SavePreviousData()
//    {
//        // Lưu dữ liệu trước khi chuyển scene
//        ReadDataFromFile();
//        ShowData();
//        WriterDataToFile(); // Truyền đối tượng GameDataa vào phương thức WriterDataToFile
//    }

//    public void ReadDataFromFile()
//    {
//        // Đọc dữ liệu từ file
//        GameDataa data = GameManagerr.ReadData(); // Đọc dữ liệu và lưu vào biến data của lớp GameDataa
//        if (data == null)
//        {
//            gameManagerr = new GameManagerr();
//        }
//    }

//    public void ShowData()
//    {
//        var health = playerManger.getCurrentHealth();
//        //du lieu trong file
//        //var healthFromFile = gameManagerr.healthPlayer;

//        //cap nhap vao data
//        gameManagerr.healthPlayer = health;

//        // Hiển thị dữ liệu lên giao diện
//        heathPlayer.text = "Health: " + gameManagerr.healthPlayer.ToString();
//        levelPlayer.text = "Level: " + gameManagerr.levelPlayer.ToString();

//        gameData.currentHealth = health;
//        gameManagerr.healthPlayer = health;
//    }

//    public void WriterDataToFile()
//    {
//        // Ghi dữ liệu vào file
//        GameManagerr.SaveData(gameManagerr);
//    }
//}