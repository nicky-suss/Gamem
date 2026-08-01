#pragma once
#include <algorithm>
#include <cmath>
#include <tuple>

class GeometryGm {
public:
  GeometryGm() = delete;

  static inline float GetDotProduct(float x1, float y1, float x2, float y2) {
    return (x1 * x2) + (y1 * y2);
  }

  static inline double GetDotProduct(double x1, double y1, double x2,double y2) {
    return (x1 * x2) + (y1 * y2);
  }

  static inline float GetDotProduct3D(float x1, float y1, float z1, float x2, float y2, float z2) {
    return (x1 * x2) + (y1 * y2) + (z1 * z2);
  }

  static inline double GetDotProduct3D(double x1, double y1, double z1, double x2, double y2, double z2) {
    return (x1 * x2) + (y1 * y2) + (z1 * z2);
  }

  static inline std::tuple<float, float> Reflect(float x, float y, float normalX, float normalY) {
    float dot = GetDotProduct(x, y, normalX, normalY);
    return std::make_tuple(x - 2.0f * dot * normalX, y - 2.0f * dot * normalY);
  }

  static inline std::tuple<double, double>
  Reflect(double x, double y, double normalX, double normalY) {
    double dot = GetDotProduct(x, y, normalX, normalY);
    return std::make_tuple(x - 2.0 * dot * normalX, y - 2.0 * dot * normalY);
  }

  static inline std::tuple<float, float, float>
  Reflect3D(float x, float y, float z, float normalX, float normalY, float normalZ) {
    float dot = GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
    return std::make_tuple(x - 2.0f * dot * normalX, y - 2.0f * dot * normalY, z - 2.0f * dot * normalZ);
  }

  static inline std::tuple<double, double, double>
  Reflect3D(double x, double y, double z, double normalX, double normalY, double normalZ) {
    double dot = GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
    return std::make_tuple(x - 2.0 * dot * normalX, y - 2.0 * dot * normalY, z - 2.0 * dot * normalZ);
  }

  static inline float ToRadians(float degrees) {
    constexpr float kPi = 3.14159265358979323846f;
    return degrees * (kPi / 180.0f);
  }

  static inline double ToRadians(double degrees) {
    constexpr double kPi = 3.14159265358979323846;
    return degrees * (kPi / 180.0);
  }

  static inline float ToDegrees(float radians) {
    constexpr float kPi = 3.14159265358979323846f;
    return radians * (180.0f / kPi);
  }

  static inline double ToDegrees(double radians) {
    constexpr double kPi = 3.14159265358979323846;
    return radians * (180.0 / kPi);
  }

  static inline float GetDistance(float x1, float y1, float x2, float y2) {
    float dx = x2 - x1;
    float dy = y2 - y1;
    return std::sqrt((dx * dx) + (dy * dy));
  }

  static inline double GetDistance(double x1, double y1, double x2, double y2) {
    double dx = x2 - x1;
    double dy = y2 - y1;
    return std::sqrt((dx * dx) + (dy * dy));
  }

  static inline float GetDistanceSquared(float x1, float y1, float x2, float y2) {
    float dx = x2 - x1;
    float dy = y2 - y1;
    return (dx * dx) + (dy * dy);
  }

  static inline double GetDistanceSquared(double x1, double y1, double x2, double y2) {
    double dx = x2 - x1;
    double dy = y2 - y1;
    return (dx * dx) + (dy * dy);
  }

  static inline float GetDistance3D(float x1, float y1, float z1, float x2, float y2, float z2) {
    float dx = x2 - x1;
    float dy = y2 - y1;
    float dz = z2 - z1;
    return std::sqrt((dx * dx) + (dy * dy) + (dz * dz));
  }

  static inline double GetDistance3D(double x1, double y1, double z1, double x2, double y2, double z2) {
    double dx = x2 - x1;
    double dy = y2 - y1;
    double dz = z2 - z1;
    return std::sqrt((dx * dx) + (dy * dy) + (dz * dz));
  }

  static inline bool CheckCircleVsCircle(float x1, float y1, float radius1, float x2, float y2, float radius2) {
    float sumRadius = radius1 + radius2;
    return GetDistanceSquared(x1, y1, x2, y2) <= (sumRadius * sumRadius);
  }

  static inline bool CheckCircleVsCircle(double x1, double y1, double radius1, double x2, double y2, double radius2) {
    double sumRadius = radius1 + radius2;
    return GetDistanceSquared(x1, y1, x2, y2) <= (sumRadius * sumRadius);
  }

  static inline bool CheckAABBVsAABB(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2) {
    return (x1 + width1) >= x2 && x1 <= (x2 + width2) && (y1 + height1) >= y2 && y1 <= (y2 + height2);
  }

  static inline bool CheckAABBVsAABB(double x1, double y1, double width1, double height1, double x2, double y2, double width2, double height2) {
    return (x1 + width1) >= x2 && x1 <= (x2 + width2) && (y1 + height1) >= y2 && y1 <= (y2 + height2);
  }

  static inline bool CheckCircleVsAABB(float circleX, float circleY, float radius, float aabbX, float aabbY, float width, float height) {
    float closestX = std::clamp(circleX, aabbX, aabbX + width);
    float closestY = std::clamp(circleY, aabbY, aabbY + height);
    float deltaX = circleX - closestX;
    float deltaY = circleY - closestY;
    float distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);
    return distanceSquare <= (radius * radius);
  }

  static inline bool CheckCircleVsAABB(double circleX, double circleY, double radius, double aabbX, double aabbY, double width, double height) {
    double closestX = std::clamp(circleX, aabbX, aabbX + width);
    double closestY = std::clamp(circleY, aabbY, aabbY + height);
    double deltaX = circleX - closestX;
    double deltaY = circleY - closestY;
    double distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);
    return distanceSquare <= (radius * radius);
  }

  static inline float GetMagnitude(float x, float y) {
    return std::sqrt((x * x) + (y * y));
  }

  static inline double GetMagnitude(double x, double y) {
    return std::sqrt((x * x) + (y * y));
  }

  static inline float GetMagnitude3D(float x, float y, float z) {
    return std::sqrt((x * x) + (y * y) + (z * z));
  }

  static inline double GetMagnitude3D(double x, double y, double z) {
    return std::sqrt((x * x) + (y * y) + (z * z));
  }

  static inline std::tuple<float, float, float>
  GetCrossProduct(float x1, float y1, float z1, float x2, float y2, float z2) {
    return std::make_tuple((y1 * z2) - (z1 * y2), (z1 * x2) - (x1 * z2), (x1 * y2) - (y1 * x2));
  }

  static inline std::tuple<double, double, double>
  GetCrossProduct(double x1, double y1, double z1, double x2, double y2, double z2) {
    return std::make_tuple((y1 * z2) - (z1 * y2), (z1 * x2) - (x1 * z2), (x1 * y2) - (y1 * x2));
  }

  static inline float GetAngleBetween(float dotProduct, float lengthA, float lengthB) {
    if (lengthA == 0.0f || std::isnan(lengthA) || lengthB == 0.0f || std::isnan(lengthB))
      return 0.0f;
    float A = dotProduct / (lengthA * lengthB);
    A = std::clamp(A, -1.0f, 1.0f);
    return std::acos(A);
  }

  static inline double GetAngleBetween(double dotProduct, double lengthA, double lengthB) {
    if (lengthA == 0.0 || std::isnan(lengthA) || lengthB == 0.0 || std::isnan(lengthB))
      return 0.0;
    double A = dotProduct / (lengthA * lengthB);
    A = std::clamp(A, -1.0, 1.0);
    return std::acos(A);
  }
  static inline double NormalizeAngle(double angle) {
    return std::fmod((std::fmod(angle, 360.0) + 360.0), 360.0);
  }
  static inline float NormalizeAngle(float angle) {
    return std::fmod((std::fmod(angle, 360.0f) + 360.0f), 360.0f);
  }
};