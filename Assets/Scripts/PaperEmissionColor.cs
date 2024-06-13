using UnityEngine;

public class PaperEmissionColor : MonoBehaviour
{
    private TimeBlinking tb;
    private Renderer _renderer;
    [HideInInspector] public bool _isSelect;
    private GameObject _myPaper;

    private void Awake()
    {
        tb = FindObjectOfType<TimeBlinking>();
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        _myPaper = gameObject;
    }

    void Update()
    {
        BlinkingMaterial();
    }

    public void BlinkingMaterial()
    {
        if (_renderer != null)
        {
            _renderer.material.EnableKeyword("_EMISSION");

            if (_isSelect)
            {
                _renderer.material.SetColor("_EmissionColor", Color.Lerp(Color.clear, Color.yellow, Mathf.PingPong(Time.time, tb.blinkingTime)));
            }
            else
            {
                _renderer.material.SetColor("_EmissionColor", Color.clear);
            }
        }
        else
        {
            Debug.LogWarning("Renderer not found on the paper object!");
        }
    }
}
