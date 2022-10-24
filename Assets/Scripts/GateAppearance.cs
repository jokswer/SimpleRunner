using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateAppearance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Image topImage;
    [SerializeField] private Image glassImage;

    [SerializeField] private Color colorPositive;
    [SerializeField] private Color colorNegative;

    [SerializeField] private GameObject expandLabel;
    [SerializeField] private GameObject shrinkLabel;
    [SerializeField] private GameObject upLabel;
    [SerializeField] private GameObject downLabel;

    public void UpdateVisual(DeformationType deformationType, int value)
    {
        DisableAllLabels();
        UpdateText(value);
        UpdateColor(value);
        UpdateLabel(deformationType, value);
    }

    private void SetColor(Color color)
    {
        topImage.color = color;
        glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }

    private void UpdateColor(int value)
    {
        if (value > 0)
        {
            SetColor(colorPositive);
        }
        else if (value == 0)
        {
            SetColor(Color.gray);
        }
        else
        {
            SetColor(colorNegative);
        }
    }

    private void DisableAllLabels()
    {
        expandLabel.SetActive(false);
        shrinkLabel.SetActive(false);
        upLabel.SetActive(false);
        downLabel.SetActive(false);
    }

    private void UpdateLabel(DeformationType deformationType, int value)
    {
        if (deformationType == DeformationType.Width)
        {
            if (value > 0)
            {
                expandLabel.SetActive(true);
            }
            else
            {
                shrinkLabel.SetActive(true);
            }
        }
        else
        {
            if (value > 0)
            {
                upLabel.SetActive(true);
            }
            else
            {
                downLabel.SetActive(true);
            }
        }
    }

    private void UpdateText(int value)
    {
        text.text = $"{(value > 0 ? "+" : "")}{value.ToString()}";
    }
}