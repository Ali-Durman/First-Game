using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Controller : MonoBehaviour
{

    public GameObject Ball;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        // �ncelikle 2 nokta aras�ndaki mesafeyi nas�l bulurum? = �imdi kameram�z�n pozisyonundan karakterimizin pozisyonunu ��kart�rsak aras�ndaki
        // transform.position                             // mesafeyi bulmu� oluruz. Peki biz kameram�z�n pozisyonununa nas�l ula�abiliriz? = �uan zaten kameran�n i�erisine bir kod yaz�yoruz.
        // ama bu �ekilde topumuzun pozisyonununa ula�am�yoruz bu y�zden hemen yukar�da oyun objesini at�yoruz globale.

        // Ball.transform.position                        // bu �ekilde ula�abiliyoruz. (topun pozisyonuna)

        distance = transform.position - Ball.transform.position;    // Bu �ekilde aradaki mesafeyi bir kez buldurttuk bak�n fark�ndaysan�z starta yazd�m tek kez buldurmam yeterli ve bunu hep kullanabilirim.
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Ball.transform.position + distance;    // �imdi burada update metodunu kulland�k ama bu kamera olaylar�nda LateUpdate kullan�l�yor. �imdi 3 tane Update t�r� g�rm�� oluca��z.

        // Bunlar FixedUpdate, Update, LateUpdate
        // LateUpdate = B�t�n Updateler bittikten sonra �al���yor. Bu �ekilde kameran�n g�r�nt�s� daha g�zel oluyor �b�r t�rl� bazen titremeler olabiliyor.
    }
}
