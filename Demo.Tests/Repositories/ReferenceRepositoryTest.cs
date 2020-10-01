using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Demo.Web.Repositories.ReferenceRepository;

namespace Demo.Tests.Repositories
{
    [TestClass]
    public class ReferenceRepositoryTest
    {
        [TestMethod]
        public async Task Get_Reference_No_Sequence_Should_Return_True()
        {
            string expected = "3";
            var result = await GetReferenceNoSequenceAsync();
            Assert.IsTrue(result == expected);
        }
    }
}
