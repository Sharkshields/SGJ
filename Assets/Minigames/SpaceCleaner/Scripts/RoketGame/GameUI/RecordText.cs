using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordText : MonoBehaviour
{
    private Text textRecord;
    private int record;
    [SerializeField] private ScoreManager manager;


    private void Awake()
    {
        textRecord = this.GetComponent<Text>();
        manager.startRecordUI += StartUpdateUI;
        manager.updateUI += UpdateUI;
    }

    private void StartUpdateUI(int i)
    {
        record = i;
        textRecord.text = "Best Score: " + record.ToString();
    }

    private void UpdateUI(int score)
    {
        if (score>record)
        {
            record = score;
            textRecord.text = "Best Score: " + record.ToString();
        }
    }
}
