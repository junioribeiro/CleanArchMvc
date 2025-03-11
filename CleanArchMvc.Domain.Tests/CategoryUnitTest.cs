using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With valid State")]
        public void CreateCategory_WithValidParamiters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                  .NotThrow<DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create Category With Negative Id Value")]
        public void CreateCategory_NegativeIdValue_DomainExceptionValidationInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                   .Throw<DomainExceptionValidation>().WithMessage("Invalid id value");
        }

        [Fact(DisplayName = "Create Category With short  name Value")]
        public void CreateCategory_ShortNameValue_DomainExceptionValidationName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                   .Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category Missing name Value")]
        public void CreateCategory_MissingNameValue_DomainExceptionValidationRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                   .Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }
    }
}