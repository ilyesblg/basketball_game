using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int dotsNumber;
    [SerializeField] private GameObject dotsParent;
    [SerializeField] private GameObject dotsPrefab;
    [SerializeField] private float dotSpacing;

    private Transform[] dotsList;

    private void Start()
    {
        Hide();
        PrepareDots();
    }

    private void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];

        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotsPrefab, dotsParent.transform).transform;
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        float timeStamp = dotSpacing;

        for (int i = 0; i < dotsNumber; i++)
        {
            Vector2 pos = new Vector2(
                ballPos.x + forceApplied.x * timeStamp,
                ballPos.y + forceApplied.y * timeStamp - 0.5f * Physics2D.gravity.magnitude * timeStamp * timeStamp
            );

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
