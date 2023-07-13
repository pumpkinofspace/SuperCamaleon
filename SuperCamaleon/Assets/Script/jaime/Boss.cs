using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int rutina;
    public float cronometro;
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
    
    //gaydar////fireball//
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

    public void Comportamiento_Boss()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < 15)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            Point.transform.LookAt(target.transform.position);
            musica.enabled = true;

            //activar el boss
            if(Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
            {
                switch (rutina)
                {
                    //caminar hacia el jugador
                    case 0:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", true);
                        ani.SetBool("run", false);

                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);
                        cronometro += 1 * Time.deltaTime;
                        if(cronometro > time_rutinas)
                        {
                            rutina = Random.Range(0, 5);
                            cronometro = 0;
                        }
                        break;

                    // ir en putiza osea correr//
                    case 1:

                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", false);
                        ani.SetBool("run", true);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);
                        cronometro += 1 * Time.deltaTime;
                        if (cronometro > time_rutinas)
                        {
                            rutina = Random.Range(0, 5);
                            cronometro = 0;
                        }
                        break;

                    // rayo jotizador osea lanzallamas
                    case 2:
                        ani.SetBool("walk", false);
                        ani.SetBool("run", false);
                        ani.SetBool("attack", true);
                        ani.SetFloat("skills", 0);

                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        rango.GetComponent<CapsuleCollider>().enabled = false;


                        break;

                    //caso ataque salto
                    case 3:
                       
                        if( fase == 2)
                        {
                            jump_distance += 1 * Time.deltaTime;
                            ani.SetBool("walk", false);
                            ani.SetBool("run", false);
                            ani.SetBool("attack", true);
                            ani.SetFloat("skill", 0);
                            hit_Select = 3;
                            rango.GetComponent<CapsuleCollider>().enabled = false;

                            if (direction_skill)
                            {
                                if(jump_distance < 1f)
                                {
                                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                                }

                                transform.Translate(Vector3.forward * 8 * Time.deltaTime);
                            }



                        }
                        else
                        {
                            rutina = 0;
                            cronometro = 0;
                        }

                        break;

                    case 4:
                        if(fase == 2)
                        {
                            jump_distance += 1 * Time.deltaTime;
                            ani.SetBool("walk", false);
                            ani.SetBool("run", false);
                            ani.SetBool("attack", true);
                            ani.SetFloat("skill", 0);
                            hit_Select = 3;
                            rango.GetComponent<CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);


                        }
                        else
                        {
                            rutina = 0;
                            cronometro = 0;
                        }

                        break;
                }
            }


        }
    }



    public void Final_Ani()
    {
        rutina = 0;
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<CapsuleCollider>().enabled = true;
        lanza_llamas = false;
        jump_distance = 0;
        direction_skill = false;
    }

    public void Direction_Attack_Start()
    {
        direction_skill = true;
    }

    public void Direction_Attack_Final()
    {
        direction_skill = false;
    }

    public void ColliderWeaponTrue()
    {
        hit[hit_Select].GetComponent<SphereCollider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hit[hit_Select].GetComponent<SphereCollider>().enabled = false;
    }

    //lanzallama

    public GameObject GetBala()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(fire, cabeza.transform.position, cabeza.transform.rotation) as GameObject;
        pool.Add(obj);
        return obj;
    }


    public void LanzaLlamas_Skill()
    {
        cronometro2 += 1 * Time.deltaTime;
        if(cronometro2 > 0.1f)
        {
            GameObject obj = GetBala();
            obj.transform.position = cabeza.transform.position;
            obj.transform.rotation = cabeza.transform.rotation;
            cronometro2 = 0;
        }
    }

    public void Start_Fire()
    {
        lanza_llamas = true;
    }

    public void Stop_Fire()
    {
        lanza_llamas = false;
    }


}
