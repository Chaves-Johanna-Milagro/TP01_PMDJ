using UnityEngine;

public class ShowAxis : MonoBehaviour // Script dentro de un emply
{
    private Vector3 _posStartX; //posicion inicial (desde donde se dibuja la linea en X)
    private Vector3 _posEndX;

    private Vector3 _posStartY; //posicion inicial (desde donde se dibuja la linea en Y)
    private Vector3 _posEndY;

    private LineRenderer _lineX; //componentes
    private LineRenderer _lineY;
  
    void Start()
    {
        //definicion de la posicion en el eje X
        _posStartX = new Vector3(5f,0f,0f);
        _posEndX = new Vector3(-5f,0f,0f);

        //definicion de la posicion en el eje Y
        _posStartY = new Vector3 (0f,5f,0f);
        _posEndY = new Vector3 (0f,-5f,0f);

        //obtencion del componenete LineRenderer de los hijos
        _lineX = transform.Find("AxisX").GetComponent<LineRenderer>();
        _lineY = transform.Find("AxisY").GetComponent<LineRenderer>();

        //definicion del grosor de la linea X
        _lineX.startWidth = 0.05f;
        _lineX.endWidth = 0.05f;

        //definicion del grosor de la linea Y
        _lineY.startWidth = 0.05f;
        _lineY.endWidth = 0.05f;

        //metodo que dibuja las lineas
        DrawAxis(); 
    }

    private void DrawAxis() 
    {
        //Eje X
        _lineX.SetPosition(0, _posStartX);
        _lineX.SetPosition(1, _posEndX);

        //Eje Y
        _lineY.SetPosition(0, _posStartY);
        _lineY.SetPosition(1, _posEndY);
    }

}
