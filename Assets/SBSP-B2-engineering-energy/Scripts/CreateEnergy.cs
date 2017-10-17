using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnergy : MonoBehaviour {

	public int time;
	public Energy energy;
	public Image inventory;
	public Image plasma;
	public Image reactor;
	public int numAlive;

	public ParticleSystem.Particle[] particles;
	public ParticleSystem partSys;

	void Update(){

		numAlive = partSys.GetParticles(particles);

		for( int i = 0; i < particles.Length; i++){
			particles[i].position = new Vector3( particles[i].position.x, particles[i].position.y, transform.parent.position.z - .001f);
		}

		partSys.SetParticles(particles, numAlive);

	}

	public void CheckType(string type){
		if (type == "bMatter") {
			time += 60;
		} else if (type == "plasma") {
			time += 30;
		} else if (type == "sun") {
			time += 120; 
		}
	}

}
