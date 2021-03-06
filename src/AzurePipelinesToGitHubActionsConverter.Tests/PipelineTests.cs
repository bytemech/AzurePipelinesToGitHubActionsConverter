using AzurePipelinesToGitHubActionsConverter.Core.Conversion;
using AzurePipelinesToGitHubActionsConverter.Core.Conversion.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurePipelinesToGitHubActionsConverter.Tests
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void PipelineNameTest()
        {
            //Arrange
            string input = "name: test ci pipelines";
            Conversion conversion = new Conversion();

            //Act
            ConversionResponse gitHubOutput = conversion.ConvertAzurePipelineToGitHubAction(input);

            //Assert
            string expected = "name: test ci pipelines";
            Assert.AreEqual(expected, gitHubOutput.actionsYaml);
            Assert.AreEqual(true, gitHubOutput.v2ConversionSuccessful);
        }

        [TestMethod]
        public void PipelineInvalidStringTest()
        {
            //Arrange
            string input = "     ";
            Conversion conversion = new Conversion();

            //Act
            ConversionResponse gitHubOutput = conversion.ConvertAzurePipelineToGitHubAction(input);

            //Assert
            string expected = "";
            Assert.AreEqual(expected, gitHubOutput.actionsYaml);
            Assert.AreEqual(true, gitHubOutput.v2ConversionSuccessful);
        }

        [TestMethod]
        public void PipelineNullStringTest()
        {
            //Arrange
            string input = null;
            Conversion conversion = new Conversion();

            //Act
            ConversionResponse gitHubOutput = conversion.ConvertAzurePipelineToGitHubAction(input);

            //Assert
            string expected = "";
            Assert.AreEqual(expected, gitHubOutput.actionsYaml);
            Assert.AreEqual(true, gitHubOutput.v2ConversionSuccessful);
        }     

    }
}