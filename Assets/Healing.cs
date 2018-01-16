using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healing : MonoBehaviour {

    public GameObject[] healthBarSprite = new GameObject[3];

    public float curHealth = 3;

    public int healthcount;
    private bool dmg = false;
        

	void Start ()
    {
        healthcount = 0;
        //healthBarSprite[0].SetActive(true);
    }
	

	void Update ()
    {
        if (curHealth <= 0)
            Restart();
	
	}

    public void Damage(float damage)
    {
        curHealth = curHealth - damage;
    }
    public void recoverHealth(float heal)
    {
        curHealth = curHealth + heal;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(!dmg) //this is to stop the healthbars going down without waiting 3 seconds
        {
            if (other.gameObject.CompareTag("Enemies"))
            {
                Damage(1); //by making it a function, you can control how much u want it to hurt. So use same function for stronger enemies.
                healthBarSprite[healthcount].SetActive(false);
                healthcount++;
                healthBarSprite[healthcount].SetActive(true);
                dmg = true;
                yield return new WaitForSeconds(3);
                dmg = false;
            }
        }

        if (!dmg) //this is to stop the healthbars going down without waiting 3 seconds
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Damage(1); //by making it a function, you can control how much u want it to hurt. So use same function for stronger enemies.
                healthBarSprite[healthcount].SetActive(false);
                healthcount++;
                healthBarSprite[healthcount].SetActive(true);
                dmg = true;
                yield return new WaitForSeconds(3);
                dmg = false;
            }

        }
    }
    void Restart() //denne gjør at spilleren kan få fullt liv 
    {
        healthBarSprite[0].SetActive(true);
        curHealth = 3; //fullt liv
        healthcount = 0; //første bildet, altså tre hjerter
    }
}

//IEnumerator OnTriggerEnter2D(Collider2D other)//valgte å sette IEnumeartor her istedenfor void fordi det gjorde at koden ble mer effektiv
//                                              //når man går inn i en collider som kan ta liv fra spilleren, som spikes og fienden.
//                                              //denne setter også at spilleren kan bli immune mot å ta skade på tre sekunder fordi man stanser koden ved IEnumerator og yield. 
//{
//    if (!damageTaken)
//    { //hvis man ikke allerede har tatt skade
//        if (other.gameObject.CompareTag("CanLose"))
//        { //leter etter taggen "CanLose"
//            Damage(1);//her sender man inn 1. Altså, man tar en skade ved å gå inn med ting tagget med CanLose
//            hurt = true;
//            anim.SetBool("TakeDamage", hurt);
//            sprite[healtcount].SetActive(false); //array bildene blir falske
//            healtcount++; //her setter man inn den neste bildet i arrayen
//            sprite[healtcount].SetActive(true); //dette nye bildet blir synlig
//            damageTaken = true;
//            yield return new WaitForSeconds(3); //her tvinger man koden til å stoppe i tre sekunder. Dette er for å gi spilleren rom til å romme fra collideren den er i som gir skade
//            damageTaken = false;
//        }
//    }
//    else
//    {
//        hurt = false;
//        anim.SetBool("TakeDamage", hurt);
//    }
//
//    if (currentHealth <= 0) //hvis helsen er lik eller mindre enn 0
//    {
//        lose.Die(); //her får man funksjonen Die, fra lose scriptet
//        Restart(); //denne kalles opp gjør klart alt igjen til å spilles på nytt
//        yield return new WaitForSeconds(2.5f); //gjør at de tre hjertene i dukker opp igjen før etter spilleren har blitt transportert til begynnelsen 
//        sprite[healtcount].SetActive(true);
//        sprite[3].SetActive(false); //denne er fortsatt aktiv i når helsa skal starte på nytt igjen, siden alle blir satt sant. Men med denne, så blir den slått av. 
//    }
//
//}
//
//void Restart() //denne gjør at spilleren kan få fullt liv og at bilde arrayen begynner på nytt igjen, altså viser tre hjerter. 
//{
//    currentHealth = 3; //fullt liv
//    healtcount = 0; //første bildet, altså tre hjerter
//}