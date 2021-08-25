using System;
namespace BaseCleanArchitecture.Domain.Entities.Model
{
    public class DataResult
    {
        public bool Successfull { get; set; }

        public dynamic Data { get; set; }

        public DataResult()
        {
            this.Successfull = true;
        }

        public void LogError(Exception ex)
        {
            this.Successfull = false;
            this.Data = ex.Message;
        }
    }
}
