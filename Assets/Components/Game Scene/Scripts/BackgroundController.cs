﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float starPositionPaddingX;
    public float starPositionPaddingY;

    public int starsAmountAll = 20;
    public float starsAmountFarDispertion = 0.8f;

    public Camera cam;
    public Transform player;

    public GameObject starPrefab;
    public float parallaxEffectAmount;

    private List<GameObject> stars;
    
    void Start() {
        stars = new List<GameObject>();
        cam = Camera.main;

        spawnStars();
    }

    public void spawnStars () {
        for (int i = 0; i < starsAmountAll; i++) {

            GameObject star = Instantiate(starPrefab, Vector3.zero, Quaternion.identity);
            star.transform.position = generateStarPosition();


        }
    }

    public Vector2 generateStarPosition() {
        // vp = view port

        Vector2 vpLeftBottom = cam.ViewportToWorldPoint(new Vector3(cam.rect.x, cam.rect.y));
        Vector2 vpRightTop = cam.ViewportToWorldPoint(new Vector3(cam.rect.x + cam.rect.width, cam.rect.y + cam.rect.height));

        Vector2 newStarPostion = new Vector2(Random.Range(vpLeftBottom.x - starPositionPaddingX, vpRightTop.x + starPositionPaddingX), Random.Range(vpLeftBottom.y - starPositionPaddingY, vpRightTop.y + starPositionPaddingY));
        
        return newStarPostion;
    }

}