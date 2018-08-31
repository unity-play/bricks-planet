using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsField : MonoBehaviour
{
    private Transform thisTransform;
    private ParticleSystem.Particle[] points;
    private float starDistanceSqr;
    private float starClipDistanceSqr;

    public Color starColor;
    public int starMax = 600;
    public float starSize = 0.35f;
    public float starDistance = 60f;
    public float starClipDistance = 15f;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starMax];
        for (int i = 0; i < starMax; ++i)
        {
            points[i].position = Random.insideUnitSphere * starDistance + thisTransform.position;
            points[i].color = new Color(starColor.r, starColor.g, starColor.b, starColor.a);
            points[i].size = starSize;
        }
    }

    void Update()
    {
        if (points == null)
        {
            CreateStars();
        }

        for (int i = 0; i < starMax; ++i)
        {
            if ((points[i].position - thisTransform.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + thisTransform.position;
            }
            if ((points[i].position - thisTransform.position).sqrMagnitude <= starDistanceSqr)
            {
                float percentage = (points[i].position - thisTransform.position).sqrMagnitude / starClipDistanceSqr;
                points[i].color = new Color(1, 1, 1, percentage);
                points[i].size = percentage * starSize;
            }
        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
}
