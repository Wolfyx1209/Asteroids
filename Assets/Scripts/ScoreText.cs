using System;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private TMP_Text _tmpText;

    private void Start()
    {
        _tmpText = GetComponent<TMP_Text>();
    }
}
