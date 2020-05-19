using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    public ProgressBar pb;
    
    public Damageable dmg;

    public void Start()
    {
        dmg.OnHurt.AddListener(Refresh);
    }

    public void Refresh(int _)
    {
        pb.SetPercentage((float)dmg.health / (float)dmg.maxHealth);
    }
}
