using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BombPlace : MonoBehaviour
{   
    public float bombExplodeTime = 3f;
    public int bombAmount = 1;
    public int bombLeft;
    public KeyCode key = KeyCode.Space;
    public GameObject bombPrefab;

    public Explosion explosionPrefab;

    public float explosionTime = 1f;
    public int explosionRange = 1;
    public LayerMask explosionLayerMask;
    private void OnEnable() {
        bombLeft = bombAmount;
    }

    private void Update() {
        if (Input.GetKeyDown(key) && bombLeft > 0) {
            bombLeft--;
            StartCoroutine(Place());
        }
    }
    private IEnumerator Place() {
        Vector2 place;
        place.x = -0.42f;
        place.y = 0.63f;
        GameObject bomb = Instantiate(bombPrefab, place, Quaternion.identity);
        bombLeft--;
        yield return new WaitForSeconds(bombExplodeTime);

        place = bomb.transform.position;
        Explosion explosion = Instantiate(explosionPrefab, place, Quaternion.identity);
        explosion.enableAnimation(explosion.mot);
        Destroy(explosion.gameObject, explosionTime);

        Explode(place, Vector2.up, explosionRange);
        Explode(place, Vector2.down, explosionRange);
        Explode(place, Vector2.left, explosionRange);
        Explode(place, Vector2.right, explosionRange);
        Destroy(bomb);
    }

    private void Explode(Vector2 place, Vector2 dir, int range) {
        Vector2 pos;
        pos.x = place.x;
        pos.y = place.y;
        for (int i = 1; i <= range; i++) {
            pos.x = place.x + dir.x * i;
            pos.y = place.y + dir.y * i;
            if (Physics2D.OverlapBox(pos, Vector2.one / 2f, 0f, explosionLayerMask)) {
                break;
            }
            Explosion explosion = Instantiate(explosionPrefab, pos, Quaternion.identity);
            if (i == range) {
                explosion.enableAnimation(explosion.ba);
            } else if (i < range && range != 1) {
                explosion.enableAnimation(explosion.hai);
            }
            explosion.SetDir(dir);
            Destroy(explosion.gameObject, explosionTime);
        }
    }
}
