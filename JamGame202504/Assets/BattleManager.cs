using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    private void Start()
    {
        returnButton.OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(1))
            .Subscribe(_ => { BattleFlowController.Instance.EndBattle(); });    
    }
}
