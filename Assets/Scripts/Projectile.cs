using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Projectile : MonoBehaviour 
{
	
	public Vector3 targetPos;
	public float speed = 20f;
	public float arcHeight =  1;
	
	
	private Vector3 startPos;
    private ParabolaEquation parabolaEquation;
	
	void Start() 
    {
		startPos = transform.position;
        Vector3 highPoint = new Vector3((targetPos.x-startPos.x)/2+startPos.x, arcHeight, 1);
        parabolaEquation = new ParabolaEquation(startPos, highPoint, targetPos);
	}
	
	void Update() 
    {
        float currentX = transform.position.x;
        float xChange = calculateXChangeForConsistentMovement(currentX);
        float nextX = currentX + xChange * Time.deltaTime;
        Vector3 nextPos = new Vector3(nextX, parabolaEquation.calculate(nextX), transform.position.z);
		

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>(); 

        rigidBody.MovePosition(nextPos);
        rigidBody.MoveRotation(LookAt2D(nextPos - transform.position));
		transform.rotation = LookAt2D(nextPos - transform.position);
		transform.position = nextPos;
		
		if (nextPos == targetPos) Arrived();
	}
	
	void Arrived() {
		Destroy(gameObject);
	}
	
	/// 
	/// This is a 2D version of Quaternion.LookAt; it returns a quaternion
	/// that makes the local +X axis point in the given forward direction.
	/// 
	/// forward direction
	/// Quaternion that rotates +X to align with forward
	private static Quaternion LookAt2D(Vector2 forward) 
    {
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}

    // We want to move in a consistent speed, through the parabola, 
    //but we need to know how much movement does that mean, regarding x
    private float calculateXChangeForConsistentMovement(float x) 
    {
        return speed / (Mathf.Sqrt(Mathf.Pow(parabolaEquation.calculateDerivative(x), 2) + 1));
    }

    private class ParabolaEquation 
    {
        private Vector2 a;
        private Vector2 b;
        private Vector2 c;

        public ParabolaEquation(Vector2 a, Vector2 b, Vector2 c) 
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // A parabola is approximated with the 3 given points, with Lagrange interpolation
        public float calculate(float x) 
        {
            float partA = (a.y*(x-b.x)*(x-c.x))/((a.x-b.x)*(a.x-c.x));
            float partB = (b.y*(x-a.x)*(x-c.x))/((b.x-a.x)*(b.x-c.x));
            float partC = (c.y*(x-a.x)*(x-b.x))/((c.x-a.x)*(c.x-b.x));
            return partA + partB + partC;
        }

        // A rough approximation of Lagrange interpolation's derivative
        public float calculateDerivative(float x) 
        {
            return (calculate(x+0.001f) - calculate(x))/(0.001f);
        }
    }
}
