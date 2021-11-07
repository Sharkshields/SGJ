using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuRocket : MonoBehaviour
{
    [SerializeField] private MainMenuManager manager;
    private Image image;

    private void Awake()
    {
        image = this.GetComponent<Image>();
        manager.updateRoketUI += UpdateImage;
    }

    private void UpdateImage(Sprite sprite)
    {
        image.sprite = sprite;
        image.preserveAspect = true;
    }
}
