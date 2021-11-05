using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Save save;

    [SerializeField] private List<RocketInfoUI> listInfo;
    [SerializeField] private RoketUI defoltPanel;
    private List<RoketUI> roketUIs;

    public event Action<int> updateScore;
    public event Action<Sprite> updateRoketUI;

    private void Start()
    {
        roketUIs = new List<RoketUI>();
        for (int i = 0; i < listInfo.Count; i++)
        {
            var newRocketUI = Instantiate(defoltPanel);
            newRocketUI.transform.SetParent(this.transform);
            newRocketUI.transform.localScale = new Vector3(1, 1, 1);
            newRocketUI.Constructor(listInfo[i]);
            newRocketUI.updateRocket += UpdateRocket;
            newRocketUI.updateScore += Sale;
            newRocketUI.transform.position = new Vector3(newRocketUI.transform.position.x, newRocketUI.transform.position.y, 0);

            roketUIs.Add(newRocketUI);
            updateScore(save.Score);
            updateRoketUI(save.Sprite);
        }
    }
   
    private void UpdateRocket(Rocket rocket, Sprite sprite)
    {
        save.SetRoket(rocket,sprite);
        save.SaveState();
        updateRoketUI(sprite);
    }

    private bool Sale(int price)
    {
        if (save.Score>=price)
        {
            save.Score = save.Score - price;
            updateScore(save.Score);
            save.SaveState();
            return true;
        }
        else
        {
            return false;
        }
    }
}
