using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez");
                RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı en az 5 karakter olabilir");
                RuleFor(x => x.Name).MaximumLength(500).WithMessage("Proje adı en fazla 500 karakter olabilir");
                
        }
    }
}
