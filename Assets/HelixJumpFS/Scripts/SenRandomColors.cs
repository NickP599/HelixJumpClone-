using UnityEngine;
using UnityEngine.UI;

public class SenRandomColors : MonoBehaviour
{
    [SerializeField] private Material ballMat;
    [SerializeField] private Material axisMat;
    [SerializeField] private Material defaultMatSegment;
    [SerializeField] private Material trapSegmentMat;
    [SerializeField] private Material finishSegmentMat;
    [SerializeField] private Image image;
    

    [SerializeField] private Color[] ballMatcolors;
    [HideInInspector]public Color ballMathColor => ballMat.color;

    [SerializeField] private Color[] axisMatcolors;
    [SerializeField] private Color[] defaultMatSegmentcolors;
    [SerializeField] private Color[] trapSegmentMatcolors;
    [SerializeField] private Color[] finishSegmentMatcolors;



    private void Start()
    {
        int index = Random.Range(0, ballMatcolors.Length);

        ballMat.color = ballMatcolors[index];
        axisMat.color = axisMatcolors[index];
        defaultMatSegment.color = defaultMatSegmentcolors[index];
        trapSegmentMat.color = trapSegmentMatcolors[index];
        finishSegmentMat.color = finishSegmentMatcolors[index];

        SetBackGraundColor();

    }

    private void SetBackGraundColor()
    {
        Color color = finishSegmentMat.color;
        color.a = 0.5f;
        image.color = color;
    }


}
