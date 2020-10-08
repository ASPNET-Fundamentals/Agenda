using System.Collections.Generic;
using Agenda.Entity;

namespace Agenda.BLL
{
    public interface IExampleBusiness
    {        
        Example GetExampleByID(Example example);
        List<Example> GetListExampleByFilter(ExampleFilter exampleFilter);
        Example Insert(Example example);
        void Update(Example example);
        void Delete(Example example);
    }
}