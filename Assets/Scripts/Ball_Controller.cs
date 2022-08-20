using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     // User interface yani kullan�c� aray�z k�t�phanesini ekledik.

public class Ball_Controller : MonoBehaviour
{

    Rigidbody fizik; // bir �nceki dersimizde rigidbodyi void start�n i�erisindeki sat�rda tan�malm��t�m a�a��da �rnek olarak yaz�yor. Biz fizi�e hi� bir yerde ula�am�yoruz, bu y�zden globalde tan�ml�yoruz.
    public int hiz;
    int sayac = 0;
    public int Coins;

    public Text SayacText;
    public Text Finish;

    // Start is called before the first frame update
    void Start()    // Bir kere �al��an bir metot
    {
        fizik = GetComponent<Rigidbody>();        // Rigidbody fizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()         // Normal Update komutumuzu zaten biliyoruz, s�rekli �al���yor ama belli bir zamana g�re �al��m�yor yani belli bir oranda de�il, de�i�ebiliyor ama FixedUpdate sabittir e�er 
        // FixedUpdate kullan�rsak sabit olur. Biz fizik haraketlerini bu FixedUpdate ile yap�ca��z. S�rekli �al���yor / �imdi Update metodumuz bizim her framede �al���yor ama bize sabit h�zda �al��an
        // metot laz�m o zaman FixedUpdate i kullan�ca��z. FixedUpdate de her zaman �al���yor ama sabit bir h�zda �al���yor.
    {
        float yatay = Input.GetAxisRaw("Horizontal");  // dikkat ettiyseniz b�y�k harfle ba�lad�k parametrede �nemli ��nk� k���k harfle Horizontal yazmayaca��z. Horizontal = yatay demek Vertical = dikey
        float dikey = Input.GetAxisRaw("Vertical");   // demek. Peki Bu GetAxisRaw bize bir float d�nd�r�yor yani bu metot bir float de�eri return ediyor, bizde bunu dikey diye bir de�i�ken tan�mlay�p
                                                      // ona atad�k.

        Vector3 vec = new Vector3(yatay,0,dikey);  // Bu kod sat�r�n�n anlam� nedir? = az sonra oyunumuzda topumuzu haraket ettirice�iz. Hangi eksende haraket etti�ini bilmem gerekiyor. X ve Z ekseninde
                // haraket ettiriyoruz. Y ekseninde yani yukar� ve ya a�a�� gitmeyecek. �ne, arkaya, sa�a, sola gidece�inden dolay� X ve Z ekseninde haraket edicek.
            // B�yle bir vekt�r olu�turduk, bu vekt�r� yani vec i bir yere parametre olarak verece�iz birazdan ve topumuz haraket edecek. G�rd���n�zde anlayacaks�n�z. x e yatay� atad�k y ye 0 � z ye de 
               // dikeyi atad�k. �imdi rigidbodyimizi olu�turucaz ��nk� rigidbodymizin i�erisinde bir metot var addforce diye topumuza kuvvet uyguluyor.

        fizik.AddForce(vec*hiz); // �imdi topumuza kuvvet uygulayaca��z. Evet bu kadar haraket ettirme komudumuz bu kadard�. Haraket ediyor ama �ok yava� haraket ediyor. hiz diye bir intager olu�turduk
        // public olucak �ekilde ve bu vector3 m�z ile �arp�yoruz. public komutu oldu�undan scriptimizin aray�z�nde art�k hiz diye bir sekme var ve buna bir de�er verirsek oyun motoru i�erisinde h�z�n�
        // istedi�imiz gibi de�i�tirebiliriz manuel bir �ekilde.

      //  Debug.Log("yatay =  " + yatay + "   dikey = " + dikey);     // bu komut konsolda  e�er yatay�n bir artmas�n� istiyorsak D tu�una bas�yoruz - 1 olmas�n� istiyorsakta A tu�una bas�yoruz.
                                                                   // dikey i�inde 1 olmas�n� istiyorsak W tu�una bas�yoruz e�er -1 olmas�n� istiyorsak S tu�una bas�yoruz.



    }


    void OnTriggerEnter(Collider other)       // �imdi bu trigger bir objeye temas edildi�inde bu metot �al��acak. Bu ontrigger in �u �ekilde 3 metodu var. Enter / Stay / Exit. Biz burada Enter kullan�caz.
    {                                          // Enter = Bir kere temas oldu�unda bir kere s�yl�yor ve bir daha �al��m�yor.
                                               // Stay = Temas oldu�u s�re boyunca hep bizi uyar�yor.
                                               // Exit = Temas oldu ve temastan ��k�ld�ktan sonra yazd�r�yor.
                                               //  Debug.Log("Temas Oldu");

       // Destroy(other.gameObject);        // Burada g�rd���n�z farkl� bir parametre var other. Burada temas edilen oyun objesini yok et kodunu yazd�k ama bu �ok iyi bir y�ntem de�il ��nk� bizim sahnemiz
                                        // de ba�ka triggerl� elemanlar olabilir. Biz sadece coin vb olan �eyleri silmek istedik ama farkl� objelerde silindi bunu olsun istemedik. Buna bir ��z�m olarak
                                        // �ncelikle bu coinlerimize ve ya vb objelerimize birer etiket vermemiz gerekiyor tag yani prefab �zerinden add tag yapabiliriz ve hepsinde art�k coin diye bir tag
                                        // var. �imdi biz diyece�iz ki yukar�daki kodda sadece coin olanlar� sil.


       // if (other.gameObject.tag== "Coins")       // Buradaki e�er komudunda sadece tagleri Coins isminde olan etiketli objeleri de�dik�e oyundan kald�r/sil. 
       /* {
           // Destroy(other.gameObject);            // fark� triggerl� olan objelere tag verip mesela x olsun x e de�erse konumunu de�i�tirebiliriz, yok edebiliriz, boyutunu de�i�tirebilirdik vb �eyleri
                                                    // yapabilirdik. �imdi burada biz objelerimizi yok ediyoruz biz bunlar� yok etmeyelim sadece kapatal�m.

            other.gameObject.SetActive(false);            // gameobjectin setactive diye bir metodu var

        }               */
       


        
        
        if (other.gameObject.tag == "Coins")         
        {
            other.gameObject.SetActive(false);
            sayac++;
            // Debug.Log("Sayac = " + sayac);     Bunlar� art�k console da g�stermemize gerek kalmad� oyun ekran�nda g�r�yoruz.
            SayacText.text = "Coins = " + sayac;

                if (sayac == Coins)
                {
                   //  Debug.Log("Oyun Bitti");    Bunlar� art�k console da g�stermemize gerek kalmad� oyun ekran�nda g�r�yoruz.
                   Finish.text = "Finish";
                }
        }
        
    }
}
