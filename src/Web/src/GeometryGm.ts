import { getWasm } from "./WasmLoader.js";

/**
 * Provides static methods for Geometry calculations
 */
export class GeometryGm {
    /**
     * Reflects a 2D vector off a surface defined by a normal vector.
     * @param x The X component of the incident vector.
     * @param y The Y component of the incident vector.
     * @param normalX The X component of the surface normal (should be normalized).
     * @param normalY The Y component of the surface normal (should be normalized).
     * @returns A tuple containing the X and Y components of the reflected vector.
     */
    public static reflect(x: number, y: number, normalX: number, normalY: number): { x: number, y: number } {
        const outXPtr = getWasm()._malloc(8);
        const outYPtr = getWasm()._malloc(8);

        getWasm()._gamem_reflect(x, y, normalX, normalY, outXPtr, outYPtr);

        const resX = getWasm().getValue(outXPtr, "double");
        const resY = getWasm().getValue(outYPtr, "double");

        getWasm()._free(outXPtr);
        getWasm()._free(outYPtr);

        return { x: resX, y: resY };
    }
    /**
     * Reflects a 3D vector off a surface defined by a normal vector.
     * @param x The X component of the incident vector.
     * @param y The Y component of the incident vector.
     * @param z The Z component of the incident vector.
     * @param normalX The X component of the surface normal (should be normalized).
     * @param normalY The Y component of the surface normal (should be normalized).
     * @param normalZ The Z component of the surface normal (should be normalized).
     * @returns A tuple containing the X, Y, and Z components of the reflected vector.
     */
    public static reflect3D(x: number, y: number, z: number, normalX: number, normalY: number, normalZ: number): { x: number, y: number, z: number } {
        const outXPtr = getWasm()._malloc(8);
        const outYPtr = getWasm()._malloc(8);
        const outZPtr = getWasm()._malloc(8);

        getWasm()._gamem_reflect3d(x, y, z, normalX, normalY, normalZ, outXPtr, outYPtr, outZPtr);

        const resX = getWasm().getValue(outXPtr, "double");
        const resY = getWasm().getValue(outYPtr, "double");
        const resZ = getWasm().getValue(outZPtr, "double");

        getWasm()._free(outXPtr);
        getWasm()._free(outYPtr);
        getWasm()._free(outZPtr);

        return { x: resX, y: resY, z: resZ };
    }
    /**
     * Converts an angle from degrees to radians.
     * @param degrees The angle in degrees.
     * @returns The angle in radians.
     */
    public static toRadians(degrees: number) {
        return getWasm()._gamem_toradians(degrees);
    }
    /**
     * Converts an angle from radians to degrees.
     * @param radians The angle in radians.
     * @returns The angle in degrees.
     */
    public static toDegrees(radians: number) {
        return getWasm()._gamem_todegrees(radians);
    }
    /**
     * Calculates the Euclidean distance between two points in a 2D plane.
     * @param x1 The X-coordinate of the first point
     * @param y1 The Y-coordinate of the first point
     * @param x2 The X-coordinate of the second point
     * @param y2 The Y-coordinate of the second point
     * @returns The distance between the two points in 2D space.
     */
    public static getDistance(x1: number, y1: number, x2: number, y2: number) {
        return getWasm()._gamem_getdistance(x1, y1, x2, y2);
    }
    /**
     * Calculates the squared distance between two 2D points.
     * @param x1 The X coordinate of the first point.
     * @param y1 The Y coordinate of the first point.
     * @param x2 The X coordinate of the second point.
     * @param y2 The Y coordinate of the second point.
     * @returns The squared distance between the two points, avoiding an expensive square root operation.
     */
    public static getDistanceSquared(x1: number, y1: number, x2: number, y2: number) {
        return getWasm()._gamem_getdistancesquared(x1, y1, x2, y2);
    }
    /**
     * Calculates the Euclidean distance between two points in 3D space.
     * @param x1 The X-coordinate of the first point.
     * @param y1 The Y-coordinate of the first point.
     * @param z1 The Z-coordinate of the first point.
     * @param x2 The X-coordinate of the second point.
     * @param y2 The Y-coordinate of the second point.
     * @param z2 The Z-coordinate of the second point.
     * @returns The distance between the two points in 3D space.
     */
    public static getDistance3D(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number) {
        return getWasm()._gamem_getdistance3d(x1, y1, z1, x2, y2, z2);
    }
    
}
/**
 * Provides static methods for basic 2D intersection and collision detection.
 */
export class CollisionGm {
    /**
     * Checks for an intersection between two circles.
     * @param x1 The X-coordinate of the first circle's center.
     * @param y1 The Y-coordinate of the first circle's center.
     * @param radius1 The radius of the first circle.
     * @param x2 The X-coordinate of the second circle's center.
     * @param y2 The Y-coordinate of the second circle's center.
     * @param radius2 The radius of the second circle.
     * @returns True if the circles intersect or touch; otherwise, false.
     */
    public static checkCircleVsCircle(x1: number, y1: number, radius1: number, x2: number, y2: number, radius2: number) {
        return getWasm()._gamem_checkcirclevscircle(x1, y1, radius1, x2, y2, radius2);
    }
    /**
     * Checks for an intersection between two Axis-Aligned Bounding Boxes (AABB).
     * @param x1 The minimum X-coordinate (left edge) of the first box.
     * @param y1 The minimum Y-coordinate (top/bottom edge) of the first box.
     * @param width1 The total width of the first box.
     * @param height1 The total height of the first box.
     * @param x2 The minimum X-coordinate (left edge) of the second box.
     * @param y2 The minimum Y-coordinate (top/bottom edge) of the second box.
     * @param width2 The total width of the second box.
     * @param height2 The total height of the second box.
     * @returns True if the bounding boxes overlap or touch; otherwise, false.
     */
    public static checkAABBVsAABB(x1: number, y1: number, width1: number, height1: number, x2: number, y2: number, width2: number, height2: number) {
        return getWasm()._gamem_checkaabbvsaabb(x1, y1, width1, height1, x2, y2, width2, height2);
    }
    /**
     * Checks for an intersection between a circle and an Axis-Aligned Bounding Box (AABB).
     * @param circleX The X-coordinate of the circle's center.
     * @param circleY The Y-coordinate of the circle's center.
     * @param radius The radius of the circle.
     * @param aabbX The minimum X-coordinate (left edge) of the box.
     * @param aabbY The minimum Y-coordinate (top/bottom edge) of the box.
     * @param width The total width of the box.
     * @param height The total height of the box.
     * @returns True if the circle intersects or touches the bounding box; otherwise, false.
     */
    public static checkCircleVsAABB(circleX: number, circleY: number, radius: number, aabbX: number, aabbY: number, width: number, height: number) {
        return getWasm()._gamem_checkcirclevsaabb(circleX, circleY, radius, aabbX, aabbY, width, height);
    }
}
export class VectorMathGm {
    /**
     * Calculates the dot product of two 2D vectors.
     * @param x1 The X-component of the first vector.
     * @param y1 The Y-component of the first vector.
     * @param x2 The X-component of the second vector.
     * @param y2 The Y-component of the second vector.
     * @returns The scalar dot product of the two 2D vectors.
     */
    public static getDotProduct(x1: number, y1: number, x2: number, y2: number) {
        return getWasm()._gamem_getdotproduct(x1, y1, x2, y2);
    }
    /**
     * Calculates the dot product of two 3D vectors.
     * @param x1 The X-component of the first vector.
     * @param y1 The Y-component of the first vector.
     * @param z1 The Z-component of the first vector.
     * @param x2 The X-component of the second vector.
     * @param y2 The Y-component of the second vector.
     * @param z2 The Z-component of the second vector.
     * @returns The scalar dot product of the two 3D vectors.
     */
    public static getDotProduct3D(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number) {
        return getWasm()._gamem_getdotproduct(x1, y1, x2, y2);
    }
    /**
     * Calculates the magnitude (length) of a 2D vector.
     * @param x The X-component of the vector.
     * @param y The Y-component of the vector.
     * @returns The magnitude of the 2D vector.
     */
    public static getMagnitude(x: number, y: number) {
        return getWasm()._gamem_getmagnitude(x, y);
    }
    /**
     * Calculates the magnitude (length) of a 3D vector.
     * @param x The X-component of the vector.
     * @param y The Y-component of the vector.
     * @param z The Z-component of the vector.
     * @returns The magnitude of the 3D vector.
     */
    public static getMagnitude3D(x: number, y: number, z: number) {
        return getWasm()._gamem_getmagnitude3d(x, y, z);
    }
    /**
     * Calculates the cross product of two 3D vectors.
     * @param x1 The X-component of the first vector.
     * @param y1 The Y-component of the first vector.
     * @param z1 The Z-component of the first vector.
     * @param x2 The X-component of the second vector.
     * @param y2 The Y-component of the second vector.
     * @param z2 The X-component of the first vector.
     * @returns A tuple representing the resulting 3D vector perpendicular to both input vectors
     */
    public static getCrossProduct(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number): { x: number, y: number, z: number } {
        const outXPtr = getWasm()._malloc(8);
        const outYPtr = getWasm()._malloc(8);
        const outZPtr = getWasm()._malloc(8);

        getWasm()._gamem_getcrossproduct(x1, y1, z1, x2, y2, z2, outXPtr, outYPtr, outZPtr);

        const resX = getWasm().getValue(outXPtr, "double");
        const resY = getWasm().getValue(outYPtr, "double");
        const resZ = getWasm().getValue(outZPtr, "double");
        
        getWasm()._free(outXPtr);
        getWasm()._free(outYPtr);
        getWasm()._free(outZPtr);

        return { x: resX, y: resY, z: resZ };
    }
    /**
     * Calculates the angle between two vectors in radians using their dot product and magnitudes.
     * @param dotProduct The dot product of the two vectors.
     * @param lengthA The magnitude (length) of the first vector.
     * @param lengthB The magnitude (length) of the second vector.
     * @returns The angle between the vectors in radians.
     */
    public static getAngleBetween(dotProduct: number, lengthA: number, lengthB: number) {
        return getWasm()._gamem_getanglebetween(dotProduct, lengthA, lengthB);
    }
    /**
     * Normalizes an angle in degrees into the range [0, 360).
     * @param angle The input angle in degrees to normalize.
     * @returns The equivalent angle wrapped within the range of 0 (inclusive) to 360 (exclusive) degrees.
     */
    public static normalizeangle(angle: number) {
        return getWasm()._gamem_normalizeangle(angle);
    }
}