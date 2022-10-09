using NUnit.Framework;
using RayTracerChallenge;
using System;
using TechTalk.SpecFlow;

namespace RayTracerChallengeTest.StepDefinitions
{
    [Binding]
    public class CanvasStepDefinitions
    {
        private Canvas _canvas = new Canvas(0,0);
        
        [Given(@"a width of (.*) and a length of (.*)")]
        public void GivenAWidthOfAndALengthOf(int p0, int p1)
        {
            var width = p0;
            var length = p1;
        }

        [When(@"creating a canvas with width (.*) and length (.*)")]
        public void WhenCreatingACanvasWithWidthAndLength(int p0, int p1)
        {
            _canvas = new Canvas(p0, p1);
        }

        [Then(@"canvas\.width is equal to (.*)")]
        public void ThenCanvas_WidthIsEqualTo(int p0)
        {
            Assert.AreEqual(p0, _canvas.Width);
        }

        [Then(@"canvas\.length is equal to (.*)")]
        public void ThenCanvas_LengthIsEqualTo(int p0)
        {
            Assert.AreEqual(p0, _canvas.Height);
        }
        
        [Then(@"every pixel in canvas is black")]
        public void ThenEveryPixelInCanvasIsBlack()
        {
           var ExpectedResult = new Color(0, 0, 0);
            for (int i = 0; i < _canvas.Width; i++)
            {
                for (int j = 0; j < _canvas.Height; j++)
                {
                    Assert.AreEqual(ExpectedResult, _canvas.GetPixel(i, j));
                }
            }
        }

        [Given(@"a canvas with width (.*) and length (.*)")]
        public void GivenACanvasWithWidthAndLength(int p0, int p1)
        {
            _canvas = new Canvas(p0, p1);
        }

        [When(@"writing red color values (.*) and (.*) and (.*) to pixel at position (.*) and (.*)")]
        public void WhenWritingRedColorValuesAndAndToPixelAtPositionAnd(int p0, int p1, int p2, int p3, int p4)
        {
            _canvas.WritePixel(p3, p4, new Color(p0, p1, p2));
        }
        
        [Then(@"the pixel at position (.*) and (.*) should be color with values (.*) and (.*) and (.*)")]
        public void ThenThePixelAtPositionAndShouldBeColorWithValuesAndAnd(int p0, int p1, int p2, int p3, int p4)
        {
            var expectedResult = new Color(1, 0, 0);
            var test = _canvas.GetPixel(p0, p1);
            Assert.That(expectedResult.Equals(_canvas.GetPixel(p0, p1)));
        }






    }
}
