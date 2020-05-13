using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour
{
    public List <InfoText> infotext;

   [SerializeField] private Text info;
   [SerializeField] private Text berendInfo;

    private int _sObjectIndex;
    void Start()
    {
        FetchInfo();
    }

    public void FetchInfo(){
        info.text = infotext[_sObjectIndex].uitleg;
        berendInfo.text = infotext[_sObjectIndex].berendUitleg;
    }

    public void NextScriptable()
    {
        _sObjectIndex ++;
        FetchInfo();
    }

}
