using UnityEngine;
using TMPro;
using System.Diagnostics;

public class PerformanceMonitor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI performanceText;

    private float deltaTime = 0.0f;
    private int frameCount = 0; 
    private float timeElapsed = 0.0f;
    private float totalTime = 0.0f;
    private int totalFrames = 0;

    private Stopwatch stopwatch;

    // Start is called before the first frame update
    void Start()
    {
        stopwatch = new Stopwatch();    
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.unscaledDeltaTime;
        timeElapsed += Time.unscaledDeltaTime;
        frameCount++;
        totalFrames++;

        if (deltaTime >= 1.0f)
        {
            float fps = frameCount / deltaTime;
            float avgFps = totalFrames / totalTime;

            long memoryUsed = System.GC.GetTotalMemory(false);

            float cpuFrameTime = Time.deltaTime * 1000f;
            float gpuFrameTime = Time.unscaledDeltaTime * 1000f;

            performanceText.text =
            $"FPS: {fps:F2} \nAvg FPS: {avgFps:F2}\n" +
            $"CPU Frame Time: {cpuFrameTime:F2} ms \nGPU Frame Time: {gpuFrameTime:F2} ms\n" +
            $"Memory: {memoryUsed / (1024f * 1024f):F2} MB";

            deltaTime = 0.0f;
            frameCount = 0;
        }

        totalTime += Time.unscaledDeltaTime;
    }

    public void BenchMarkMethod()
    {
        UnityEngine.Debug.Log("Starting benchmark...");
        stopwatch.Reset();
        stopwatch.Start();

        PerformHeavyCalculation();

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Benchmark completed. Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    private void PerformHeavyCalculation()
    {
        int[] numbers = new int[10000000];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Range(0, 10000);

            if (i % 100000  == 0)
            {
                UnityEngine.Debug.Log($"Processing...{i} iterations completed");
            }
        }

        System.Array.Sort(numbers);
        UnityEngine.Debug.Log("Sorting completed");
    }
}
