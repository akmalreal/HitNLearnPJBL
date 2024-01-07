using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsnumber;
    [SerializeField] GameObject Dotsparent;
    [SerializeField] GameObject DotsPerfab;
    [SerializeField] float dotSpacing;
    [SerializeField][Range(0.01f, 0.5f)] float dotMinScale;
    [SerializeField][Range(0.5f, 1f)] float dotMaxScale;

    Transform[] dotsList;
    Vector2 pos;
    float timeStamp;

    private void Start()
    {
        Hide();
        PrepareDots();
    }

    private void PrepareDots()
    {
        dotsList = new Transform[dotsnumber];
        DotsPerfab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scalefactor = scale / dotsnumber;

        for (int i = 0; i < dotsnumber; i++)
        {
            GameObject dot = Instantiate(DotsPerfab, Dotsparent.transform);
            dotsList[i] = dot.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
            {
                scale -= scalefactor;
            }
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied) // Mengubah Updatedots menjadi UpdateDots (penamaan yang benar)
    {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsnumber; ++i)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    {
        Dotsparent.SetActive(true);
    }

    public void Hide()
    {
        Dotsparent.SetActive(false);
    }
}
