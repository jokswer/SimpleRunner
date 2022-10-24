using System;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    private static readonly int PushValue = Shader.PropertyToID("_PushValue");

    private float _widthMultiplier = 0.0005f;
    private float _heightMultiplier = 0.01f;

    [SerializeField] private AudioSource pumpSound;

    [SerializeField] private Renderer renderer;
    [SerializeField] private Transform topSpine;
    [SerializeField] private Transform bottomSpine;
    [SerializeField] private Transform colliderTransform;

    [SerializeField] private int width;
    [SerializeField] private int height;

    void Start()
    {
        SetWidth(Progress.Instance.Width);
        SetHeight(Progress.Instance.Height);
    }

    void Update()
    {
        var spineOffsetY = height * _heightMultiplier + 0.17f;
        var colliderOffsetY = 1.84f + height * _heightMultiplier;

        topSpine.position = bottomSpine.position + new Vector3(0, spineOffsetY, 0);
        colliderTransform.localScale = new Vector3(1, colliderOffsetY, 1);

        if (Input.GetKeyDown(KeyCode.W))
        {
            AddWidth(20);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            AddHeight(20);
        }
    }

    public void AddWidth(int value)
    {
        width += value;
        UpdateWidth();
        PlaySound(value);
    }

    public void AddHeight(int value)
    {
        height += value;
        PlaySound(value);
    }

    public void SetWidth(int value)
    {
        width = value;
        UpdateWidth();
    }

    public void SetHeight(int value)
    {
        height = value;
    }

    public void HitBarrier()
    {
        if (height > 0)
        {
            height -= 50;
        }
        else if (width > 0)
        {
            width -= 50;
            UpdateWidth();
        }
        else
        {
            Die();
        }
    }

    private void UpdateWidth()
    {
        renderer.material.SetFloat(PushValue, width * _widthMultiplier);
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().ShowFinishWindow();
    }

    private void PlaySound(int value)
    {
        if (value > 0)
        {
            pumpSound.Play();
        }
    }
}