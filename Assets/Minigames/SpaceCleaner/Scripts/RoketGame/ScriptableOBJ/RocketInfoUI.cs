using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "RocketFromUI")]
public class RocketInfoUI : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private bool onSold;
    [SerializeField] private Rocket roket;
    [SerializeField] private int price;
    [SerializeField] private Sprite image;

    public bool OnSold { get => onSold; set { onSold = value; SaveState(); } }
    public Rocket Roket { get => roket;}
    public int Price { get => price;}
    public Sprite Image { get => image;}

    [ContextMenu("Save")]
    public void SaveState()
    {
        var json = JsonUtility.ToJson(this);
        File.WriteAllText(GetFilePath(), json);
        Debug.Log(GetFilePath());
    }
    public void LoadState()
    {
        var json = File.ReadAllText(GetFilePath());
        JsonUtility.FromJsonOverwrite(json, this);
    }
    private string GetFilePath()
    {
        return Application.persistentDataPath + $"/{name}.so";
    }
    private void Awake()
    {
        LoadState();
    }

}
