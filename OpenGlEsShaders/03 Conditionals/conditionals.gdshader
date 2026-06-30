shader_type canvas_item;

uniform float progress : hint_range(0.0, 1.0) = 0.0;

void fragment() {
	// Basic conditonal
	//if(UV.x >= 0.5){
		//COLOR.a = 1.0;
	//}
	//else{
		//COLOR.a = 0.0;
	//}
	
	// Using ternary operators
	//COLOR.a = UV.x >= 0.5 ? 1.0 : 0.0;
	
	// Using step function
	COLOR.a = step(progress, UV.x);
}