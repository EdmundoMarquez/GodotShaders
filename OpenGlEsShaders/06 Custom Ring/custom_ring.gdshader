shader_type canvas_item;

uniform vec4 tint_color: source_color = vec4(0.5);
uniform float custom_radius = 0.2;
uniform float custom_width: hint_range(0.0, 0.5, 0.001) = 0.01;
uniform float custom_feather: hint_range(0.01, 0.3, 0.001) = 0.05;

float circle(vec2 position, float radius, float feather)
{
	return smoothstep(radius + feather, radius, length(position - vec2(0.5)));
}

void fragment() {
	float alpha = circle(UV, custom_radius, custom_feather);
	float inner_alpha = circle(UV, custom_radius - custom_width, custom_feather);
	
	//ALTERNATIVE: Use distance to measure center
	//vec2 center = vec2(0.5, 0.5);
	//float alpha = 1.0 - step(custom_radius, distance(center, UV));
	//float inner_alpha = 1.0 - step(custom_radius - custom_width, distance(center, UV));
	
	COLOR = tint_color;
	COLOR.a = tint_color.a * (alpha - inner_alpha);
}
