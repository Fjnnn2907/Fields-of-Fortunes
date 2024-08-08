using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUPManager : MonoBehaviour
{
    public static PopUPManager Instance {  get; private set; }
    public Vector3 PopUptransform;
    private void Awake()
    {
        Instance = this;
    }
    public GameObject popUpText;
    public void ShowDamege(string text,Transform _position)
    {
        if (popUpText)
        {
            GameObject prefab = Instantiate(popUpText, _position.position + PopUptransform, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
    public void ShowExp(string text,Transform _position)
    {
        if (popUpText)
        {
            GameObject prefab = Instantiate(popUpText, _position.position + PopUptransform, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.GetComponentInChildren<TextMesh>().color = Color.green;  

        }
    }
}
