using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private HudUI hudController;
    [SerializeField] private GameObject focus;
    [SerializeField] private GameObject charging;
    [SerializeField] private GameObject factory;
    [SerializeField] private GameObject garage;
    [SerializeField] private GameObject shop;
    [SerializeField] public Toggle pauseToggle;

    // Start is called before the first frame update
    private void Start()
    {
        pauseToggle.onValueChanged.AddListener((value) =>
        {
            Paused(value);
        });
    }

    // Update is called once per frame
    private void Update()
    {
        EscapePressed(Input.GetButtonDown("Cancel"));
    }

    public void Paused(bool isPressed)
    {
        Time.timeScale = isPressed ? 0f : 1;
        hudController.enabled = !isPressed;
        if (!(charging.activeSelf || factory.activeSelf || garage.activeSelf || shop.activeSelf))
        {
            focus.SetActive(isPressed);
        }
    }

    private void EscapePressed(bool isPressed)
    {
        if (isPressed)
        {
            if (charging.activeSelf)
            {
                charging.SetActive(false);
                focus.SetActive(false);
            }
            else if (factory.activeSelf)
            {
                factory.SetActive(false);
                focus.SetActive(false);
            }
            else if (garage.activeSelf)
            {
                garage.SetActive(false);
                focus.SetActive(false);
            }
            else if (shop.activeSelf)
            {
                shop.SetActive(false);
                focus.SetActive(false);
            }
            else
            {
                pauseToggle.isOn = !pauseToggle.isOn;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool collided = false;

        if (collision.gameObject.CompareTag("Charging"))
        {
            charging.SetActive(true);
            collided = true;
        }
        else if (collision.gameObject.CompareTag("Factory"))
        {
            factory.SetActive(true);
            collided = true;
        }
        else if (collision.gameObject.CompareTag("Garage"))
        {
            garage.SetActive(true);
            collided = true;
        }
        else if (collision.gameObject.CompareTag("Shop"))
        {
            shop.SetActive(true);
            collided = true;
        }
        if (collided)
        {
            focus.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bool collided = false;

        if (collision.gameObject.CompareTag("Charging"))
        {
            charging.SetActive(false);
            collided = true;
        }
        else if (collision.gameObject.CompareTag("Factory"))
        {
            factory.SetActive(false);
            collided = true;
        }
        else if (collision.gameObject.CompareTag("Garage"))
        {
            garage.SetActive(false);
            collided = true;
        }
        else if (collision.gameObject.CompareTag("Shop"))
        {
            shop.SetActive(false);
            collided = true;
        }
        if (collided)
        {
            focus.SetActive(false);
        }
    }
}
