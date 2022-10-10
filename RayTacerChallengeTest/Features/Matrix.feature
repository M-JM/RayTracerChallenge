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
| 0   | 3   | 4   |
| 1   | 3   | 8.5   |
| 3   | 3   | 16.5    |
| 3   | 0   | 13.5   |
| 0   | 0   | 1   |
| 0   | 1   | 2   |

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
| 0   | 0   | -3   |
| 0   | 1   | 5   |
| 1   | 0   | 1   |
| 1   | 1   | -2   |

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
| 0   | 0   | -3   |
| 1   | 1   | -2   |
| 2   | 2   | 1   |
