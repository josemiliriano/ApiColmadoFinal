using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Eceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string entityName, object id) : base($"{entityName} con ID '{id}' no fue encontrado.", 404)
        {
        }
    }

    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException(string entityName, string value) : base($"{entityName} '{value}' ya existe.", 409)
        {
        }
    }

    public class ValidationException : BusinessException
    {
        public ValidationException(string message) : base(message, 400)
        {
        }
    }
}
