using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;

    [SerializeField] Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        enemyController = GetComponentInChildren<EnemyController>();
    }

    private void Start()
    {
        slider.maxValue = enemyController.hp;
        slider.value = enemyController.hp;

        enemyController.OnDamaged.AddListener((hp) => { slider.value = hp; });
    }
}
