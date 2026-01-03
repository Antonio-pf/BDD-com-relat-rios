Feature: Subtraction

Simple calculator for subtracting two numbers

@math
Scenario: Subtract two positive numbers
	Given the first number is 100
	And the second number is 30
	When the two numbers are subtracted
	Then the result should be 70

@math
Scenario: Subtract negative result
	Given the first number is 25
	And the second number is 50
	When the two numbers are subtracted
	Then the result should be -25
