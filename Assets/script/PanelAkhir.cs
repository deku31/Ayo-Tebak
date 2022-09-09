using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAkhir : MonoBehaviour
{
    private ManagerSoal Soal;
    [SerializeField] private Text scoreAkhir;

    private void Awake()
    {
        Soal = FindObjectOfType<ManagerSoal>();
    }
    private void Start()
    {
        scoreAkhir.text = Soal.jawabanBenar.ToString();
    }
}
