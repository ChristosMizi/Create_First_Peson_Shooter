using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public Image _currentHealthBar;
    public Slider healthbar;
    public Text _ratioText;

    [SerializeField]
    private float _currentHealth = 150;
    [SerializeField]
    private float _maxHitPoint = 150;

    private void Start()
    {
        UpdateHealthBar();
        
        GameObject zk = GameObject.FindWithTag("Canvas");
        
    }
    private void UpdateHealthBar()
    {
        float ratio = _currentHealth / _maxHitPoint;
        _currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        _ratioText.text = (ratio * 100).ToString("0") + '%';

    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {

            _currentHealth = 0;
            Debug.Log("Player is Dead");
            Destroy(this.gameObject);
            
        }
        UpdateHealthBar();

    }


    private void HealDamage(float heal)
    {
        _currentHealth += heal;
        if (_currentHealth > _maxHitPoint)
        {

            _currentHealth = _maxHitPoint;
            Debug.Log("Dead");
           
        }
        UpdateHealthBar();
    }
}
