# Gamem 3.2.0 is out!

_You can download it on [NuGet](https://www.nuget.org/packages/Gamem)!_

## Changes

Random methods were transfered from `MathGm` to a new class `RandomGm`. Don't worry, you can still use `MathGm` random methods! They were just marked as deprecated

## New methods

### RandomGm (NEW)
- `RandomAngleDegrees` - Generates a random angle number in degrees (0 - 360)
- `RandomAngleRadians` - Generates a random angle number in radians (0.0 - 6.28)
- `RandomSign` - Generates a random sign (-1 or 1) so your number can turn into positive or negative
- `RandomBool` - Generates random bool value (true or false)

> [!NOTE]
> `RandomRange` and `RollChance` are already in `RandomGm` class, they were transfered from `MathGm` so they are not new
### MathGm
- `EaseOutElastic` - Calculates an Ease-Out Elastic easing value, producing an oscillating decay effect that settles at 1.0.