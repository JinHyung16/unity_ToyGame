using UnityEngine;
using UnityEngine.UI;

public class ParticlePurchase : MonoBehaviour
{
    public Transform spawnPos;

    public GameObject particleObj;
    private ParticleSystem particle;

    public Image particleImg;
    public float particleCost;

    [HideInInspector]
    public bool isPurchased = false;

    public Toggle toggle;
    private void Awake()
    {
        toggle.onValueChanged.AddListener(GetParticle);
        particle = particleObj.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(isPurchased == true)
        {
            particleCost = 0;
        }
        else
        {
            return;
        }
    }
    public void GetParticle(bool purchase)
    {
        if(purchase == true && isPurchased == false)
        {
            if (Data.M_Data.gold >= particleCost)
            {
                Data.M_Data.gold -= particleCost;
                particle.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z);
                isPurchased = true;
            }
        }

        if(purchase == true && isPurchased == true)
        {
            particle.Play(true);
            particleImg.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            particle.Stop(true);
            particleImg.color = new Color(1, 1, 1, 1);
        }
    }
}
