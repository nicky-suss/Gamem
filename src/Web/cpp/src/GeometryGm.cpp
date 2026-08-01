#include "../include/GeometryGm.hpp"
#include <emscripten/em_macros.h>
#include <emscripten/emscripten.h>

extern "C" {

EMSCRIPTEN_KEEPALIVE
double gamem_getdotproduct(double x1, double y1, double x2, double y2) {
    return GeometryGm::GetDotProduct(x1, y1, x2, y2);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getdotproduct_f(float x1, float y1, float x2, float y2) {
    return GeometryGm::GetDotProduct(x1, y1, x2, y2);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getdotproduct3d(double x1, double y1, double z1, double x2, double y2, double z2) {
    return GeometryGm::GetDotProduct3D(x1, y1, z1, x2, y2, z2);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getdotproduct3d_f(float x1, float y1, float z1, float x2, float y2, float z2) {
    return GeometryGm::GetDotProduct3D(x1, y1, z1, x2, y2, z2);
}

EMSCRIPTEN_KEEPALIVE
void gamem_reflect(double x, double y, double normalX, double normalY, double* outX, double* outY) {
    auto result = GeometryGm::Reflect(x, y, normalX, normalY);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
}

EMSCRIPTEN_KEEPALIVE
void gamem_reflect_f(float x, float y, float normalX, float normalY, float* outX, float* outY) {
    auto result = GeometryGm::Reflect(x, y, normalX, normalY);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
}

EMSCRIPTEN_KEEPALIVE
void gamem_reflect3d(double x, double y, double z, double normalX, double normalY, double normalZ, double* outX, double* outY, double* outZ) {
    auto result = GeometryGm::Reflect3D(x, y, z, normalX, normalY, normalZ);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
    *outZ = std::get<2>(result);
}

EMSCRIPTEN_KEEPALIVE
void gamem_reflect3d_f(float x, float y, float z, float normalX, float normalY, float normalZ, float* outX, float* outY, float* outZ) {
    auto result = GeometryGm::Reflect3D(x, y, z, normalX, normalY, normalZ);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
    *outZ = std::get<2>(result);
}

EMSCRIPTEN_KEEPALIVE
double gamem_toradians(double degrees) {
    return GeometryGm::ToRadians(degrees);
}

EMSCRIPTEN_KEEPALIVE
float gamem_toradians_f(float degrees) {
    return GeometryGm::ToRadians(degrees);
}

EMSCRIPTEN_KEEPALIVE
double gamem_todegrees(double radians) {
    return GeometryGm::ToDegrees(radians);
}

EMSCRIPTEN_KEEPALIVE
float gamem_todegrees_f(float radians) {
    return GeometryGm::ToDegrees(radians);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getdistance(double x1, double y1, double x2, double y2) {
    return GeometryGm::GetDistance(x1, y1, x2, y2);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getdistance_f(float x1, float y1, float x2, float y2) {
    return GeometryGm::GetDistance(x1, y1, x2, y2);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getdistancesquared(double x1, double y1, double x2, double y2) {
    return GeometryGm::GetDistanceSquared(x1, y1, x2, y2);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getdistancesquared_f(float x1, float y1, float x2, float y2) {
    return GeometryGm::GetDistanceSquared(x1, y1, x2, y2);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getdistance3d(double x1, double y1, double z1, double x2, double y2, double z2) {
    return GeometryGm::GetDistance3D(x1, y1, z1, x2, y2, z2);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getdistance3d_f(float x1, float y1, float z1, float x2, float y2, float z2) {
    return GeometryGm::GetDistance3D(x1, y1, z1, x2, y2, z2);
}

EMSCRIPTEN_KEEPALIVE
bool gamem_checkcirclevscircle(double x1, double y1, double radius1, double x2, double y2, double radius2) {
    return GeometryGm::CheckCircleVsCircle(x1, y1, radius1, x2, y2, radius2);
}

EMSCRIPTEN_KEEPALIVE
bool gamem_checkcirclevscircle_f(float x1, float y1, float radius1, float x2, float y2, float radius2) {
    return GeometryGm::CheckCircleVsCircle(x1, y1, radius1, x2, y2, radius2);
}

EMSCRIPTEN_KEEPALIVE
bool gamem_checkaabbvsaabb(double x1, double y1, double width1, double height1, double x2, double y2, double width2, double height2) {
    return GeometryGm::CheckAABBVsAABB(x1, y1, width1, height1, x2, y2, width2, height2);
}

EMSCRIPTEN_KEEPALIVE
bool gamem_checkaabbvsaabb_f(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2) {
    return GeometryGm::CheckAABBVsAABB(x1, y1, width1, height1, x2, y2, width2, height2);
}

EMSCRIPTEN_KEEPALIVE
bool gamem_checkcirclevsaabb(double circleX, double circleY, double radius, double aabbX, double aabbY, double width, double height) {
    return GeometryGm::CheckCircleVsAABB(circleX, circleY, radius, aabbX, aabbY, width, height);
}

EMSCRIPTEN_KEEPALIVE
bool gamem_checkcirclevsaabb_f(float circleX, float circleY, float radius, float aabbX, float aabbY, float width, float height) {
    return GeometryGm::CheckCircleVsAABB(circleX, circleY, radius, aabbX, aabbY, width, height);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getmagnitude(double x, double y) {
    return GeometryGm::GetMagnitude(x, y);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getmagnitude_f(float x, float y) {
    return GeometryGm::GetMagnitude(x, y);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getmagnitude3d(double x, double y, double z) {
    return GeometryGm::GetMagnitude3D(x, y, z);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getmagnitude3d_f(float x, float y, float z) {
    return GeometryGm::GetMagnitude3D(x, y, z);
}

EMSCRIPTEN_KEEPALIVE
void gamem_getcrossproduct(double x1, double y1, double z1, double x2, double y2, double z2, double* outX, double* outY, double* outZ) {
    auto result = GeometryGm::GetCrossProduct(x1, y1, z1, x2, y2, z2);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
    *outZ = std::get<2>(result);
}

EMSCRIPTEN_KEEPALIVE
void gamem_getcrossproduct_f(float x1, float y1, float z1, float x2, float y2, float z2, float* outX, float* outY, float* outZ) {
    auto result = GeometryGm::GetCrossProduct(x1, y1, z1, x2, y2, z2);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
    *outZ = std::get<2>(result);
}

EMSCRIPTEN_KEEPALIVE
double gamem_getanglebetween(double dotProduct, double lengthA, double lengthB) {
    return GeometryGm::GetAngleBetween(dotProduct, lengthA, lengthB);
}

EMSCRIPTEN_KEEPALIVE
float gamem_getanglebetween_f(float dotProduct, float lengthA, float lengthB) {
    return GeometryGm::GetAngleBetween(dotProduct, lengthA, lengthB);
}
EMSCRIPTEN_KEEPALIVE
double gamem_normalizeangle(double angle) {
    return GeometryGm::NormalizeAngle(angle);
}
EMSCRIPTEN_KEEPALIVE
float gamem_normalizeangle_f(float angle) {
    return GeometryGm::NormalizeAngle(angle);
}
}