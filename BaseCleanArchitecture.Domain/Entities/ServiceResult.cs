using System;
using System.Collections.Generic;

namespace BaseCleanArchitecture.Domain.Entities.Model
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public dynamic ResultObject { get; set; }
        public string ResultTitle { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public void LogError(String message)
        {
            Messages.Add(message);
        }

        public void LogError(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
