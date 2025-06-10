using UnityEngine;

public class MovementPt3 : MonoBehaviour
{
    private Transform puntoA;
    private Transform puntoB;
    private float alturaMax = 15f;
    private float duracion = 2f;

    private float t = 0f;
    private bool subiendo = true;

    // Coeficientes para parábola: f(t) = a*t^2 + b*t + c
    private float a, b, c;

    void Start()
    {
        puntoA = transform.parent.Find("PuntoA");
        puntoB = transform.parent.Find("PuntoB");

        // Ajustar a, b, c para una parábola con vértice en t=0.5 y altura "alturaMax"
        float h = 0.5f; // vértice en la mitad
        float k = alturaMax;

        // Derivados de forma canónica: f(t) = a*(t - h)^2 + k => f(t) = at^2 + bt + c
        a = -4 * k;
        b = 4 * k;
        c = 0;
    }

    void Update()
    {
        // Avanza o retrocede el tiempo entre 0 y 1
        float velocidad = Time.deltaTime / duracion;
        t += subiendo ? velocidad : -velocidad;
        t = Mathf.Clamp01(t);

        // Movimiento lineal de A a B
        Vector3 posLineal = Vector3.Lerp(puntoA.position, puntoB.position, t);

        // Altura de la parábola
        float alturaY = a * t * t + b * t + c;

        // Aplicar la parábola al eje Y
        transform.position = posLineal + Vector3.up * alturaY;

        // Cambiar dirección si llegó al extremo
        if (t >= 1f) subiendo = false;
        else if (t <= 0f) subiendo = true;
    }
}
