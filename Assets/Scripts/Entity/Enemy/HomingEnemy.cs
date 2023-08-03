using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : IEnemy
{
    /*
     * Possible States:
     *      RotateToMove
     *      RotateToFire
     *      SetDistanceToMove
     *      Rotating
     *      Moving
     *      Firing
     */
    string State = "RotateToFire";
    int fromRotate = 0;     // State control for after "Rotating" - 0 goes to "Firing" while 1 goes to "SetDistanceToMove"

    float direction = 0;    // Used during "Rotating", where the ship will rotate while direction is not 0
    float distance = 0;     // Used during "Moving", where the ship moves a certain distance

    [SerializeField] float minMoveDist = 0f;
    [SerializeField] float maxMoveDist = 1f;

    [SerializeField] float rotSpeed = 1f;

    [SerializeField] bool debug = false;

    private void Update()
    {
        if (moveDown) return;   // Wait until done moving down.

        if (debug) DebugState(); 

        if (State == "Firing") Fire();
        else Move();
    }

    #region Movement

    // Handles state control for movement
    protected override void Move()
    {
        switch (State)
        {
            case "RotateToMove":
                RotateToMove();

                break;
            case "RotateToFire":
                RotateToFire();

                break;
            case "SetDistanceToMove":
                SetDistance();

                break;
            case "Rotating":
                Rotating();

                break;
            case "Moving":
                Moving();

                break;
        }
    }

    // Rotate to a random position
    void RotateToMove()
    {
        direction = Random.Range(-180, 180);

        State = "Rotating";
    }

    // Find angle that'll make the ship look at the player
    void RotateToFire()
    {
        Vector3 vecDirection = (playerTransform.position - transform.position).normalized;
        Vector3 curDirection = transform.rotation.eulerAngles;
        direction = Quaternion.Angle(Quaternion.Euler(vecDirection), Quaternion.Euler(curDirection));

        Instantiate(ammoPrefab, transform.position, Quaternion.Euler(vecDirection));
        Instantiate(ammoPrefab, transform.position, Quaternion.Euler(curDirection));
        Debug.Log(direction);

        State = "Rotating";
    }

    // Sets distance to move
    void SetDistance()
    {
        distance = Random.Range(minMoveDist, maxMoveDist);

        State = "Moving";
    }

    // Rotates the ship slightly
    void Rotating()
    {
        // Done Rotating
        if (direction == 0)
        {
            // Check where state needs to be after rotating
            if (fromRotate == 0) State = "Firing";
            else if (fromRotate == 1) State = "SetDistanceToMove";

            fromRotate = (fromRotate + 1) % 2;  // Make sure next Rotating has the proper fromRotate
            return;
        }

        // Find amount to rotate by this frame
        float rotationAmount = Mathf.Sign(direction) * Time.deltaTime * rotSpeed;
        if (Mathf.Abs(rotationAmount) > Mathf.Abs(direction)) rotationAmount = direction;

        transform.Rotate(transform.forward, rotationAmount);
        direction -= rotationAmount;
    }

    // Moves the ship slightly
    void Moving()
    {
        float toMove = speed * Time.deltaTime;

        if (toMove > distance)
        {
            // Done Moving
            transform.Translate(Vector3.up * -distance);
            distance = 0;

            State = "RotateToFire";
            return;
        }

        transform.Translate(Vector3.up * -toMove);
        distance -= toMove;
    }

    #endregion

    protected override void Fire()
    {
        base.Fire();

        State = "RotateToMove";
    }

    void DebugState()
    {
        if (State.Contains("Rotate")) Debug.Log(State);
        else if (State.Contains("Set")) Debug.Log(State);
    }
}
