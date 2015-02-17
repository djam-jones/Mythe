using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    private Vector2 mousePos;

    void FixedUpdate() {
        UpdateRot();
    }

    void UpdateRot() {
        // Position of this object using Pixels
        Vector2 objPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = Input.mousePosition.x - objPos.x;
        mousePos.y = Input.mousePosition.y - objPos.y;

        float rot = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rot));
    }

}
