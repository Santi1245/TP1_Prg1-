using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour
{
    [SerializeField] private bool isEnabled = true;
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private float duracionEfecto = 3f;

    private PlayerMovement player; 
    private float velocidadOriginal;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        velocidadOriginal = player.speed;
    }

    void Update()
    {
        if (isEnabled == true && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        isEnabled = false;
        Debug.Log("<color=yellow>Poder habilitado</color>");

        player.speed = velocidadOriginal * 2f;
        Debug.Log("Activando poder especial");

        yield return new WaitForSeconds(duracionEfecto);

        player.speed = velocidadOriginal;

        yield return new WaitForSeconds(cooldown);

        isEnabled = true;
        Debug.Log("<color=red>Poder desabilitado</color>");
    }
}

