using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]private TMP_Text _textField;

    private void OnEnable()
    {
        _textField.text = $"Points: {GameManager.singleton.points}";
    }
}
