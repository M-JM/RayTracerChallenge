using NUnit.Framework;
using RayTracerChallenge;
using System;
using TechTalk.SpecFlow;

namespace RayTracerChallengeTest.StepDefinitions
{
    [Binding]
    public class ColorStepDefinitions
    {
        private Color _colorA = new Color(0,0,0);
        private Color _colorB = new Color(0,0,0);
        private Color _result = new Color(0,0,0);
        private Tuple<double, double, double> _tuple = new Tuple<double, double, double>(0, 0, 0);

        [Given(@"a tuple color with values \((.*), (.*), (.*)\)")]
        public void GivenATupleColorWithValues(Decimal p0, Decimal p1, Decimal p2)
        {
            _tuple = new Tuple<double, double, double>((double)p0, (double)p1, (double)p2);
        }

        [When(@"instansiate a Color with those values")]
        public void WhenInstansiateAColorWithThoseValues()
        {
            _colorA = new Color(_tuple.Item1, _tuple.Item2, _tuple.Item3);
        }

        [Then(@"the red value of the color object is (.*)")]
        public void ThenTheRedValueOfTheColorObjectIs(Decimal p0)
        {
            var expectedResult = (double)p0;
            Assert.AreEqual(expectedResult, _colorA.Red);
        }

        [Then(@"the green value of the color object is (.*)")]
        public void ThenTheGreenValueOfTheColorObjectIs(Decimal p0)
        {
            var expectedResult = (double)p0;
            Assert.AreEqual(expectedResult, _colorA.Green);
        }

        [Then(@"the blue value of the color object is (.*)")]
        public void ThenTheBlueValueOfTheColorObjectIs(Decimal p0)
        {
            var expectedResult = (double)p0;
            Assert.AreEqual(expectedResult, _colorA.Blue);
        }

        [Given(@"a first color with values \((.*), (.*), (.*)\)")]
        public void GivenAFirstColorWithValues(Decimal p0, Decimal p1, Decimal p2)
        {
            _colorA = new Color((double)p0, (double)p1, (double)p2);
        }

        [Given(@"a second color with values \((.*), (.*), (.*)\)")]
        public void GivenASecondColorWithValues(Decimal p0, Decimal p1, Decimal p2)
        {
            _colorB = new Color((double)p0, (double)p1, (double)p2);
        }

        [When(@"c(.*) is added to c(.*)")]
        public void WhenCIsAddedToC(int p0, int p1)
        {
            _result = _colorA + _colorB;
        }

        [Then(@"the result is a Color with values \((.*), (.*), (.*)\)")]
        public void ThenTheResultIsAColorWithValues(Decimal p0, Decimal p1, Decimal p2)
        {
            var ExpectedResult = new Color((double)p0, (double)p1, (double)p2);
            Assert.IsTrue(ExpectedResult.Equals(_result));
            Assert.That(_result, Is.EqualTo(ExpectedResult).Within(0.0001));
        }

        [When(@"c(.*) is substracted from c(.*)")]
        public void WhenCIsSubstractedFromC(int p0, int p1)
        {
            _result = _colorA - _colorB;
        }

        [When(@"c is multiplied by (.*)")]
        public void WhenCIsMultipliedBy(int p0)
        {
            _result = _colorA * (double)p0;
        }

        [When(@"c(.*) is multiplied by c(.*)")]
        public void WhenCIsMultipliedByC(int p0, int p1)
        {
            _result = _colorA * _colorB;
        }
    }
}
