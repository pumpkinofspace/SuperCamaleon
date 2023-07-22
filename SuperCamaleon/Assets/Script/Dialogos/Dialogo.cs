using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject marcaDeDialogo;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo; 
    [SerializeField, TextArea(4, 6)] private string[] lineasDialogo;

    private bool playerEstaCercas;
    private bool dialogoEstado;
    private int lineaIndex;

    public float tiempoEscritura = 0.05f;
    // Update is called once per frame
    void Update()
    {
        if(playerEstaCercas && Input.GetButtonDown("Fire1"))
        {
            if (!dialogoEstado)
            {
                StartDialogo();
            }else if (textoDialogo.text == lineasDialogo[lineaIndex])
            {
                NextDialogo();
            }
           
        }
    }

    private void StartDialogo()
    {
        dialogoEstado = true;
        marcaDeDialogo.SetActive(false);
        panelDialogo.SetActive(true);
        lineaIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogo()
    {
        lineaIndex++;
        if(lineaIndex < lineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogoEstado = false;
            panelDialogo.SetActive(false);
            marcaDeDialogo.SetActive(true);

        }
    }

    private IEnumerator ShowLine()
    {
        textoDialogo.text = string.Empty;

        foreach(char ch in lineasDialogo[lineaIndex])
        {
            textoDialogo.text += ch;
            yield return new WaitForSeconds(tiempoEscritura);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            marcaDeDialogo.SetActive(true);
            playerEstaCercas = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            marcaDeDialogo.SetActive(false);
            playerEstaCercas = false;
        }
        
    }
}
