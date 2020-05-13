using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour
{
    [SerializeField] private List <InfoText> infotext;
    [SerializeField] private List <ProgramText> programtext;

   [SerializeField] private Text _info;
   [SerializeField] private Text _berendInfo;

    [SerializeField] private Text _vraag;
    [SerializeField] private Text _berendUitleg;
    [SerializeField] private Text _antwoord1;
    [SerializeField] private Text _antwoord2;
    [SerializeField] private Text _antwoord3;

    private int _sObjectIndex;
    void Start()
    {
        FetchInfo();
    }

    public void FetchInfo(){
        _info.text = infotext[_sObjectIndex].uitleg;
        _berendInfo.text = infotext[_sObjectIndex].berendUitleg;
        _vraag.text = programtext[_sObjectIndex].vraag;
        _berendUitleg.text = programtext[_sObjectIndex].berendUitleg;
        _antwoord1.text = programtext[_sObjectIndex].antwoord1;
        _antwoord2.text = programtext[_sObjectIndex].antwoord2;
        _antwoord3.text = programtext[_sObjectIndex].antwoord3;
    }

    public void NextScriptable()
    {
        _sObjectIndex ++;
    }
}
