extends Sprite2D

@export_category("Colors")
@export var main_color_to : Color
@export var highlight_color_to : Color
@export_category("Values")
@export_range(0.0,1.0,0.1) var pulse_amount_to : float = 0.5

func _ready() -> void:
	# Set the color parameter
	material.set_shader_parameter('PulseAmount', pulse_amount_to)

	# Create a tween
	var tween = create_tween()
	# Animate the shader parameter
	tween.tween_property(self, 'material:shader_parameter/MainColor', main_color_to, 2)
	tween.parallel().tween_property(self, 'material:shader_parameter/HighlightColor', highlight_color_to, 2)