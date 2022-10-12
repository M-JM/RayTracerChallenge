Feature: Matrix

Matrices are a great way to store and manipulate data. We will write a class to create a matrices of various sizes.
We will also code basic operations on matrices. 

@Creation
Scenario Outline: Constructing and inspecting a 4x4 matrix
	Given a matrix M with 4
		"""
		{1, 2, 3, 4},
		{5.5, 6.5, 7.5, 8.5},
		{9, 10, 11, 12},
		{13.5, 14.5, 15.5, 16.5}
		"""
	When inspecting the maxtrix with the following <row> and <col>
	Then the result should be <result>

Examples:
	| row | col | result |
	| 0   | 3   | 4      |
	| 1   | 3   | 8.5    |
	| 3   | 3   | 16.5   |
	| 3   | 0   | 13.5   |
	| 0   | 0   | 1      |
	| 0   | 1   | 2      |

@Creation
Scenario Outline: Constucting and inspecting a 2x2 matrix
	Given a matrix M with 2
		"""
		{-3, 5},
		{1, -2}
		"""
	When inspecting the maxtrix with the following <row> and <col>
	Then the result should be <result>
Examples:
	| row | col | result |
	| 0   | 0   | -3     |
	| 0   | 1   | 5      |
	| 1   | 0   | 1      |
	| 1   | 1   | -2     |

@Creation
Scenario Outline: Constructing and inspecting a 3x3 matrix
	Given a matrix M with 3
		"""
		{-3, 5, 0},
		{1, -2, -7},
		{0, 1, 1}
		"""
	When inspecting the maxtrix with the following <row> and <col>
	Then the result should be <result>
Examples:
	| row | col | result |
	| 0   | 0   | -3     |
	| 1   | 1   | -2     |
	| 2   | 2   | 1      |


@Equality
Scenario Outline: Comparing two matrices
	Given a matrix M with 4
		"""
		{1, 2, 3, 4},
		{5, 6, 7, 8},
		{9, 8, 7, 6},
		{5, 4, 3, 2}
		"""
	And a matrix N with 4
		"""
		{1, 2, 3, 4},
		{5, 6, 7, 8},
		{9, 8, 7, 6},
		{5, 4, 3, 2}
		"""
	When comparing the matrices
	Then they should be considered equal

@Equality
Scenario: Matrix equality with different matrices
	Given a matrix M with 4
		"""
		{1, 2, 3, 4},
		{5, 6, 7, 8},
		{9, 8, 7, 6},
		{5, 4, 3, 2}
		"""
	And a matrix N with 4
		"""
		{2, 3, 4, 5},
		{6, 7, 8, 9},
		{8, 7, 6, 5},
		{4, 3, 2, 1}
		"""
	When comparing the matrices
	Then they should not be considered equal

@Multiplication

Scenario: Multiplying a matrix by another maxtrix of the same size
	Given a matrix M with 4
		"""
		{1, 2, 3, 4},
		{5, 6, 7, 8},
		{9, 8, 7, 6},
		{5, 4, 3, 2}
		"""
	And a matrix N with 4
		"""
		{-2, 1, 2, 3},
		{3, 2, 1, -1},
		{4, 3, 6, 5},
		{1, 2, 7, 8}
		"""
	When multiplying the matrices
	Then the outcome should be a Matrix with 4 and
		"""
		{20, 22, 50, 48},
		{44, 54, 114, 108},
		{40, 58, 110, 102},
		{16, 26, 46, 42}
		"""

@Multiplication

Scenario: Multiplying a matrix by a tuple
	Given a matrix M with 4
		"""
		{1, 2, 3, 4},
		{2, 4, 4, 2},
		{8, 6, 4, 1},
		{0, 0, 0, 1}
		"""
	And a tuple T with value (1, 2, 3, 1)
	When multiplying the matrix and tuple
	Then the outcome should be a tuple with value (18, 24, 33, 1)


@Multiplication

Scenario: Multiplying a matrix by the identity matrix
	Given a matrix M with 4
		"""
		{0, 1, 2, 4},
		{1, 2, 4, 8},
		{2, 4, 8, 16},
		{4, 8, 16, 32}
		"""
	And a matrix Identity
		"""
		{1, 0, 0, 0},
		{0, 1, 0, 0},
		{0, 0, 1, 0},
		{0, 0, 0, 1}
		"""
	When multiplying the matrix and identity matrix
	Then the result should be
		"""
		{0, 1, 2, 4},
		{1, 2, 4, 8},
		{2, 4, 8, 16},
		{4, 8, 16, 32}
		"""

@Multiplication
Scenario: Multiplying a tuple by the identity matrix
	Given a matrix Identity
		"""
		{1, 0, 0, 0},
		{0, 1, 0, 0},
		{0, 0, 1, 0},
		{0, 0, 0, 1}
		"""
	And a tuple T with value (1, 2, 3, 4)
	When multiplying the tuple and identity matrix
	Then the outcome should be a tuple with value (1, 2, 3, 4)

@Operations @Transform
Scenario: Transposing a Matrix
	Given a matrix M with 4
		"""
		{0, 9, 3, 0},
		{9, 8, 0, 8},
		{1, 8, 5, 3},
		{0, 0, 5, 8}
		"""
	When transposing the matrix
	Then the outcome should be a Matrix with 4 and
		"""
		{0, 9, 1, 0},
		{9, 8, 8, 0},
		{3, 0, 5, 5},
		{0, 8, 3, 8}
		"""
	
@Operations @Transform
Scenario: Transposing a Identity Matrix
	Given a matrix Identity
		"""
		{1, 0, 0, 0},
		{0, 1, 0, 0},
		{0, 0, 1, 0},
		{0, 0, 0, 1}
		"""
	When transposing the identity matrix
	Then the outcome should be a Matrix with 4 and
		"""
		{1, 0, 0, 0},
		{0, 1, 0, 0},
		{0, 0, 1, 0},
		{0, 0, 0, 1}
		"""

@Operations @Determinants
Scenario: Calculating the determinant of a 2x2 matrix
	Given a matrix M with 2
		"""
		{1, 5},
		{-3, 2}
		"""
	When calculating the determinant
	Then the outcome should be 17

@Operations @SubMatrix
Scenario: A submatrix of a 3x3 matrix is a 2x2 matrix
	Given a matrix M with 3
		"""
		{1, 5, 0},
		{-3, 2, 7},
		{0, 6, -3}
		"""
	When calculating the submatrix with row 0 and col 2
	Then the outcome should be a Matrix with 2 and
		"""
		{-3, 2},
		{0, 6}
		"""

@Operations @SubMatrix
Scenario: A submatrix of a 4x4 matrix is a 3x3 matrix
	Given a matrix M with 4
		"""
		{-6, 1, 1, 6},
		{-8, 5, 8, 6},
		{-1, 0, 8, 2},
		{-7, 1, -1, 1}
		"""
	When calculating the submatrix with row 2 and col 1
	Then the outcome should be a Matrix with 3 and
		"""
		{-6, 1, 6},
		{-8, 8, 6},
		{-7, -1, 1}
		"""

@Operations @Minor
Scenario: Calculating the Minor of a 3x3 matrix
	Given a matrix M with 3
		"""
		{3, 5, 0},
		{2, -1, -7},
		{6, -1, 5}
		"""
	When calculating the minor with row 1 and col 0
	Then the outcome should be 25

@Operations @Cofactor
Scenario: Calculating the Cofactor of a 3x3 matrix
	Given a matrix M with 3
		"""
		{3, 5, 0},
		{2, -1, -7},
		{6, -1, 5}
		"""
	When calculating the cofactor with row 0 and col 0
	Then the outcome should be -12

	@Operations @Cofactor
Scenario: Calculating the Cofactor of a 3x3 matrix with row 1 and col 0
	Given a matrix M with 3
		"""
		{3, 5, 0},
		{2, -1, -7},
		{6, -1, 5}
		"""
	When calculating the cofactor with row 1 and col 0
	Then the outcome should be -25

@Operations @Determinants
Scenario: Calculating the determinant of a 3x3 matrix
	Given a matrix M with 3
		"""
		{1, 2, 6},
		{-5, 8, -4},
		{2, 6, 4}
		"""
	When calculating the determinant
	Then the outcome should be -196

@Operations @Determinants
Scenario: Calculating the determinant of a 4x4 matrix
	Given a matrix M with 4
		"""
		{-2, -8, 3, 5},
		{-3, 1, 7, 3},
		{1, 2, -9, 6},
		{-6, 7, 7, -9}
		"""
	When calculating the determinant
	Then the outcome should be -4071