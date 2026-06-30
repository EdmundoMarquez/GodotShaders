shader_type canvas_item;

uniform float offset : hint_range(0.0, 1.0) = 0.0;
uniform float red_value : hint_range(0.0, 1.0, 0.1) = 1.0;
uniform float green_value : hint_range(0.0, 1.0, 0.1) = 1.0;
uniform sampler2D gradient_texture;

void fragment() {
	COLOR.a = UV.y - offset;
	vec4 gradient_color = texture(gradient_texture, UV);
	COLOR.rgb = gradient_color.rgb;
	
	float original_alpha = texture(TEXTURE, UV).a;
	COLOR.a += original_alpha;
	COLOR.r = UV.x * red_value;
	COLOR.g = UV.y * green_value;
}
