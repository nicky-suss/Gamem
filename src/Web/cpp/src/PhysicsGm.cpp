#include "../include/PhysicsGm.hpp"
#include <emscripten/em_macros.h>
#include <emscripten/emscripten.h>

extern "C" {

EMSCRIPTEN_KEEPALIVE
double gamem_applygravity(double velocity, double gravity, double deltaTime) {
    return PhysicsGm::ApplyGravity(velocity, gravity, deltaTime);
}

EMSCRIPTEN_KEEPALIVE
float gamem_applygravity_f(float velocity, float gravity, float deltaTime) {
    return PhysicsGm::ApplyGravity(velocity, gravity, deltaTime);
}

EMSCRIPTEN_KEEPALIVE
double gamem_applyfriction(double velocity, double frictionCoeff, double deltaTime) {
    return PhysicsGm::ApplyFriction(velocity, frictionCoeff, deltaTime);
}

EMSCRIPTEN_KEEPALIVE
float gamem_applyfriction_f(float velocity, float frictionCoeff, float deltaTime) {
    return PhysicsGm::ApplyFriction(velocity, frictionCoeff, deltaTime);
}

EMSCRIPTEN_KEEPALIVE
double gamem_movetowards(double current, double target, double maxDelta) {
    return PhysicsGm::MoveTowards(current, target, maxDelta);
}

EMSCRIPTEN_KEEPALIVE
float gamem_movetowards_f(float current, float target, float maxDelta) {
    return PhysicsGm::MoveTowards(current, target, maxDelta);
}

EMSCRIPTEN_KEEPALIVE
double gamem_bounce(double vOld, double bounciness) {
    return PhysicsGm::Bounce(vOld, bounciness);
}

EMSCRIPTEN_KEEPALIVE
float gamem_bounce_f(float vOld, float bounciness) {
    return PhysicsGm::Bounce(vOld, bounciness);
}

EMSCRIPTEN_KEEPALIVE
double gamem_bounce_threshold(double vOld, double bounciness, double minBounceThreshold) {
    return PhysicsGm::Bounce(vOld, bounciness, minBounceThreshold);
}

EMSCRIPTEN_KEEPALIVE
float gamem_bounce_threshold_f(float vOld, float bounciness, float minBounceThreshold) {
    return PhysicsGm::Bounce(vOld, bounciness, minBounceThreshold);
}

EMSCRIPTEN_KEEPALIVE
double gamem_clampvelocity(double v, double max) {
    return PhysicsGm::ClampVelocity(v, max);
}

EMSCRIPTEN_KEEPALIVE
float gamem_clampvelocity_f(float v, float max) {
    return PhysicsGm::ClampVelocity(v, max);
}

EMSCRIPTEN_KEEPALIVE
double gamem_addforce(double v, double F, double t, double m) {
    return PhysicsGm::AddForce(v, F, t, m);
}

EMSCRIPTEN_KEEPALIVE
float gamem_addforce_f(float v, float F, float t, float m) {
    return PhysicsGm::AddForce(v, F, t, m);
}

EMSCRIPTEN_KEEPALIVE
double gamem_addimpulse(double vOld, double J, double m) {
    return PhysicsGm::AddImpulse(vOld, J, m);
}

EMSCRIPTEN_KEEPALIVE
float gamem_addimpulse_f(float vOld, float J, float m) {
    return PhysicsGm::AddImpulse(vOld, J, m);
}

EMSCRIPTEN_KEEPALIVE
double gamem_jumpcut(double v, double multiplier) {
    return PhysicsGm::JumpCut(v, multiplier);
}

EMSCRIPTEN_KEEPALIVE
float gamem_jumpcut_f(float v, float multiplier) {
    return PhysicsGm::JumpCut(v, multiplier);
}

EMSCRIPTEN_KEEPALIVE
double gamem_terminalvelocity(double v, double vlimit) {
    return PhysicsGm::TerminalVelocity(v, vlimit);
}

EMSCRIPTEN_KEEPALIVE
float gamem_terminalvelocity_f(float v, float vlimit) {
    return PhysicsGm::TerminalVelocity(v, vlimit);
}
EMSCRIPTEN_KEEPALIVE
double gamem_calculatejumpvelocity(double h, double g) {
    return PhysicsGm::CalculateJumpVelocity(h, g);
}
EMSCRIPTEN_KEEPALIVE
float gamem_calculatejumpvelocity_f(float h, float g) {
    return PhysicsGm::CalculateJumpVelocity(h, g);
}
EMSCRIPTEN_KEEPALIVE
double gamem_getstoppingdistance(double v, double a) {
    return PhysicsGm::GetStoppingDistance(v, a);
}
EMSCRIPTEN_KEEPALIVE
float gamem_getstoppingdistance_f(float v, float a) {
    return PhysicsGm::GetStoppingDistance(v, a);
}
EMSCRIPTEN_KEEPALIVE
double gamem_applyquadraticdrag(double v, double k, double t) {
    return PhysicsGm::ApplyQuadraticDrag(v, k, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_applyquadraticdrag_f(float v, float k, float t) {
    return PhysicsGm::ApplyQuadraticDrag(v, k, t);
}
EMSCRIPTEN_KEEPALIVE
double gamem_calculatelaunchvelocity(double target, double start, double g, double t) {
    return PhysicsGm::CalculateLaunchVelocity(target, start, g, t);
}
EMSCRIPTEN_KEEPALIVE
float gamem_calculatelaunchvelocity_f(float target, float start, float g, float t) {
    return PhysicsGm::CalculateLaunchVelocity(target, start, g, t);
}
EMSCRIPTEN_KEEPALIVE
void gamem_predicttrajectory(float startPosX, float startPosY, float startVelocityX, float startVelocityY, float gravityX, float gravityY, float t, double* outX, double* outY) {
    auto result = PhysicsGm::PredictTrajectory(startPosX, startPosY, startVelocityX, startVelocityY, gravityX, gravityY, t);
    *outX = std::get<0>(result);
    *outY = std::get<1>(result);
}
EMSCRIPTEN_KEEPALIVE
void gamem_drag(float velocityX, float velocityY, float velocityZ, float drag, float deltaTime, double* outVelocityX, double* outVelocityY, double* outVelocityZ) {
    auto result = PhysicsGm::Drag(velocityX, velocityY, velocityZ, drag, deltaTime);
    *outVelocityX = std::get<0>(result);
    *outVelocityY = std::get<1>(result);
    *outVelocityZ = std::get<2>(result);
}
}