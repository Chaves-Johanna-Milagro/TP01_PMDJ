using UnityEngine;

public class MovementPt2 : MonoBehaviour //formula y = mx + b  ej y = 2x + 0  
{
    private Vector3 targetA = new Vector3(5f,10f,0f); //con x = 5 e y = 12
    private Vector3 targetB = new Vector3 (10f,20f,0f); //con x = 10 e y = 20
    private float speed = 15f;
    private Vector3 target;

    void Start()
    {
        transform.position = targetA;//posicion inicial 
        target = targetA;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Cambia la dirección al llegar a un punto
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = target == targetA ? targetB : targetA; // si target es igual a targetA entonces ahora target es igual a targetB
        }
    }


}
