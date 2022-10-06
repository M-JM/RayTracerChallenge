Feature: Tuples

Tuples are a way to group together values of different types.
Tuples are immutable and can contain up to 22 elements.

The basic building blocks of our Ray tracer will be points and vectors which are Tuples.
Points will be used to represent the location of objects in space. (W = 1.0)
Vectors will be used to represent the direction of objects in space. (W= 0.0)


// tags are markers akin to categories.
// can be used for example to mark important tests that have to be ran more frequently.

@ProveTupleIsPoint
Scenario: A tuple with w=1.0 is a point
	Given a <- tuple(4.3f, -4.2f, 3.1f, 1.0f)
	Then a.x = 4.3f
	And a.y = -4.2f
	And a.z = 3.1f
	And a.w = 1.0f
	And a is a point
	And a is not a vector

@ProveTupleIsVector
Scenario: A tuple with w=0.0 is a vector
	Given b <- tuple(4.3f, -4.2f, 3.1f, 0.0f)
	Then b.x = 4.3f
	And b.y = -4.2f
	And b.z = 3.1f
	And b.w = 0.0f
	And b is a vector
	And b is not a point

@ProveCreatingPoint
Scenario: point() creates tuples with w=1
Given p <- point(4.0f, -4.0f, 3.0f)
Then p = tuple(4.0f, -4.0f, 3.0f, 1.0f)

@ProveCreatingVector
Scenario: vector() creates tuples with w=0
Given v <- vector(4.0f, -4.0f, 3.0f)
Then v = tuple(4.0f, -4.0f, 3.0f, 0.0f)