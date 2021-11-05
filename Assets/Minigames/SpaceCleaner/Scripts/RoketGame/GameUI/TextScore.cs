
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour
{

    private Text textScore;
    private int countScore;
    [SerializeField] private ScoreManager manager;
    void Awake()
    {
        textScore = this.GetComponent<Text>();
        textScore.text = "Your Score: 0";
        manager.updateUI += OnGrabGarbage;
    }

    private void OnDestroy()
    {
        manager.updateUI -= OnGrabGarbage;

    }

    public void OnGrabGarbage(int score)
    {
         countScore=score;
        textScore.text = "Your Score: " + countScore.ToString();
    }


}
