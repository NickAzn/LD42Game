using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    //Causes object to shake
    public IEnumerator StartShake(float duration, float magnitude) {
        Vector3 originalPos = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude + originalPos.x;
            float y = Random.Range(-1f, 1f) * magnitude + originalPos.y;
            transform.localPosition = new Vector3(x, y, originalPos.z);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
