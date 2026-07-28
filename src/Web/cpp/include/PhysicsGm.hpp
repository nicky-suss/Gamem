#pragma once
#include <algorithm>
#include <cmath>
#include <tuple>

class PhysicsGm {
public:
  PhysicsGm() = delete;

  static inline float ApplyGravity(float velocity, float gravity, float deltaTime) {
    return velocity + gravity * deltaTime;
  }

  static inline double ApplyGravity(double velocity, double gravity, double deltaTime) {
    return velocity + gravity * deltaTime;
  }

  static inline float ApplyFriction(float velocity, float frictionCoeff, float deltaTime) {
    if (std::fabs(velocity) <= 1e-6f)
      return 0.0f;
    float frictionCoeffAbs = std::fabs(frictionCoeff);
    float reduction = frictionCoeffAbs * std::fabs(deltaTime);
    if (std::fabs(velocity) <= reduction)
      return 0.0f;
    return velocity - std::copysign(1.0f, velocity) * reduction;
  }

  static inline double ApplyFriction(double velocity, double frictionCoeff, double deltaTime) {
    if (std::fabs(velocity) <= 1e-6)
      return 0.0;
    double frictionCoeffAbs = std::fabs(frictionCoeff);
    double reduction = frictionCoeffAbs * std::fabs(deltaTime);
    if (std::fabs(velocity) <= reduction)
      return 0.0;
    return velocity - std::copysign(1.0, velocity) * reduction;
  }

  static inline float MoveTowards(float current, float target, float maxDelta) {
    if (maxDelta <= 0.0f)
      return current;
    float dist = target - current;
    if (std::fabs(dist) <= maxDelta)
      return target;
    return current + std::copysign(1.0f, dist) * maxDelta;
  }

  static inline double MoveTowards(double current, double target, double maxDelta) {
    if (maxDelta <= 0.0)
      return current;
    double dist = target - current;
    if (std::fabs(dist) <= maxDelta)
      return target;
    return current + std::copysign(1.0, dist) * maxDelta;
  }

  static inline float Bounce(float vOld, float bounciness, float minBounceThreshold) {
    float vNew = -vOld * std::clamp(bounciness, 0.0f, 1.0f);
    if (std::fabs(vNew) < minBounceThreshold)
      vNew = 0.0f;
    return vNew;
  }

  static inline double Bounce(double vOld, double bounciness, double minBounceThreshold) {
    double vNew = -vOld * std::clamp(bounciness, 0.0, 1.0);
    if (std::fabs(vNew) < minBounceThreshold)
      vNew = 0.0;
    return vNew;
  }

  static inline float Bounce(float vOld, float bounciness) {
    return Bounce(vOld, bounciness, 0.1f);
  }

  static inline double Bounce(double vOld, double bounciness) {
    return Bounce(vOld, bounciness, 0.1);
  }

  static inline float ClampVelocity(float v, float max) {
    float limit = std::fabs(max);
    return std::clamp(v, -limit, limit);
  }

  static inline double ClampVelocity(double v, double max) {
    double limit = std::fabs(max);
    return std::clamp(v, -limit, limit);
  }

  static inline float AddForce(float v, float F, float t, float m) {
    return m <= 1e-6f ? v : v + (F * t / m);
  }

  static inline double AddForce(double v, double F, double t, double m) {
    return m <= 1e-6 ? v : v + (F * t / m);
  }

  static inline float AddImpulse(float vOld, float J, float m) {
    return m <= 1e-6f ? vOld : vOld + (J / m);
  }

  static inline double AddImpulse(double vOld, double J, double m) {
    return m <= 1e-6 ? vOld : vOld + (J / m);
  }

  static inline float JumpCut(float v, float multiplier) {
    return v > 0.0f ? v * multiplier : v;
  }

  static inline double JumpCut(double v, double multiplier) {
    return v > 0.0 ? v * multiplier : v;
  }

  static inline float TerminalVelocity(float v, float vlimit) {
    return v < -std::fabs(vlimit) ? -std::fabs(vlimit) : v;
  }

  static inline double TerminalVelocity(double v, double vlimit) {
    return v < -std::fabs(vlimit) ? -std::fabs(vlimit) : v;
  }
  static inline double CalculateJumpVelocity(double h, double g) {
    return std::sqrt(2.0 * std::abs(g) * h);
  }
  static inline float CalculateJumpVelocity(float h, float g) {
    return std::sqrt(2.0f * std::abs(g) * h);
  }
  static inline double GetStoppingDistance(double v, double a)
  {
   if (a <= 0.0)
      return 0.0;
   return (v * v) / (2.0 * a);
  }
  static inline float GetStoppingDistance(float v, float a)
  {
   if (a <= 0.0f)
      return 0.0f;
   return (v * v) / (2.0f * a);
  }
  static inline double ApplyQuadraticDrag(double v, double k, double t) {
    return v - (v * std::abs(v) * k * t);
  }
  static inline float ApplyQuadraticDrag(float v, float k, float t) {
    return v - (v * std::abs(v) * k * t);
  }
  static inline double CalculateLaunchVelocity(double target, double start, double g, double t)
  {
    if (t <= 0.0) return 0.0;
    return (target - start - (g * t * t) / 2.0) / t;
  }
  static inline float CalculateLaunchVelocity(float target, float start, float g, float t)
  {
    if (t <= 0.0f) return 0.0f;
    return (target - start - (g * t * t) / 2.0f) / t;
  }
  static inline std::tuple<float, float> PredictTrajectory(float startPosX, float startPosY, float startVelocityX, float startVelocityY, float gravityX, float gravityY, float t)
  {
    return std::make_tuple(startPosX + startVelocityX * t + 1.0f / 2.0f * gravityX * (t * t), startPosY + startVelocityY * t + 1.0f / 2.0f * gravityY * (t * t));
  }
};