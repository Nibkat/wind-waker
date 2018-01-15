﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {
    private GameObject _player;
    public GameObject arrow;
    public GameObject currentArrow;
    private float _shotCharge;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if (Input.GetMouseButton(1)) {
            if(currentArrow == null) {
                InstantiateArrow();
            }

            Aim();

            if (Input.GetMouseButton(0)){
                ChargeShot();              
            }

            if (Input.GetMouseButtonUp(0)) {
                Shoot(_shotCharge * 200);
            }

            if (Input.GetMouseButtonDown(0)) {
                
            }
        }
    }

    private void Aim() {
        Vector3 aimPos = new Vector3(_player.transform.position.x + 1, _player.transform.position.y, _player.transform.position.z);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, aimPos, Time.deltaTime * 15);
    }

    private void Shoot(float power) {
        print("void shoot");
        currentArrow.GetComponent<Arrow>().AddVelocity(power);
        _shotCharge = 0f;
    }

    private void ChargeShot() {
        if (_shotCharge <= 1.5f) {
            print("charging");
            _shotCharge += 1 * Time.deltaTime;
        }

    }
    
    private void InstantiateArrow() {
        currentArrow = Instantiate(arrow, new Vector3(2.5f, 1, 1.5f), Quaternion.identity);
       
    }
}