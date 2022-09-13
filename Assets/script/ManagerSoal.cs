using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSoal : MonoBehaviour
{
    [SerializeField] private Text soalTxt;
    [SerializeField] private Text Score;
    public int jawabanBenar;

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

    [SerializeField] private List<Image> Btn;
    [SerializeField] private List<Text> textcolor;

    [SerializeField] private Color colordefault;
    [SerializeField] private Color colorcorrect;
    [SerializeField] private Color TextColorCorrect;
    [SerializeField] private Color TextColordefault;

    bool starttime;

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
        starttime = true;
        foreach (var item in Btn)
        {
            item.color = colordefault;
        }
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
        if (starttime == true)
        {
            time -= Time.deltaTime;
        }
        timetxt.text = time.ToString("0");
        if (time < 1)
        {
            starttime = false;
            StartCoroutine(timer());
            gantisoal();
            time = TimeDefault;
        }
       
    }

    IEnumerator timer()
    {
        cekjawaban();
        yield return new WaitForSeconds(0.9f);
        if (DaftarSoal.Count > 0)
        {
            starttime = true;
            foreach (var item in Btn)
            {
                item.color = colordefault;
            }
            foreach (var item in textcolor)
            {
                item.color = TextColordefault;
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
        
        //DaftarSoal.RemoveAt(AcakSoal);

        StopCoroutine(timer());
    }
    void gantisoal()
    {
        DaftarSoal.RemoveAt(AcakSoal);
        AcakSoal = Random.RandomRange(0, DaftarSoal.Count - 1);
    }
    private void cekjawaban()
    {
        if (DaftarSoal[AcakSoal].A == true)
        {
            Btn[0].color = colorcorrect;
            textcolor[0].color = TextColorCorrect;
        }
        else if (DaftarSoal[AcakSoal].B == true)
        {
            textcolor[1].color = TextColorCorrect;
            Btn[1].color = colorcorrect;
        }
        else if (DaftarSoal[AcakSoal].C == true)
        {
            textcolor[2].color = TextColorCorrect;
            Btn[2].color = colorcorrect;
        }
        else if (DaftarSoal[AcakSoal].D == true)
        {
            textcolor[3].color = TextColorCorrect;
            Btn[3].color = colorcorrect;
        }
        else
        {
            foreach (var item in Btn)
            {
                item.color = colordefault;
            }
            foreach (var item in textcolor)
            {
                item.color = TextColordefault;
            }
        }
    }

    public void pilihanBtn(string pilihan)
    {
        if (DaftarSoal[AcakSoal].A == true && pilihan == "A")
        {
            print("Benar");
            jawabanBenar++;
            cekjawaban();

        }
        else if (DaftarSoal[AcakSoal].B == true && pilihan == "B")
        {
            print("Benar");
            jawabanBenar++;
            cekjawaban();
        }
        else if (DaftarSoal[AcakSoal].C == true && pilihan == "C")
        {
            jawabanBenar++;
            print("Benar");
            cekjawaban();
        }
        else if (DaftarSoal[AcakSoal].D == true && pilihan == "D")
        {
            jawabanBenar++;
            print("Benar");
            Btn[3].color = colorcorrect;
            cekjawaban();
        }
        if (DaftarSoal.Count-1>=0)
        {
            StartCoroutine(timer());

            gantisoal();
            time = TimeDefault;
        }
        else
        {
            panelAkhir.SetActive(true);
        }

    }
}
