using UnityEngine;

public class TestParticles : MonoBehaviour
{
    public ParticleSystem particulas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var emission = particulas.emission;
            var shape = particulas.shape;

            emission.rateOverTime = 50;
            shape.angle = 90;
        }
    }
}
