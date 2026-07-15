#include "../include/MathGm.hpp"
#include <emscripten/em_macros.h>
#include <emscripten/emscripten.h>

extern "C" {
EMSCRIPTEN_KEEPALIVE
double gamem_smooth_step(double start, double end, double t) {
  return MathGm::SmoothStep(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_smooth_step_f(float start, float end, float t) {
  return MathGm::SmoothStep(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
double gamem_random_range(double min, double max) {
  return MathGm::RandomRange(min, max);
}
EMSCRIPTEN_KEEPALIVE
float gamem_random_range_f(float min, float max) {
  return MathGm::RandomRange(min, max);
}
EMSCRIPTEN_KEEPALIVE
double gamem_lerp(double start, double end, double t) {
  return MathGm::Lerp(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_lerp_f(float start, float end, float t) {
  return MathGm::Lerp(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
double gamem_lerp_unclamped(double start, double end, double t) {
  return MathGm::LerpUnclamped(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_lerp_unclamped_f(float start, float end, float t) {
  return MathGm::LerpUnclamped(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
double gamem_inverse_lerp(double value, double start, double end) {
  return MathGm::InverseLerp(value, start, end);
}
EMSCRIPTEN_KEEPALIVE
float gamem_inverse_lerp_f(float value, float start, float end) {
  return MathGm::InverseLerp(value, start, end);
}
EMSCRIPTEN_KEEPALIVE
double gamem_accelerate(double Vcurrent, double Vtarget, double a, double t) {
  return MathGm::Accelerate(Vcurrent, Vtarget, a, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_accelerate_f(float Vcurrent, float Vtarget, float a, float t) {
  return MathGm::Accelerate(Vcurrent, Vtarget, a, t);
}
EMSCRIPTEN_KEEPALIVE
double gamem_map(double toMin, double v, double fromMin, double toMax, double fromMax) {
  return MathGm::Map(toMin, v, fromMin, toMax, fromMax);
}
EMSCRIPTEN_KEEPALIVE
float gamem_map_f(float toMin, float v, float fromMin, float toMax, float fromMax) {
  return MathGm::Map(toMin, v, fromMin, toMax, fromMax);
}
EMSCRIPTEN_KEEPALIVE
double gamem_remap(double toMin, double v, double fromMin, double toMax, double fromMax) {
  return MathGm::Remap(toMin, v, fromMin, toMax, fromMax);
}
EMSCRIPTEN_KEEPALIVE
float gamem_remap_f(float toMin, float v, float fromMin, float toMax, float fromMax) {
  return MathGm::Remap(toMin, v, fromMin, toMax, fromMax);
}
EMSCRIPTEN_KEEPALIVE
int gamem_roll_chance(int chance) {
  return MathGm::RollChance(chance);
}
EMSCRIPTEN_KEEPALIVE
double gamem_roll_chance_d(double chance) {
  return MathGm::RollChance(chance);
}
EMSCRIPTEN_KEEPALIVE
float gamem_roll_chance_f(float chance) {
  return MathGm::RollChance(chance);
}
EMSCRIPTEN_KEEPALIVE
double gamem_move_towards(double current, double target, double speed, double dt) {
  return MathGm::MoveTowards(current, target, speed, dt);
}
EMSCRIPTEN_KEEPALIVE
double gamem_move_towards_f(float current, float target, float speed, float dt) {
  return MathGm::MoveTowards(current, target, speed, dt);
}
EMSCRIPTEN_KEEPALIVE
double gamem_safe_divide(double a, double b) {
  return MathGm::SafeDivide(a, b);
}
EMSCRIPTEN_KEEPALIVE
float gamem_safe_divide_f(float a, float b) {
  return MathGm::SafeDivide(a, b);
}
EMSCRIPTEN_KEEPALIVE
double gamem_safe_divide_fb(double a, double b, double fallback) {
  return MathGm::SafeDivide(a, b, fallback);
}
EMSCRIPTEN_KEEPALIVE
float gamem_safe_divide_f_fb(float a, float b, float fallback) {
  return MathGm::SafeDivide(a, b, fallback);
}
EMSCRIPTEN_KEEPALIVE
int gamem_safe_divide_i_fb(int a, int b, int fallback) {
  return MathGm::SafeDivide(a, b, fallback);
}
EMSCRIPTEN_KEEPALIVE
bool gamem_approximately(double a, double b) {
  return MathGm::Approximately(a, b);
}
EMSCRIPTEN_KEEPALIVE
bool gamem_approximately_f(float a, float b) {
  return MathGm::Approximately(a, b);
}
EMSCRIPTEN_KEEPALIVE
double gamem_smooth_damp(double current, double target, double* currentVelocity, double smoothTime, double maxSpeed, double deltaTime) {
  return MathGm::SmoothDamp(current, target, *currentVelocity, smoothTime, maxSpeed, deltaTime);
}
EMSCRIPTEN_KEEPALIVE
double gamem_smooth_damp_f(float current, float target, float* currentVelocity, float smoothTime, float maxSpeed, float deltaTime) {
  return MathGm::SmoothDamp(current, target, *currentVelocity, smoothTime, maxSpeed, deltaTime);
}
EMSCRIPTEN_KEEPALIVE
double gamem_smooth_damp_angle(double* current, double target, double* currentVelocity, double smoothTime, double deltaTime) {
  return MathGm::SmoothDampAngle(*current, target, *currentVelocity, smoothTime, deltaTime);
}
EMSCRIPTEN_KEEPALIVE
float gamem_smooth_damp_angle_f(float* current, float target, float* currentVelocity, float smoothTime, float deltaTime) {
  return MathGm::SmoothDampAngle(*current, target, *currentVelocity, smoothTime, deltaTime);
}
EMSCRIPTEN_KEEPALIVE
double gamem_ping_pong(double t, double length) {
  return MathGm::PingPong(t, length);
}
EMSCRIPTEN_KEEPALIVE
double gamem_lerp_angle(double start, double end, double t) {
  return MathGm::LerpAngle(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_lerp_angle_f(float start, float end, float t) {
  return MathGm::LerpAngle(start, end, t);
}
EMSCRIPTEN_KEEPALIVE
double gamem_repeat(double t, double length) {
  return MathGm::Repeat(t, length);
}
EMSCRIPTEN_KEEPALIVE
float gamem_repeat_f(float t, float length) {
  return MathGm::Repeat(t, length);
}
}