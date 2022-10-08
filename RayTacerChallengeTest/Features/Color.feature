Feature: Color

Color class with operations for color manipulation.

@Creation
Scenario: Colors are tuples that consist of red , green , blue value
	Given a tuple color with values (0.9, 0.6, 0.75)
	When instansiate a Color with those values
	Then the red value of the color object is 0.9
	Then the green value of the color object is 0.6
	Then the blue value of the color object is 0.75

@Operations @Addition

Scenario: Adding colors
	Given a first color with values (0.9, 0.6, 0.75)
	And a second color with values (0.7, 0.1, 0.25)
	When c1 is added to c2
	Then the result is a Color with values (1.6, 0.7, 1.0)

@Operations @Subtraction

Scenario: Substracting colors
		Given a first color with values (0.9, 0.6, 0.75)
	And a second color with values (0.7, 0.1, 0.25)
	When c2 is substracted from c1
	Then the result is a Color with values (0.2, 0.5, 0.5)
	
@Operations @Multiplication

Scenario: Multiplying a color by a scalar
	Given a first color with values (0.9, 0.6, 0.75)
	When c is multiplied by 2
	Then the result is a Color with values (1.8, 1.2, 1.5)

@Operations @Multiplication

Scenario: Multiplying a color by a color
	Given a first color with values (1, 0.2, 0.4)
	And a second color with values (0.9, 1, 0.1)
	When c1 is multiplied by c2
	Then the result is a Color with values (0.9, 0.2, 0.04)