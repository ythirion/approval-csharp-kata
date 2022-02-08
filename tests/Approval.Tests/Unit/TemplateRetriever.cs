using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Approval.Shared.SalesForce.Templating;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;
using static Approval.Tests.CollectionExtensions;

namespace Approval.Tests.Unit
{
    [UsesVerify]
    public class TemplateRetriever
    {
        [Fact]
        public void Given_GLPP_And_Individual_Prospect_Should_Return_GLPP()
        {
            var template = Template.FindTemplateFor("GLPP", "INDIVIDUAL_PROSPECT");

            template.DocumentType.Should().Be(DocumentType.GLPP);
            template.RecordType.Should().Be(SfRecordType.INDIVIDUAL_PROSPECT);
            template.TemplateId.Should().Be("GUIDEPP");
            template.TemplateFile.Should().Be("GLPP.ftl");
        }

        [Fact]
        public void Given_GLPP_And_Legal_Prospect_Should_Throw_InvalidArgumentException()
        {
            var act = () => Template.FindTemplateFor("GLPP", "LEGAL_PROSPECT");
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid Document template type or record type");
        }

        [Fact]
        public Task Combination_Verify()
            => Verify(
                CombineEnumValues<DocumentType, SfRecordType>()
                    .Select(t => FindTemplateSafely(t.Item1, t.Item2))
                    .Aggregate(new StringBuilder(), (builder, s) => builder.AppendLine(s))
            );

        private static string FindTemplateSafely(
            DocumentType documentType,
            SfRecordType recordType)
            => PrintResult(documentType, recordType,
                TryFindTemplate(documentType, recordType));

        private static string PrintResult(
            DocumentType documentType,
            SfRecordType recordType,
            string result)
            => $"[{documentType},{recordType}] => {result}";

        private static string TryFindTemplate(DocumentType documentType, SfRecordType recordType)
        {
            try
            {
                return Template.FindTemplateFor(documentType.ToString(), recordType.ToString()).ToString();
            }
            catch (ArgumentException argumentException)
            {
                return argumentException.Message;
            }
        }
    }
}
