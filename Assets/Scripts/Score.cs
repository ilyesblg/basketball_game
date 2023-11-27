using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static Score instance;
    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishTrigger")
        {
            PlayerPrefs.SetInt("score", score);
            score++;
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }

        scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
