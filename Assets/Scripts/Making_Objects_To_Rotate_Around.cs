using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Making_Objects_To_Rotate_Around : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);       // Burada kulland���m�z transform.Rotate vector3 axislerini al�yor. transform.Rotate ad� �st�nde d�nd�rmeye yar�yor.
                                                                        // Burada ise vector3 �n x y z ile �a�r� zamanlar�yla �arparsak stabil bir �ekilde yava�layacakt�r.
                                                                        // Bu �stte g�rd���m t�m kod coin ya da vb. objeleri stabil bir h�zda d�nd�rmeye yar�yor. 
       // Debug.Log(Time.deltaTime);     Bu Time.deltaTime nedir? = Bu her update metodunun �a�r� zaman� demektir.
    }
}
