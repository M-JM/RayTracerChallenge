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

