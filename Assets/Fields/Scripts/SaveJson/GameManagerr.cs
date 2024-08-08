using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable] // Dùng để lưu trữ dữ liệu của class này
public class GameDataa
{
    public int healthPlayer;
    public int levelPlayer;
    public int coinsPlayer;
}

public class GameManagerr
{
    public int healthPlayer;
    public int levelPlayer;
    public int coinsPlayer;
    const string FILE_NAME = "data.txt";

    public static bool SaveData(GameDataa data)
    {
        try
        {
            // Chuyển data từ kiểu GameDataa sang kiểu string
            // Chuyển sang dạng text JSON
            var json = JsonUtility.ToJson(data);
            // Tạo ra file data.txt
            var fileStream = new FileStream(FILE_NAME, FileMode.Create);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
            return true;
        }
        catch (Exception e)
        {
            Debug.Log($"Save data error: {e.Message}");
        }
        return false;
    }

    public static GameDataa ReadData()
    {
        try
        {
            if (File.Exists(FILE_NAME))
            {
                // Đọc để mở file
                var fileStream = new FileStream(FILE_NAME, FileMode.Open);

                using (var reader = new StreamReader(fileStream))
                {
                    // Đọc dữ liệu trong file
                    var json = reader.ReadToEnd();
                    // Chuyển dữ liệu từ JSON sang class
                    var dataa = JsonUtility.FromJson<GameDataa>(json);
                    return dataa;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error loading file: " + e.Message);
        }
        return null;
    }
}