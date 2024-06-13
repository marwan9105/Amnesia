using System.Collections.Generic;
using UnityEngine;

public class MoveRuller : MonoBehaviour
{
    PadLockPassword _lockPassword;
    PadLockEmissionColor _pLockColor;

    [HideInInspector]
    public List<GameObject> _rullers = new List<GameObject>();
    private int _scroolRuller = 0;
    private int _changeRuller = 0;
    [HideInInspector]
    public int[] _numberArray = { 0, 0, 0, 0 };

    private int _numberRuller = 0;

    private bool _isActveEmission = false;

    void Awake()
    {
        _lockPassword = FindObjectOfType<PadLockPassword>();
        _pLockColor = FindObjectOfType<PadLockEmissionColor>();

        _rullers.Add(GameObject.Find("Ruller1"));
        _rullers.Add(GameObject.Find("Ruller2"));
        _rullers.Add(GameObject.Find("Ruller3"));
        _rullers.Add(GameObject.Find("Ruller4"));

        foreach (GameObject r in _rullers)
        {
            r.transform.Rotate(-144, 0, 0, Space.Self);
        }
    }

    void Update()
    {
        MoveRulles();
        RotateRullers();
        _lockPassword.Password();
    }

    void MoveRulles()
    {
        // Changez les touches d'interaction à d'autres touches (par exemple, E et R pour changer de rouleau)
        if (Input.GetKeyDown(KeyCode.W))
        {
            _isActveEmission = true;
            _changeRuller++;
            _numberRuller += 1;

            if (_numberRuller > 3)
            {
                _numberRuller = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isActveEmission = true;
            _changeRuller--;
            _numberRuller -= 1;

            if (_numberRuller < 0)
            {
                _numberRuller = 3;
            }
        }
        _changeRuller = (_changeRuller + _rullers.Count) % _rullers.Count;

        for (int i = 0; i < _rullers.Count; i++)
        {
            if (_isActveEmission)
            {
                if (_changeRuller == i)
                {
                    _rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = true;
                    _rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
                }
                else
                {
                    _rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                    _rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
                }
            }
        }
    }

    void RotateRullers()
    {
        // Changez les touches d'interaction à d'autres touches (par exemple, T pour +1 et G pour -1)
        if (Input.GetKeyDown(KeyCode.R))
        {
            _isActveEmission = true;
            _scroolRuller = 36;
            _rullers[_changeRuller].transform.Rotate(-_scroolRuller, 0, 0, Space.Self);

            _numberArray[_changeRuller] += 1;

            if (_numberArray[_changeRuller] > 9)
            {
                _numberArray[_changeRuller] = 0;
            }
        }
    }
}
