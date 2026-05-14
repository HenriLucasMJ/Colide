using UnityEngine;

public class SunPulse : MonoBehaviour
{
    private Material mat;

    public float speed = 2f;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        float glow = Mathf.Lerp(
            0.25f,
            0.35f,
            (Mathf.Sin(Time.time * speed) + 1f) / 2f
        );

        mat.SetFloat("_Glow", glow);
    }
}