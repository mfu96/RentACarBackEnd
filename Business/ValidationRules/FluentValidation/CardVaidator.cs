using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator:AbstractValidator<CreditCard>
    {
        public CardValidator()
        {
            RuleFor(cr => cr.NameOnTheCard).NotEmpty();
            RuleFor(cr => cr.ExpirationDate).NotEmpty();

        }
    }
}
