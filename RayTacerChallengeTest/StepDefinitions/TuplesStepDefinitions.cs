using NUnit.Framework;
using RayTracerChallenge;
using System;
using TechTalk.SpecFlow;

namespace RayTracerChallengeTest.StepDefinitions
{
    [Binding]
    public class TuplesStepDefinitions
    {
        //Refactor the private fields and use only 2 Tuples to perform the operations
        // Maybe Abstract class Tuples and let Point and Vector inherit from it ?
        // Using Tuples does not make it clear what the type of the object is.
        

        private Tuples _tuplesA = new Tuples(0f,0f,0f,0f);
        private Tuples _tuplesB = new Tuples(0f,0f,0f,0f);
        private Tuples? _createPoint;
        private Tuples? _createVector;
        private Tuples _result = new Tuples(0f, 0f, 0f, 0f);
        private Tuples _pointA = new Tuples(0f, 0f, 0f, 0f);
        private Tuples _pointB = new Tuples(0f, 0f, 0f, 0f);
        private Tuples _vectorC = new Tuples(0f, 0f, 0f, 0f);
        private Tuples _vectorD = new Tuples(0f, 0f, 0f, 0f);
        private ArgumentException _argumentException = new ArgumentException();

        [Given(@"a <- tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void GivenA_Tuple(float p0, float p1, float p2, float p3)
        {
            _tuplesA = new Tuples(p0, p1, p2, p3);
            
        }

        [Then(@"a\.x = (.*)f")]
        public void ThenA_X(float p0)
        {
            Assert.That(p0, Is.EqualTo(_tuplesA.XAxis).Within(0.01f));
        }
        
        [Then(@"a\.y = (.*)f")]
        public void ThenA_Y(float p1)
        {
            Assert.That(p1, Is.EqualTo(_tuplesA.YAxis).Within(0.01f));
        }

        [Then(@"a\.z = (.*)f")]
        public void ThenA_Z(float p2)
        {
            Assert.That(p2, Is.EqualTo(_tuplesA.ZAxis).Within(0.01f));
        }

        [Then(@"a\.w = (.*)f")]
        public void ThenA_W(float p3)
        {
            Assert.That(p3, Is.EqualTo(_tuplesA.WAxis).Within(0.01f));
        }

        [Then(@"a is a point")]
        public void ThenAIsAPoint()
        {
            Assert.True(_tuplesA.IsPoint());
        }

        [Then(@"a is not a vector")]
        public void ThenAIsNotAVector()
        {
            Assert.False(_tuplesA.IsVector());
        }

      
        [Given(@"b <- tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void GivenB_Tuple(float p0, float p1, float p2, float p3)
        {
            _tuplesB = new Tuples(p0, p1, p2, p3);
        }

        [Then(@"b\.x = (.*)f")]
        public void ThenB_X(float p0)
        {
            Assert.That(p0, Is.EqualTo(_tuplesB.XAxis).Within(0.01f));
        }

        [Then(@"b\.y = (.*)f")]
        public void ThenB_Y(float p1)
        {
            Assert.That(p1, Is.EqualTo(_tuplesB.YAxis).Within(0.01f));
     
        }

        [Then(@"b\.z = (.*)f")]
        public void ThenB_Z(float p2)
        {
            Assert.That(p2, Is.EqualTo(_tuplesB.ZAxis).Within(0.01f));
        }

        [Then(@"b\.w = (.*)f")]
        public void ThenB_W(float p3)
        {
            Assert.That(p3, Is.EqualTo(_tuplesB.WAxis).Within(0.01f));
        }

        [Then(@"b is a vector")]
        public void ThenBIsAVector()
        {
            Assert.True(_tuplesB.IsVector());
        }

        [Then(@"b is not a point")]
        public void ThenBIsNotAPoint()
        {
            Assert.False(_tuplesB.IsPoint());
        }

        [Given(@"the first tuples is tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void GivenTheFirstTuplesIsTupleFFFF(float p0, float p1, float p2, float p3)
        {
            _pointA = new Tuples(p0, p1, p2, p3);
        }

        [Given(@"the second tuples is tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void GivenTheSecondTuplesIsTupleFFFF(float p0, float p1, float p2, float p3)
        {
            _pointB = new Tuples(p0, p1, p2, p3);
        }

        [When(@"the two tuples are added")]
        public void WhenTheTwoTuplesAreAdded()
        {
            _result = _pointA + _pointB;
        }

        [Then(@"the result should be tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void ThenTheResultShouldBeTupleFFFF(float p0, float p1, float p2, float p3)
        {
            var expectedResult = new Tuples(p0, p1, p2, p3);
            Assert.IsTrue(expectedResult.Equals(_result));
        }


        [Given(@"the first tuple is point\((.*)f, (.*)f, (.*)f\)")]
        public void GivenTheFirstTupleIsPointFFF(float p0, float p1, float p2)
        {
            _pointA = Tuples.CreatePoint(p0, p1, p2);
        }

        [Given(@"the second tuple is vector\((.*)f, (.*)f, (.*)f\)")]
        public void GivenTheSecondTupleIsVectorFFF(float p0, float p1, float p2)
        {
            _vectorC = Tuples.CreateVector(p0, p1, p2);
        }

        [When(@"the point and vector are added")]
        public void WhenThePointAndVectorAreAdded()
        {
            _result = _pointA + _vectorC;
        }

        [Then(@"the result should be point\((.*)f, (.*)f, (.*)f\)")]
        public void ThenTheResultShouldBePointFFF(float p0, float p1, float p2)
        {
            var expectedResult = Tuples.CreatePoint(p0, p1, p2);
            Assert.IsTrue(expectedResult.Equals(_result));
        }

        [Then(@"result is a point")]
        public void ThenResultIsAPoint()
        {
            Assert.IsTrue(_result.IsPoint());
        }

        [Given(@"the first tuple is vector\((.*)f, (.*)f, (.*)f\)")]
        public void GivenTheFirstTupleIsVectorFFF(float p0, float p1, float p2)
        {
            _vectorD = Tuples.CreateVector(p0, p1, p2);
        }



        [When(@"the first and second vector are added")]
        public void WhenTheFirstAndSecondVectorAreAdded()
        {
            _result = _vectorC + _vectorD;
        }

        [Then(@"the result should be vector\((.*)f, (.*)f, (.*)f\)")]
        public void ThenTheResultShouldBeVectorFFF(float p0, float p1, float p2)
        {
            var expectedResult = Tuples.CreateVector(p0, p1, p2);
            Assert.IsTrue(expectedResult.Equals(_result));
        }

        [Then(@"result is a vector")]
        public void ThenResultIsAVector()
        {
            Assert.IsTrue(_result.IsVector());
        }

        [Given(@"the second tuple is point\((.*)f, (.*)f, (.*)f\)")]
        public void GivenTheSecondTupleIsPointFFF(float p0, float p1, float p2)
        {
            _pointB = Tuples.CreatePoint(p0, p1, p2);
        }

        [When(@"the first and second points are added")]
        public void WhenTheFirstAndSecondPointsAreAdded()
        {
            _argumentException = Assert.Throws<ArgumentException>(() => _result = _pointA + _pointB);
        }

        [Then(@"the program will throw an expection error that two points cannot be added")]
        public void ThenTheProgramWillThrowAnExpectionError()
        {
            Assert.AreEqual("Cannot add two points together", _argumentException.Message);
        }


        [When(@"the first and second vectors are substracted")]
        public void WhenTheFirstAndSecondVectorsAreSubstracted()
        {
            _result = _vectorD - _vectorC;
        }

        [When(@"the vector is substracted from the point")]
        public void WhenTheVectorIsSubstractedFromThePoint()
        {
            _result = _pointA - _vectorC;
        }

        [When(@"the point is substracted from the vector")]
        public void WhenThePointIsSubstractedFromTheVector()
        {
            _argumentException = Assert.Throws<ArgumentException>(() => _result = _vectorD - _pointB);
        }


        [When(@"the second tuple is substracted from the first tuple")]
        public void WhenTheSecondTupleIsSubstractedFromTheFirstTuple()
        {
            _result = _pointA - _pointB;
        }

        [Then(@"the program will throw an expection error that a point cannot be substracted from a vector")]
        public void ThenTheProgramWillThrowAnExpectionErrorThatAPointCannotBeSubstractedFromAVector()
        {
            Assert.AreEqual("Cannot substract a point from a vector", _argumentException.Message);

        }

        [Given(@"the zero vector is vector\((.*)f, (.*)f, (.*)f\)")]
        public void GivenTheZeroVectorIsVectorFFF(float p0, float p1, float p2)
        {
            _vectorC = Tuples.CreateVector(p0, p1,p2);
        }

        [When(@"the first tuple is substracted from the zero vector")]
        public void WhenTheFirstTupleIsSubstractedFromTheZeroVector()
        {
            _result = _vectorC - _vectorD;
        }

        [Given(@"the first tuple is tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void GivenTheFirstTupleIsTupleFFFF(float p0, float p1, float p2, float p3)
        {
            _tuplesA = new Tuples(p0, p1, p2, p3);
        }

        [When(@"the first tuple is negated")]
        public void WhenTheFirstTupleIsNegated()
        {
            _result = -_tuplesA;
        }

    }



}

