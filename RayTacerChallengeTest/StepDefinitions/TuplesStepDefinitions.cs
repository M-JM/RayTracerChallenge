using NUnit.Framework;
using RayTracerChallenge;
using System;
using TechTalk.SpecFlow;

namespace RayTracerChallengeTest.StepDefinitions
{
    [Binding]
    public class TuplesStepDefinitions
    {
        private Tuples _tuplesA = new Tuples(0f,0f,0f,0f);
        private Tuples _tuplesB = new Tuples(0f,0f,0f,0f);
        private Tuples? _createPoint;
        private Tuples? _createVector;

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


        [Given(@"p <- point\((.*)f, (.*)f, (.*)f\)")]
        public void GivenP_Point(float p0, float p1, float p2)
        {
            _createPoint = Tuples.CreatePoint(p0, p1, p2); 
        }

        [Then(@"p = tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void ThenPTuple(float p0, float p1, float p2, float p3)
        {
            Assert.IsTrue(_createPoint.IsPoint());
        }

        [Given(@"v <- vector\((.*)f, (.*)f, (.*)f\)")]
        public void GivenV_Vector(float p0, float p1, float p2)
        {
            _createVector = Tuples.CreateVector(p0, p1, p2);
        }

        [Then(@"v = tuple\((.*)f, (.*)f, (.*)f, (.*)f\)")]
        public void ThenVTuple(float p0, float p1, float p2, float p3)
        {
            Assert.IsTrue(_createVector.IsVector());
        }

    }
}
