using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Criar um produto com paramentros validos")]
        public void CriarProduct_ComParamentrosValido_ObjetoResultadoValido()
        {
            Action action = () => new Product("Product Name", "Product Description", 100, 5, "Product image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar um produto com paramentros image vazio")]
        public void CriarProduct_ComParamentrosimageVazio_ObjetoResultadoValido()
        {
            Action action = () => new Product("Product Name", "Product Description", 100, 5, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar um produto com paramentros image Null")]
        public void CriarProduct_ComParamentrosImageNull_ObjetoResultadoValido()
        {
            Action action = () => new Product("Product Name", "Product Description", 100, 5, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Criar um produto com paramentros image Null")]
        public void CriarProduct_ComParamentrosImageNull_ObjetoResultadoValidoSemException()
        {
            Action action = () => new Product("Product Name", "Product Description", 100, 5, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Criar um produto com paramentros image muito longo")]
        public void CriarProduct_ComParamentrosImageLongo_ObjetoResultadoValido()
        {
            Action action = () => new Product("Product Name", "Product Description", 100, 5, "image muito longa acima de duzentos e ciquenta caracteres image muito longa acima de duzentos e ciquenta caracteres image muito longa acima de duzentos e ciquenta caracteres image muito longa acima de duzentos e ciquenta caracteres image muito longa acima de duzentos e ciquenta caracteres");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image, too short, minimum 250 characters");
        }

        [Fact(DisplayName = "Criar um produto com paramentros Id negativo")]
        public void CriarProduct_ComParamentrosIdNegativo_ObjetoResultadoException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Criar um produto com paramentros Name vazio")]
        public void CriarProduct_ComParamentrosNameVazio_ObjetoResultadoException()
        {
            Action action = () => new Product(1, "", "Product Description", 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }
        [Fact(DisplayName = "Criar um produto com paramentros Name Null")]
        public void CriarProduct_ComParamentrosNameNull_ObjetoResultadoException()
        {
            Action action = () => new Product(null, "Product Description", 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }

        [Fact(DisplayName = "Criar um produto com paramentros Name Curto")]
        public void CriarProduct_ComParamentrosNameCurto_ObjetoResultadoException()
        {
            Action action = () => new Product("Pr", "Product Description", 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name.Name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Criar um produto com paramentros Description vazio")]
        public void CriarProduct_ComParamentrosDescriptionVazio_ObjetoResultadoException()
        {
            Action action = () => new Product("Produto name", "", 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description is required");
        }

        [Fact(DisplayName = "Criar um produto com paramentros Description null")]
        public void CriarProduct_ComParamentrosDescriptionNull_ObjetoResultadoException()
        {
            Action action = () => new Product("Produto name", null, 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description is required");
        }

        [Fact(DisplayName = "Criar um produto com paramentros Description Curto")]
        public void CriarProduct_ComParamentrosDescriptionCurto_ObjetoResultadoException()
        {
            Action action = () => new Product("Produto name", "Desc", 100, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Theory(DisplayName = "Criar um produto com paramentros price negativo")]
        [InlineData(-5)]
        public void CriarProduct_ComParamentrosPriceNegative_ObjetoResultadoException(int price)
        {
            Action action = () => new Product("Produto name", "Description", price, 5, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Theory(DisplayName = "Criar um produto com paramentros stock negativo")]
        [InlineData(-10)]
        public void CriarProduct_ComParamentrosStockNegative_ObjetoResultadoException(int stock)
        {
            Action action = () => new Product("Produto name", "Description", 150, stock, "image produto");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
        }


    }
}
