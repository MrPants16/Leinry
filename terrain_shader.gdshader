shader_type spatial;

uniform sampler2D heightmap;
uniform float height_scale = 10.0; // Adjust the height of the terrain

void vertex() {
    vec2 uv = VERTEX.xz / 100.0; // Adjust based on PlaneMesh size
    float height = texture(heightmap, uv).r * height_scale;
    VERTEX.y = height;
}