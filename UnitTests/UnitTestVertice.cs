

namespace UnitTests
{
    [TestClass]
    public class UnitTestVertice
    {
        private Vertice verticeFrom = new Vertice(0f); 
        private Vertice verticeTo = new Vertice(0f);

        [TestInitialize]
        public void Startup() 
        {
            Vertice.ResetLastId();
            verticeFrom = new Vertice(0f);
            verticeTo = new Vertice(0f);
        }

        [TestMethod]
        public void TestVerticeId()
        {
            Assert.AreEqual(0, verticeFrom.GetId());
            Assert.AreEqual(1, verticeTo.GetId());
        }
    }
}