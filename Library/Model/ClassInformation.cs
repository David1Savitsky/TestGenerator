using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library.Model
{
    public class ClassInformation
    {
        public string ClassName { get; }
        public MemberDeclarationSyntax TestClassDeclarationSyntax { get; }

        public ClassInformation(string className, MemberDeclarationSyntax testClassDeclarationSyntax)
        {
            ClassName = className;
            TestClassDeclarationSyntax = testClassDeclarationSyntax;
        }
    }
}