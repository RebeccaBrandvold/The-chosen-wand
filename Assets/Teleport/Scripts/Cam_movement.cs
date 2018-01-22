using UnityEngine;
using System.Collections;

public class Cam_movement : MonoBehaviour

//dette er med for å begrense hva spilleren kan se. Nyttig sånn at man ikke kan se utenfor bakgrunnene og sånt. 
{
	[SerializeField]//jeg bruker SerializeField for å kunne få tak i disse i scenen, men likevel beholde de som private, altså ikke endrer verdien i scriptet. Lett å endre i andre leveler derfor jeg har brukt dette
    private float xMax; //sier hvor mye x koordinaten til høyre
    [SerializeField]
    private float yMax; //samme som i x, bare y koordinater
    [SerializeField]
    private float xMin; //sier hvor lite x koordinatene kan være
    [SerializeField]
    private float yMin; //samme som x, bare med y
    [SerializeField]
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform; //Er leter den etter navnet Player og dens transform	
    }

    void LateUpdate() //denne skjer etter update. Dette skal man alltid bruke for kameraer
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
        //Mathf.Clamp er en metode å bruke når man har en verdi på x og har en minimum og maximum.
        //target.position.x er spillerens posisjon. xMin og xMax er verdier man kan fylle inn fra editor når man har sjekket hvor langt man vil at kameranene skal gå og hvor mye spilleren skal kunne se
        //z kommer ikke til å bevege seg, den har samme verdi som alltid.	
    }
}
