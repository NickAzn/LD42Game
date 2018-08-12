using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public bool shaking = false;

    //Causes object to shake
    public IEnumerator StartShake(float duration, float magnitude) {
        shaking = true;
        Vector3 originalPos = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude + originalPos.x;
            float y = Random.Range(-1f, 1f) * magnitude + originalPos.y;
            transform.localPosition = new Vector3(x, y, originalPos.z);

            timeElapsed += Time.unscaledDeltaTime;

            yield return null;
        }
        shaking = false;

        transform.localPosition = originalPos;
    }
}
