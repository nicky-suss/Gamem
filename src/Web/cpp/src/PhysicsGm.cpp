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
}