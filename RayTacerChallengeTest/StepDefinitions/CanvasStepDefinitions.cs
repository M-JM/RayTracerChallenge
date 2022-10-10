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
        private string _pPMHeader = "";
        private string _pPMData = "";
        private double _colorValue = 0.0;
        private int _colorConversionToIntResult = 0;
        private Color _color = new Color(0, 0, 0);
        private Color _color1 = new Color(0, 0, 0);
        private Color _color2 = new Color(0, 0, 0);

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


        [When(@"every pixel of the canvas is set to color (.*) and (.*) and (.*)")]
        public void WhenEveryPixelOfTheCanvasIsSetToColorAndAnd(int p0, Decimal p1, Decimal p2)
        {
            _canvas.InitializeCanvas(new Color(p0, (double)p1, (double)p2));
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
            Assert.That(expectedResult.Equals(_canvas.GetPixel(p0, p1)));
        }


        [When(@"creating a PPM header for canvas")]
        public void WhenCreatingAPPMHeaderForCanvas()
        {
            _pPMHeader = _canvas.BuildPPMHeader();
        }

        [Then(@"the PPM header should be")]
        public void ThenThePPMHeaderShouldBe(string multilineText)
        {
            Assert.AreEqual(multilineText, _pPMHeader );
        }

        [When(@"writing color values (.*) and (.*) and (.*) to pixel at position (.*) and (.*)")]
        public void WhenWritingColorValuesAndAndToPixelAtPositionAnd(int p0, int p1, int p2, int p3, int p4)
        {
            _canvas.WritePixel(p3, p4, new Color(p0, p1, p2));
        }

        [When(@"creating a PPM pixel data for canvas")]
        public void WhenCreatingAPPMPixelDataForCanvas()
        {
            _pPMData = _canvas.BuildPPMData();
        }

        [Then(@"the PPM pixel data should be")]
        public void ThenThePPMPixelDataShouldBe(string multilineText)
        {
            Assert.AreEqual(multilineText, _pPMData);
        }

        [Given(@"the first color is with values (.*) and (.*) and (.*)")]
        public void GivenTheFirstColorIsWithValuesAndAnd(int p0, int p1, int p2)
        {
            _color = new Color(p0, p1, p2);
        }

        [Given(@"the second color is with values (.*) and (.*) and (.*)")]
        public void GivenTheSecondColorIsWithValuesAndAnd(int p0, Decimal p1, int p2)
        {
            _color1 = new Color(p0, (float)p1, p2);
        }

        [Given(@"the third color is with values (.*) and (.*) and (.*)")]
        public void GivenTheThirdColorIsWithValuesAndAnd(Decimal p0, int p1, int p2)
        {
            _color2 = new Color((float)p0, p1, p2);
        }

        [When(@"writing the first color to pixel at position (.*) and (.*)")]
        public void WhenWritingTheFirstColorToPixelAtPositionAnd(int p0, int p1)
        {
            _canvas.WritePixel(p0, p1, _color);
        }

        [When(@"writing the second color to pixel at position (.*) and (.*)")]
        public void WhenWritingTheSecondColorToPixelAtPositionAnd(int p0, int p1)
        {
            _canvas.WritePixel(p0, p1, _color1);
        }

        [When(@"writing the third color to pixel at position (.*) and (.*)")]
        public void WhenWritingTheThirdColorToPixelAtPositionAnd(int p0, int p1)
        {
            _canvas.WritePixel(p0, p1, _color2);
        }

        [Given(@"a color value of (.*)")]
        public void GivenAColorValueOf(Double p0)
        {
            _colorValue = p0;
        }

        [When(@"we convert it to int")]
        public void WhenWeConvertItToInt()
        {
            _colorConversionToIntResult = Canvas.ConvertColorInInt(_colorValue);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(p0, _colorConversionToIntResult);
        }



    }
}
