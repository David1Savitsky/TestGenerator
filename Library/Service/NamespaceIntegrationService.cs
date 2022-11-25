using System.Text;
using Library.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Library.Service
{
    public class NamespaceIntegrationService
    {

        private readonly ClassGenerationService _classGenerationService;

        public NamespaceIntegrationService(ClassGenerationService classGenerationService)
        {
            _classGenerationService = classGenerationService;
        }

        public ClassInformation GenerateTestClassWithNamespaces(ClassDeclarationSyntax classDeclaration)
        {
            SyntaxNode currentTreeNode = classDeclaration;
            ClassDeclarationSyntax testClassDeclaration = _classGenerationService.GenerateTestsClass(classDeclaration);
            SyntaxNode currentNamespace = currentTreeNode;
            StringBuilder testClassDeclarationBuilder = new StringBuilder(testClassDeclaration.Identifier.Text);
            
            NamespaceDeclarationSyntax parent = (NamespaceDeclarationSyntax)currentTreeNode.Parent;
            NamespaceDeclarationSyntax ns = NamespaceDeclaration(IdentifierName(parent.Name + ".Tests"))
                .WithMembers(new SyntaxList<MemberDeclarationSyntax>(testClassDeclaration));;
            
            currentNamespace = ns;
            testClassDeclarationBuilder.Insert(0, $"{ns.Name}.");
            currentTreeNode = currentTreeNode.Parent;
            
            while (currentTreeNode.Parent is NamespaceDeclarationSyntax)
            {
                parent = (NamespaceDeclarationSyntax)currentTreeNode.Parent;
                ns = NamespaceDeclaration(parent.Name)
                    .WithMembers(new SyntaxList<MemberDeclarationSyntax>((NamespaceDeclarationSyntax)currentNamespace));
                currentNamespace = ns;
                testClassDeclarationBuilder.Insert(0, $"{ns.Name}.");
                currentTreeNode = currentTreeNode.Parent;
            }

            return new ClassInformation(testClassDeclarationBuilder.ToString(), (MemberDeclarationSyntax)currentNamespace);
        }
    }
}