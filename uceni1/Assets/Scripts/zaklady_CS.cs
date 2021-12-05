using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zaklady_CS : MonoBehaviour
{
    /* typy hodnot

    float speed = 1.4f;

    double mana = 15.4;

    int health = 100;

    string playerName = "Warrior";

    bool isDead = false;

    char oneChar =  'a';

    // write anything you want

   


    */

    Hrac warrior;
    Hrac archer;


    private void Start() // funkce bez parametru
    {

        /*  float a = 277;
          float b = 10;
          float c = a / b;


          print("");

          Debug.Log(a + " / " + b + " = " + c);
        
        float sum = VratDveCisla();
        Debug.Log("20 + 30 = " + sum);
        
        Debug.Log("Soucet je " + Vrat2Cisla(50, 81));

        funkce(30, 22);
    }

    void funkce(float a, float b) // funkce s parametry
    {

        Debug.Log("a + b = " + (a+b));
        

    }

    float VratDveCisla() // funkce ktera vraci vysledek (return)
    {
        return 20 + 30;
    }
    float Vrat2Cisla(float a, float b) // funkce ktera vraci vysledek a ma parametry
    {
        return a + b;
        

        float health = 50;
        float mana = 100;
        switch(health) // Switch funguje na podobnem principu jako if a else, ale nejdriv determinuju, co hledam v parametrech switch,
                       // a potom se ptam, jestli to tak je, nebo neni. pomoci break odejdu na dalsi case nebo default.
        {
            case 100:
                Debug.Log("Health is 100");
                break;
            case 50:
                Debug.Log("Health is 50");
                break;
            case 0:
                Debug.Log("Health is 0");
                break;
            default:
                Debug.Log("Health is neither of those values");
                break;
        }

        if (health <= 0 || health > 100) // nebo
        {
            // kod se aktivuje pokud je zdravi mene nez 0
        }
        else if (health < 50 && mana < 20) // zaroven
        {
            // neco jinyho
        }
        else
        {
            // neco uplne jinyho
        }

        // for a while loop (stejna funkcionalita)

        int iterationTime = 10;
        for(int i = 0; i < iterationTime; i++)
        {
            Debug.Log("Value of i: " + i);

        }
        
        int i = 0;
        while(i < 10)
        {
            Debug.Log("Value of i: " + i );
            i++;
        }
        

        StartCoroutine(ExecuteSomething(2));
        StartCoroutine("ExecuteSomething");
        StopCoroutine("ExecuteSomething");
    }   
    IEnumerator ExecuteSomething(float time)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("neco se vypise lol");

        yield return new WaitForSeconds(5f);

        // dalsi veci

        
    }

        */

        warrior = new Hrac(100, 50, 10, "jebe");
        archer = new Hrac(80, 30, 15, "rytmus");

        warrior.Info();
        archer.Info();

        warrior.Health = 54;

        /*
        warrior.SetHealth(12);
        warrior.GetHealth();
        */
        // rozdil mezi public a private - private uzamyka vsechny informace pouze do jedne funkce, public zpusobi, ze muzu informace pouzit v jinych funkcich, default je private
        // pouziva se napr. kdyz chci, aby mel lepsi hrac lepsi schopnosti, aby to nededily vsechny druhy postav
    } 
} //class
