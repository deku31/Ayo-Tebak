using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSoal : MonoBehaviour
{
    [SerializeField] private Text soalTxt;
    [SerializeField] private Text Score;
    [SerializeField] private int jawabanBenar;

    [Header("Time Manager")]
    [SerializeField] private Text timetxt;
    [SerializeField] private float TimeDefault=5;
    float time;

    [Header("Clue")]
    public string _Petunjuk;
    public Text Petunjuk;

    [Header("Text Jawaban")]
    [SerializeField] private Text JawabanA;
    [SerializeField] private Text JawabanB, JawabanC, JawabanD;

    public int AcakSoal;

    [System.Serializable]
    public class soal
    {
        [TextArea]
        [Header("Soal")]
        public string textsoal;

        [Header("Jawaban")]
        public string JawabanA;
        public string JawabanB, JawabanC, JawabanD;

        [Header("Kunci")]
        public bool A;
        public bool B, C, D;

        [Header("Penjelasan")]
        public string Penjelasan;
    }
    public List<soal> DaftarSoal;

    [SerializeField] private GameObject panelAkhir;
   
    private void Awake()
    {
        soalTxt = GameObject.Find("Soal").GetComponent<Text>();
    }
    private void Start()
    {
        panelAkhir.SetActive(false);
        time = TimeDefault;
        AcakSoal = Random.RandomRange(0, DaftarSoal.Count);
        soalTxt.text = DaftarSoal[AcakSoal].textsoal;
        Petunjuk.text = "Petunjuk : "+_Petunjuk;

        //text jawaban
        JawabanA.text = DaftarSoal[AcakSoal].JawabanA;
        JawabanB.text = DaftarSoal[AcakSoal].JawabanB;
        JawabanC.text = DaftarSoal[AcakSoal].JawabanC;
        JawabanD.text = DaftarSoal[AcakSoal].JawabanD;
    }

    private void Update()
    {
        Score.text = jawabanBenar.ToString();
        if (DaftarSoal.Count-1>=0)
        {
            time -= Time.deltaTime;
            timetxt.text = time.ToString("0");
            if (time <= 0)
            {
                DaftarSoal.RemoveAt(AcakSoal);
                AcakSoal = Random.RandomRange(0, DaftarSoal.Count);
                time = TimeDefault;
            }
            soalTxt.text = DaftarSoal[AcakSoal].textsoal;
            Petunjuk.text = "Petunjuk : " + _Petunjuk;

            //text jawaban
            JawabanA.text = DaftarSoal[AcakSoal].JawabanA;
            JawabanB.text = DaftarSoal[AcakSoal].JawabanB;
            JawabanC.text = DaftarSoal[AcakSoal].JawabanC;
            JawabanD.text = DaftarSoal[AcakSoal].JawabanD;
        }
        else
        {
            panelAkhir.SetActive(true);
        }
    }
    public void pilihanBtn(string pilihan)
    {
        if (DaftarSoal[AcakSoal].A == true && pilihan == "A")
        {
            print("Benar");
            jawabanBenar++;
        }
        else if (DaftarSoal[AcakSoal].B == true && pilihan == "B")
        {
            print("Benar");
            jawabanBenar++;

        }
        else if (DaftarSoal[AcakSoal].C == true && pilihan == "C")
        {
            jawabanBenar++;
            print("Benar");
        }
        else if (DaftarSoal[AcakSoal].D == true && pilihan == "D")
        {
            jawabanBenar++;
            print("Benar");
        }
        if (DaftarSoal.Count-1>=0)
        {
            DaftarSoal.RemoveAt(AcakSoal);
            AcakSoal = Random.RandomRange(0,DaftarSoal.Count);
            time = TimeDefault;
        }
        else
        {
            panelAkhir.SetActive(true);
        }

    }
}
