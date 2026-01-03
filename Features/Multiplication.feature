Feature: Multiplication

Simple calculator for multiplying two numbers

@math
Scenario: Multiply two positive numbers
	Given the first number is 5
	And the second number is 8
	When the two numbers are multiplied
	Then the result should be 40

@math
Scenario: Multiply by zero
	Given the first number is 100
	And the second number is 0
	When the two numbers are multiplied
	Then the result should be 0

@math
Scenario: Multiply negative numbers
	Given the first number is -5
	And the second number is -3
	When the two numbers are multiplied
	Then the result should be 15
