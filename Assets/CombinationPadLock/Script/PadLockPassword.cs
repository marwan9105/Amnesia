using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;

    public int[] _numberPassword = {1, 0, 9, 0};

    [HideInInspector]
    public bool isPasswordCorrect = false;

    private void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
    }

    public void Password()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword))
        {
            isPasswordCorrect = true;

            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
            }
        }
        else
        {
            isPasswordCorrect = false;
        }
    }
}
