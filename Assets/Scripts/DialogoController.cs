using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoController : MonoBehaviour
{
    public GameObject panel;

    public string[] dialogo1;
    public string[] dialogo2;
    public string[] dialogo3;

    public TMP_Text txtDialogo;
    public bool dialogoActive;

    Coroutine auxCoroutine;

    public void AbrirDialogo(int valor)
    {
        if (dialogoActive)
        {
            CerrarDialogo();
            StartCoroutine(esperaSolapacionDialogo(valor));
        }
        else
        {
            dialogoActive = false;
            auxCoroutine = StartCoroutine(mostrarDialogo(valor));

        }
    }


    IEnumerator mostrarDialogo(int valor, float time = 0.1f)
    {
        panel.SetActive(true);
        string[] dialogo;
        if (valor == 0) dialogo = dialogo1;
        else if (valor == 1) dialogo = dialogo2;
        else dialogo = dialogo3;

        int total = dialogo.Length;
        string res = "";
        dialogoActive = true;
        yield return null;
        for (int i = 0; i < total; i++)
        {

            res = "";
            if (dialogoActive)
            {
                for (int s = 0; s < dialogo[i].Length; s++)
                {
                    if (dialogoActive)
                    {
                        res = string.Concat(res, dialogo[i][s]);
                        txtDialogo.text = res;
                        yield return new WaitForSeconds(time);
                    }
                    else yield break;
                }
                yield return new WaitForSeconds(0.4f);
            }
            else yield break ;


        }
        yield return new WaitForSeconds(0.4f);
        CerrarDialogo();

    }


    IEnumerator esperaSolapacionDialogo(int valor)
    {
        yield return new WaitForEndOfFrame();
    
        auxCoroutine = StartCoroutine(mostrarDialogo(valor));
    }

    public void CerrarDialogo()
    {
        dialogoActive = false;
        if (auxCoroutine != null)
        {
            StopCoroutine(auxCoroutine);
            auxCoroutine = null;
        }

        txtDialogo.text = "";
        panel.SetActive(false);
    }
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AbrirDialogo(0);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            AbrirDialogo(1);

        }
    }
}
