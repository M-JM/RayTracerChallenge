using NUnit.Framework;
using RayTracerChallenge;
using System;
using TechTalk.SpecFlow;

namespace RayTracerChallengeTest.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Matrix")]
    public class MaxtrixStepDefinitions
    {
        private Matrix _matrix = new Matrix(0, 0);
        private float _matrixValue = 0.0f;


        [Given(@"a matrix M with (.*)")]
        public void GivenAMatrixMWith(int p0, string multilineText)
        {
            _matrix = new Matrix((int)p0, (int)p0);
            _matrix.InitializeMatrix(multilineText);
        }

 
        [When(@"inspecting the maxtrix with the following (.*) and (.*)")]
        public void WhenInspectingTheMaxtrixWithTheFollowingAnd(int p0, int p1)
        {
            _matrixValue = (float)_matrix.GetElement(p0, p1);
        }

        
     
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(float p0)
        {
            Assert.AreEqual(p0,_matrixValue );
        }
    }
}
