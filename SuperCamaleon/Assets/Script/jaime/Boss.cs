using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int rutina;
    public float conometro;
    public float time_rutinas;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;
    public RangoBoss rango;
    public float speed;
    public GameObject[] hit;
    public int hit_Select;
    
    //rayo lazer//
    public bool lanza_llamas;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject cabeza;
    private float cronometro2;
    
    //putazo//
    public float jump_distance;
    public bool direction_skill;
    
    //gaydar//
    public GameObject fire_ball;
    public GameObject Point;
    public List<GameObject> pool2 = new List<GameObject>();

    //reset jugador//
    //////// 
    public int fase = 1;
    public float HP_Min;
    public float HP_Max;
    public Image barra;
    public AudioSource musica;
    public bool muerto;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Link");
    }

}
