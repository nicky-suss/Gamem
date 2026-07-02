#pragma once
#include <algorithm>
#include <cmath>
#include <random>

class MathGm {
public:
  MathGm() = delete;

  static inline std::mt19937 &get_random_method() {
    thread_local std::mt19937 engine(std::random_device{}());
    return engine;
  }
  static inline double SmoothStep(double start, double end, double t) {
    double c = std::clamp(t, 0.0, 1.0);
    double tt = c * c * (3.0 - 2.0 * c);
    return start + (end - start) * tt;
  }
  static inline float SmoothStep(float start, float end, float t) {
    float c = std::clamp(t, 0.0f, 1.0f);
    float tt = c * c * (3.0f - 2.0f * c);
    return start + (end - start) * tt;
  }

  static inline double RandomRange(double min, double max) {
    if (min > max) {
      std::swap(min, max);
    }
    thread_local std::uniform_real_distribution<double> dist(0.0, 1.0);
    double randomF = dist(get_random_method());
    return min + (randomF * (max - min));
  }
  static inline float RandomRange(float min, float max) {
    if (min > max) {
      std::swap(min, max);
    }
    thread_local std::uniform_real_distribution<float> dist(0.0f, 1.0f);
    double randomF = dist(get_random_method());
    return min + (randomF * (max - min));
  }

  static inline double Lerp(double start, double end, double t) {
    return start + (end - start) * std::clamp(t, 0.0, 1.0);
  }
  static inline float Lerp(float start, float end, float t) {
    return start + (end - start) * std::clamp(t, 0.0f, 1.0f);
  }

  static inline double LerpUnclamped(double start, double end, double t) {
    return start + (end - start) * t;
  }
  static inline float LerpUnclamped(float start, float end, float t) {
    return start + (end - start) * t;
  }

  static inline double InverseLerp(double value, double start, double end) {
    if (std::fabs(end - start) <= 1e-5) {
      return 0.0;
    }
    return std::clamp((value - start) / (end - start), 0.0, 1.0);
  }
  static inline float InverseLerp(float value, float start, float end) {
    if (std::fabs(end - start) <= 1e-5f) {
      return 0.0;
    }
    return std::clamp((value - start) / (end - start), 0.0f, 1.0f);
  }

  static inline double Accelerate(double Vcurrent, double Vtarget, double a, double t) {
    return Vcurrent + (Vtarget - Vcurrent) * (a * t);
  }
  static inline float Accelerate(float Vcurrent, float Vtarget, float a, float t) {
    return Vcurrent + (Vtarget - Vcurrent) * (a * t);
  }

  static inline double Map(double toMin, double v, double fromMin, double toMax, double fromMax) {
    if (std::fabs(fromMax - fromMin) <= 1e-5) {
      return 0.0;
    }
    return toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
  }
  static inline float Map(float toMin, float v, float fromMin, float toMax, float fromMax) {
    if (std::fabs(fromMax - fromMin) <= 1e-5f) {
      return 0.0f;
    }
    return toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
  }

  static inline double Remap(double toMin, double v, double fromMin,  double toMax, double fromMax) {
    return MathGm::Map(toMin, v, fromMin, toMax, fromMax);
  }
  static inline float Remap(float toMin, float v, float fromMin, float toMax, float fromMax) {
    return MathGm::Map(toMin, v, fromMin, toMax, fromMax);
  }

  static inline bool RollChance(int chance) {
    thread_local std::uniform_int_distribution<int> dist(0, 99);
    return dist(get_random_method()) < std::clamp(chance, 0, 100);
  }

  static inline bool RollChance(double chance) {
    thread_local std::uniform_real_distribution<double> dist(0.0, 1.0);
    return dist(get_random_method()) * 100.0 < std::clamp(chance, 0.0, 100.0);
  }

  static inline bool RollChance(float chance) {
    thread_local std::uniform_real_distribution<float> dist(0.0f, 1.0f);
    return dist(get_random_method()) * 100.0f < std::clamp(chance, 0.0f, 100.0f);
  }

  static inline float MoveTowards(float current, float target, float speed, float dt) {
    if (std::fabs(target - current) <= speed * dt)
      return target;
    return current + std::copysign(1.0f, target - current) * speed * dt;
  }

  static inline double MoveTowards(double current, double target, double speed, double dt) {
    if (std::fabs(target - current) <= speed * dt)
      return target;
    return current + std::copysign(1.0, target - current) * speed * dt;
  }

  static inline float SafeDivide(float a, float b) {
    return std::fabs(b) < 1e-5f ? 0.0f : a / b;
  }

  static inline double SafeDivide(double a, double b) {
    return std::fabs(b) < 1e-5 ? 0.0 : a / b;
  }

  static inline float SafeDivide(float a, float b, float fallback) {
    return std::fabs(b) < 1e-5f ? fallback : a / b;
  }

  static inline double SafeDivide(double a, double b, double fallback) {
    return std::fabs(b) < 1e-5 ? fallback : a / b;
  }

  static inline int SafeDivide(int a, int b, int fallback = 0) {
    return b == 0 ? fallback : a / b;
  }

  static inline bool Approximately(float a, float b) {
    float eps = 1e-5f;
    float diff = std::fabs(a - b);
    if (diff <= eps)
      return true;
    return diff <= std::max(std::fabs(a), std::fabs(b)) * eps;
  }

  static inline bool Approximately(double a, double b) {
    double eps = 1e-5;
    double diff = std::fabs(a - b);
    if (diff <= eps)
      return true;
    return diff <= std::max(std::fabs(a), std::fabs(b)) * eps;
  }

  static inline float SmoothDamp(float current, float target, float &currentVelocity, float smoothTime, float maxSpeed, float deltaTime) {
    smoothTime = std::max(0.0001f, smoothTime);

    float omega = 2.0f / smoothTime;
    float x = omega * deltaTime;
    float denominator = 1.0f + x + 0.48f * (x * x) + 0.235f * (x * x * x);
    float exp = 1.0f / denominator;

    float change = current - target;
    float maxChange = maxSpeed * smoothTime;
    change = std::clamp(change, -maxChange, maxChange);
    float targetReal = current - change;

    float temp = (currentVelocity + omega * change) * deltaTime;
    currentVelocity = (currentVelocity - omega * temp) * exp;
    float result = targetReal + (change + temp) * exp;

    if (target - current > 0.0f && result > target) {
      currentVelocity = 0.0f;
      return target;
    }
    if (target - current < 0.0f && result < target) {
      currentVelocity = 0.0f;
      return target;
    }
    return result;
  }

  static inline double SmoothDamp(double current, double target, double &currentVelocity, double smoothTime, double maxSpeed, double deltaTime) {
    smoothTime = std::max(0.0001, smoothTime);

    double omega = 2.0 / smoothTime;
    double x = omega * deltaTime;
    double denominator = 1.0 + x + 0.48 * (x * x) + 0.235 * (x * x * x);
    double exp = 1.0 / denominator;

    double change = current - target;
    double maxChange = maxSpeed * smoothTime;
    change = std::clamp(change, -maxChange, maxChange);
    double targetReal = current - change;

    double temp = (currentVelocity + omega * change) * deltaTime;
    currentVelocity = (currentVelocity - omega * temp) * exp;
    double result = targetReal + (change + temp) * exp;

    if (target - current > 0.0 && result > target) {
      currentVelocity = 0.0;
      return target;
    }
    if (target - current < 0.0 && result < target) {
      currentVelocity = 0.0;
      return target;
    }
    return result;
  }

  static inline float SmoothDampAngle(float &current, float target, float &currentVelocity, float smoothTime, float deltaTime) {
    smoothTime = std::max(0.0001f, smoothTime);

    float w = 2.0f / smoothTime;
    float x = w * deltaTime;

    float F = 1.0f / (1.0f + x + 0.48f * (x * x) + 0.235f * (x * x * x));

    float deltaAngle = target - current;
    const float period = 360.0f;
    deltaAngle = std::fmod(std::fmod(deltaAngle, period) + 540.0f, period) - 180.0f;

    float temp = (currentVelocity + w * deltaAngle) * deltaTime;

    currentVelocity = (currentVelocity - w * temp) * F;

    float newAngle = (target - deltaAngle) + (deltaAngle + temp) * F;
    current = std::fmod(std::fmod(newAngle, period) + period, period);
    return current;
  }

  static inline double SmoothDampAngle(double &current, double target, double &currentVelocity, double smoothTime, double deltaTime) {
    smoothTime = std::max(0.0001, smoothTime);

    double w = 2.0 / smoothTime;
    double x = w * deltaTime;

    double F = 1.0 / (1.0 + x + 0.48 * (x * x) + 0.235 * (x * x * x));

    double deltaAngle = target - current;
    const double period = 360.0;
    deltaAngle = std::fmod(std::fmod(deltaAngle, period) + 540.0, period) - 180.0;

    double temp = (currentVelocity + w * deltaAngle) * deltaTime;

    currentVelocity = (currentVelocity - w * temp) * F;

    double newAngle = (target - deltaAngle) + (deltaAngle + temp) * F;
    current = std::fmod(std::fmod(newAngle, period) + period, period);
    return current;
  }
};