using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public HPBarImage HPBarI;
    public GameObject HPBar;
    public float HPRatio;
    public Image HPBarImage;
    private PlayerStat stat;
    float checkHP;
    //기본 화면 세팅
    void Awake()
    {
        HPBar.SetActive(false);
        HPBar.SetActive(true);

        //HP바 이미지 컴포넌트 가져오기
        HPBarI = GetComponentInChildren<HPBarImage>();
        HPBarImage = HPBarImage.gameObject.GetComponent<Image>();

        stat = FindObjectOfType<PlayerStat>();

    }

    void Update()
    {
        //HP바 업데이트
        if(stat.HP != 0) 
        {
            HPBarImage.fillAmount = HPRatioSet();
        }
        else {  HPBar.SetActive(false); }
    }

    //HP비율 산정
    public float HPRatioSet() {return stat.HP / stat.MaxHP;}
}
