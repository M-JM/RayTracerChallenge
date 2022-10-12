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
        private Matrix _matrix2 = new Matrix(0, 0);
        private Matrix _matrixResult = new Matrix(0, 0);
        private bool _resultComparison = false;
        private float _matrixValue = 0.0f;
        private float _determinant = 0.0f;
        private Tuples _tuple = new Tuples(0, 0, 0, 0);
        private Tuples _tupleResult = new Tuples(0, 0, 0, 0);
        private float _minor = 0.0f;


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
            Assert.AreEqual(p0, _matrixValue);
        }


        [Given(@"a matrix N with (.*)")]
        public void GivenAMatrixNWith(int p0, string multilineText)
        {
            _matrix2 = new Matrix(p0, p0);
            _matrix2.InitializeMatrix(multilineText);
        }

        [When(@"comparing the matrices")]
        public void WhenComparingTheMatrices()
        {
            _resultComparison = _matrix.Equals(_matrix2);
        }

        [Then(@"they should be considered equal")]
        public void ThenTheyShouldBeConsideredEqual()
        {
            Assert.AreEqual(true, _resultComparison);
        }

        [Then(@"they should not be considered equal")]
        public void ThenTheyShouldNotBeConsideredEqual()
        {
            Assert.AreEqual(false, _resultComparison);
        }


        [When(@"multiplying the matrices")]
        public void WhenMultiplyingTheMatrices()
        {
            _matrixResult = _matrix * _matrix2;
        }

        [Then(@"the outcome should be a Matrix with (.*) and (.*)")]
        public void ThenTheOutcomeShouldBeAMatrixWithAnd(int p0, int p1, string multilineText)
        {
            Matrix _matrixExpected = new Matrix(p1, p0);
            _matrixExpected.InitializeMatrix(multilineText);
            Assert.IsTrue(_matrixResult.Equals(_matrixExpected));
        }




        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(string multilineText)
        {
            Matrix _matrixExpected = new Matrix(4, 4);
            _matrixExpected.InitializeMatrix(multilineText);
            Assert.IsTrue(_matrixResult.Equals(_matrixExpected));
        }

        [Given(@"a tuple T with value \((.*), (.*), (.*), (.*)\)")]
        public void GivenATupleTWithValue(int p0, int p1, int p2, int p3)
        {
            _tuple = new Tuples(p0, p1, p2, p3);
        }

        [When(@"multiplying the matrix and tuple")]
        public void WhenMultiplyingTheMatrixAndTuple()
        {
            _tupleResult = _matrix * _tuple;
        }

        [Given(@"a matrix Identity")]
        public void GivenAMatrixIdentity(string multilineText)
        {
            _matrix2 = new Matrix(4, 4);
            _matrix2.InitializeMatrix(multilineText);
        }

        [When(@"multiplying the matrix and identity matrix")]
        public void WhenMultiplyingTheMatrixAndIdentityMatrix()
        {
            _matrixResult = _matrix * _matrix2;
        }

        [When(@"multiplying the tuple and identity matrix")]
        public void WhenMultiplyingTheTupleAndIdentityMatrix()
        {
            _tupleResult = _matrix2 * _tuple;
        }

        [Then(@"the outcome should be a Matrix with (.*) and")]
        public void ThenTheOutcomeShouldBeAMatrixWithAnd(int p0, string multilineText)
        {
            Matrix _matrixExpected = new Matrix(p0, p0);
            _matrixExpected.InitializeMatrix(multilineText);
            Assert.That(_matrixResult.Equals(_matrixExpected));
        }

        [Then(@"the outcome should be a tuple with value \((.*), (.*), (.*), (.*)\)")]
        public void ThenTheOutcomeShouldBeATupleWithValue(int p0, int p1, int p2, int p3)
        {
            Tuples _tupleExpected = new Tuples(p0, p1, p2, p3);
            Assert.IsTrue(_tupleResult.Equals(_tupleExpected));
        }

        [When(@"transposing the matrix")]
        public void WhenTransposingTheMatrix()
        {
            _matrixResult = _matrix.Transpose();
        }

        [When(@"transposing the identity matrix")]
        public void WhenTransposingTheIdentityMatrix()
        {
            _matrixResult = _matrix2.Transpose();
        }

        [When(@"calculating the determinant")]
        public void WhenCalculatingTheDeterminant()
        {
            _determinant = _matrix.Determinant();
        }

        [Then(@"the outcome should be (.*)")]
        public void ThenTheOutcomeShouldBe(float p0)
        {
            Assert.That(p0.Equals(_determinant));
        }

        [When(@"calculating the submatrix with row (.*) and col (.*)")]
        public void WhenCalculatingTheSubmatrixWithRowAndCol(int p0, int p1)
        {
            _matrixResult = _matrix.Submatrix(p0, p1);
        }
        
        [When(@"calculating the minor with row (.*) and col (.*)")]
        public void WhenCalculatingTheMinorWithRowAndCol(int p0, int p1)
        {
            Matrix _matrixsub = _matrix.Submatrix(p0, p1);
            _determinant = Matrix.Minor(_matrixsub);
        }

        [When(@"calculating the cofactor with row (.*) and col (.*)")]
        public void WhenCalculatingTheCofactorWithRowAndCol(int p0, int p1)
        {
            _determinant = Matrix.Cofactor(_matrix,p0, p1);
        }



    }
}
