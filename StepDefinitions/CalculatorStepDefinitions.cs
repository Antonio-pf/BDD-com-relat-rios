using Reqnroll;
using FluentAssertions;

namespace Calculator.Test.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef
    private int _number1;
    private int _number2;
    private int _sum;
    

    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int number)
    {
        _number1 = number;
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int number)
    {
        _number2 = number;
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    { 
        _sum = _number1 + _number2;
    }

    [When("the two numbers are subtracted")]
    public void WhenTheTwoNumbersAreSubtracted()
    {
        _sum = _number1 - _number2;
    }

    [When("the two numbers are multiplied")]
    public void WhenTheTwoNumbersAreMultiplied()
    {
        _sum = _number1 * _number2;
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        _sum.Should().Be(result);
        
    }
}
