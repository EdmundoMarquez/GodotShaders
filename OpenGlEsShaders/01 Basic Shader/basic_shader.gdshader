shader_type canvas_item;

uniform vec4 custom_color : source_color = vec4(0.5);

void fragment() {
	vec3 color = vec3(0.5, 0.3, 0.9);
	float alpha = 0.2;
	int test = 1;
	
	COLOR.rgb = color;
	COLOR.a *= alpha + float(test);
	COLOR = custom_color;
}
