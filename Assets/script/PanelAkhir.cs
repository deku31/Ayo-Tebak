using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelAkhir : MonoBehaviour
{
    private ManagerSoal Soal;
    [SerializeField] private string HeaderText;
    [SerializeField] private Text Header, scoreAkhir;

    int _ScoreAkhir = 0;
    private void Awake()
    {
        Soal = FindObjectOfType<ManagerSoal>();
        _ScoreAkhir = 0;
    }
    private void Start()
    {
        scoreAkhir.text = Soal.jawabanBenar.ToString();
        Header.text = HeaderText;
    }

    public void navigator(string Tujuan)
    {
        SceneManager.LoadScene(Tujuan);
    }
}
