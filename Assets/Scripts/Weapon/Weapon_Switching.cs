using UnityEngine;

public class Weapon_Switching : MonoBehaviour
{
    public int selected_weapon = 0; 

    // Start is called before the first frame update
    void Start()
    {
        Selecte_Weapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previous_selected_weapon = selected_weapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selected_weapon >= transform.childCount - 1)
                selected_weapon = 0;
            else
                selected_weapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selected_weapon <= 0)
                selected_weapon = transform.childCount - 1;
            else
                selected_weapon--;
        }

        if (previous_selected_weapon != selected_weapon)
        {
            Selecte_Weapon();
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            selected_weapon = 1;
            Selecte_Weapon();
        }


        if (Input.GetKey(KeyCode.Alpha2))
        {
            selected_weapon = 2;
            Selecte_Weapon();
        }


        if (Input.GetKey(KeyCode.Alpha3))
        {
            selected_weapon = 0;
            Selecte_Weapon();
        }


        if (Input.GetKey(KeyCode.Alpha4))
        {
            selected_weapon = 3;
            Selecte_Weapon();
        }
    }

    void Selecte_Weapon()
    {
        int i = 0; 
        foreach (Transform weapon in transform)
        { 
            if (i == selected_weapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
