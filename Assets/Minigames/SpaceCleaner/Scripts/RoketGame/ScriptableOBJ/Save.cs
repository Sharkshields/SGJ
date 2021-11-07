using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Save")]
public class Save : ScriptableObject
{
    //    [SerializeField] private Rocket roket;
    //    [SerializeField] private Sprite sprite;
    [SerializeField] private RocketInfoUI _rocket;
    [SerializeField]private int score;
    [SerializeField]private int recordScore;
    public Rocket Roket { get => _rocket.Roket;}
    public int RecordScore { get => recordScore; set { recordScore = value; SaveState(); } }
    public int Score { get => score; set { score = value; SaveState(); } }

    public Sprite Sprite { get => _rocket.Image;}

    public void SetRoket(RocketInfoUI rocket)
    {
        _rocket = rocket;
        SaveState();
    }
    private void OnEnable()
    {
        LoadState();
    }

    [ContextMenu("Save")]
    public void SaveState()
    {
        var json = JsonUtility.ToJson(this);
        File.WriteAllText(GetFilePath(),json);
        Debug.Log(GetFilePath());
    } 
    public void LoadState()
    {
        var json = File.ReadAllText(GetFilePath());
        JsonUtility.FromJsonOverwrite(json, this);
    }
    private string GetFilePath()
    {
        return Application.persistentDataPath + $"/Save.so";
    }
}
