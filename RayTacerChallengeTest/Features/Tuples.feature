Feature: Tuples

Tuples are a way to group together values of different types.
Tuples are immutable and can contain up to 22 elements.

The basic building blocks of our Ray tracer will be points and vectors which are Tuples.
Points will be used to represent the location of objects in space. (W = 1.0)
Vectors will be used to represent the direction of objects in space. (W= 0.0)


// tags are markers akin to categories.
// can be used for example to mark important tests that have to be ran more frequently.

@ProveTupleIsPoint @Creation
Scenario: A tuple with w=1.0 is a point
	Given a <- tuple(4.3f, -4.2f, 3.1f, 1.0f)
	Then a.x = 4.3f
	And a.y = -4.2f
	And a.z = 3.1f
	And a.w = 1.0f
	And a is a point
	And a is not a vector

@ProveTupleIsVector @Creation
Scenario: A tuple with w=0.0 is a vector
	Given b <- tuple(4.3f, -4.2f, 3.1f, 0.0f)
	Then b.x = 4.3f
	And b.y = -4.2f
	And b.z = 3.1f
	And b.w = 0.0f
	And b is a vector
	And b is not a point

@ProveCreatingPoint @Creation
Scenario: point() creates tuples with w=1
	Given p <- point(4.0f, -4.0f, 3.0f)
	Then p = tuple(4.0f, -4.0f, 3.0f, 1.0f)

@ProveCreatingVector @Creation
Scenario: vector() creates tuples with w=0
	Given v <- vector(4.0f, -4.0f, 3.0f)
	Then v = tuple(4.0f, -4.0f, 3.0f, 0.0f)


@Operations @Addition
Scenario: Adding two tuples
	Given the first tuples is tuple(3.0f, -2.0f, 5.0f, 1.0f)
	And the second tuples is tuple(-2.0f, 3.0f, 1.0f, 0.0f)
	When the two tuples are added
	Then  the result should be tuple(1.0f, 1.0f, 6.0f, 1.0f)

@Operations @Addition
Scenario: Adding a vector to a point makes a new point
	Given the first tuple is point(3.0f, -2.0f, 5.0f)
	And the second tuple is vector(-2.0f, 3.0f, 1.0f)
	When the point and vector are added
	Then the result should be point(1.0f, 1.0f, 6.0f)
	And result is a point

@Operations @Addition
Scenario: Adding a vector to a vector makes a new vector
	Given the first tuple is vector(4.0f, -2.0f, 5.0f)
	And the second tuple is vector(4.0f, -2.0f, 5.0f)
	When the first and second vector are added
	Then the result should be vector(8.0f, -4.0f, 10.0f)
	And result is a vector
	
@Operations @Addition
Scenario: Adding a point to a point is not allowed
	Given the first tuple is point(3.0f, -2.0f, 5.0f)
	And the second tuple is point(3.0f, -2.0f, 5.0f)
	When the first and second points are added
	Then the program will throw an expection error that two points cannot be added
	
@Operations	@Substraction
Scenario: Substracting two vectors
	Given the first tuple is vector(3.0f, 2.0f, 1.0f)
	And the second tuple is vector(5.0f, 6.0f, 7.0f)
	When the first and second vectors are substracted
	Then the result should be vector(-2.0f, -4.0f, -6.0f)
	
@Operations @Substraction
Scenario: Substracting a vector from a point
	Given the first tuple is point(3.0f, -2.0f, 5.0f)
	And the second tuple is vector(5.0f, 6.0f, 7.0f)
	When the vector is substracted from the point
	Then the result should be point(-2.0f, -8.0f, -2.0f)
	
@Operations @Substraction
Scenario: Substracting two points
	Given the first tuples is tuple(3.0f, -2.0f, 5.0f, 1.0f)
	And the second tuples is tuple(-2.0f, 3.0f, 1.0f, 0.0f)
	When the second tuple is substracted from the first tuple
	Then the result should be point(5.0f, -5.0f, 4.0f)
		
@Operations @Substraction
Scenario: Substracting a point from a vector is not allowed
	Given the first tuple is vector(3.0f, 2.0f, 1.0f)
	And the second tuple is point(3.0f, -2.0f, 5.0f)
	When the point is substracted from the vector
	Then the program will throw an expection error that a point cannot be substracted from a vector

@Operations @Negating
Scenario: Substracting a vector from a zero vector
	Given the zero vector is vector(0.0f, 0.0f, 0.0f)
	And the first tuple is vector(1f, -2f, 3f)
	When the first tuple is substracted from the zero vector
	Then the result should be vector(-1f, 2f, -3f)

@Operations @Negating

Scenario: Negating a tuple
	Given the first tuple is tuple(1.0f, -2.0f, 3.0f, -4.0f)
	When the first tuple is negated
	Then the result should be tuple(-1.0f, 2.0f, -3.0f, 4.0f)
	
	