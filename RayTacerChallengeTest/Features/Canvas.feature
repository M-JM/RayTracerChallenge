Feature: Canvas

A Canvas is a rectangular grid of pixels.

@Creation
Scenario: Creating a Canvas
	Given a width of 20 and a length of 50
	When creating a canvas with width 20 and length 50
	Then canvas.width is equal to 20
	And canvas.length is equal to 50
	And every pixel in canvas is black

@Drawing

Scenario: Writing a pixel to a canvas
	Given a canvas with width 20 and length 50
	When writing red color values 1 and 0 and 0 to pixel at position 10 and 20
	Then the pixel at position 10 and 20 should be color with values 1 and 0 and 0

@PPM @Creation

Scenario: Creating a PPM header
	Given a canvas with width 20 and length 50
	When creating a PPM header for canvas
	Then the PPM header should be
		"""
		P3
		20 50
		255
		"""

@PPM @Drawing

Scenario: Creating a PPM pixel data
	Given a canvas with width 1 and length 1
	When writing color values 1 and 0 and 0 to pixel at position 0 and 0
	And creating a PPM pixel data for canvas
	Then the PPM pixel data should be
		"""
		255 0 0
		
		"""

@PPM @Drawing

Scenario: Constructing the PPM pixel data
	Given a canvas with width 5 and length 3
	And the first color is with values 1 and 0 and 0
	And the second color is with values 0 and 0.5 and 0
	And the third color is with values -0.5 and 0 and 1
	When writing the first color to pixel at position 0 and 0
	And writing the second color to pixel at position 2 and 1
	And writing the third color to pixel at position 4 and 2
	And creating a PPM pixel data for canvas
	Then the PPM pixel data should be
		"""
		255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
		0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
		0 0 0 0 0 0 0 0 0 0 0 0 0 0 255
		
		"""
		
@PPM @ConvertColorToInt

Scenario Outline: Converting a color value to an int bewteen 0 and 255
	Given a color value of <ColorValue>
	When we convert it to int
	Then the result should be <int>

Examples:
	| ColorValue | int |
	| 0          | 0   |
	| 1          | 255 |
	| 0.8        | 204 |

@PPM @ConvertColorToInt

Scenario Outline: Converting a color value to an int out of bound
	Given a color value of <ColorValue>
	When we convert it to int
	Then the result should be <int>

Examples:
	| ColorValue | int |
	| -1         | 0   |
	| 1.5        | 255 |
	| 1.7        | 255 |

@PPM @ConvertColorToInt
Scenario Outline: Converting a color value to an int that does result in a decimal should round away from zero
	Given a color value of <ColorValue>
	When we convert it to int
	Then the result should be <int>
Examples:
	| ColorValue | int |
	| 0.5        | 128 |
	| 0.7        | 179 |
	| 0.9        | 230 |

@PPM @Drawing

Scenario: Splitting long lines in PPM files

	Given a canvas with width 10 and length 2
	When every pixel of the canvas is set to color 1 and 0.8 and 0.6
	And creating a PPM pixel data for canvas
	Then the PPM pixel data should be
		"""
		255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
		153 255 204 153 255 204 153 255 204 153 255 204 153
		255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
		153 255 204 153 255 204 153 255 204 153 255 204 153
		
		"""
