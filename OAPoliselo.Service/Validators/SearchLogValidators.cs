using FluentValidation;
using OAPoliselo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAPoliselo.Service.Validators
{
    public class SearchLogValidators : AbstractValidator<SearchLog>
    {
        public SearchLogValidators()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.SearchKey)
                .NotEmpty().WithMessage("Is necessary to inform the search.")
                .NotNull().WithMessage("Is necessary to inform the search.");


        }
    }
}