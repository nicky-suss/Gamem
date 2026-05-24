namespace Gamem;

public static class MathGamem
{
    public static double SmoothStep(double start, double end, double t)
    {
        double c = Math.Clamp(t, 0.0, 1.0);
        double T = c * c * (3.0 - 2.0 * c);
        return start + (end - start) * T;
    }
    public static float SmoothStep(float start, float end, float t)
    {
        float c = Math.Clamp(t, 0.0f, 1.0f);
        float T = c * c * (3.0f - 2.0f * c);
        return start + (end - start) * T;
    }
    public static double RandomRange(double min, double max)
    {
        if (min > max)
            throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
        return min + (Random.Shared.NextDouble() * (max - min));
    }
    public static float RandomRange(float min, float max)
    {
        if (min > max)
            throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
        return min + (Random.Shared.NextSingle() * (max - min));
    }
}