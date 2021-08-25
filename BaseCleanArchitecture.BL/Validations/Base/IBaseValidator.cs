﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCleanArchitecture.BL.Validations.Base
{
    public interface IBaseValidator : IValidator
    {
        /// <summary>
        /// This method is the responsible to decide which RuleSet si going to be excecuted base on parameter evaluation
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        string[] GetRuleSetName(object dto);
    }
}
