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
    //�⺻ ȭ�� ����
    void Awake()
    {
        HPBar.SetActive(false);
        HPBar.SetActive(true);

        //HP�� �̹��� ������Ʈ ��������
        HPBarI = GetComponentInChildren<HPBarImage>();
        HPBarImage = HPBarImage.gameObject.GetComponent<Image>();

        stat = FindObjectOfType<PlayerStat>();

    }

    void Update()
    {
        //HP�� ������Ʈ
        if(stat.HP != 0) 
        {
            HPBarImage.fillAmount = HPRatioSet();
        }
        else {  HPBar.SetActive(false); }
    }

    //HP���� ����
    public float HPRatioSet() {return stat.HP / stat.MaxHP;}
}
