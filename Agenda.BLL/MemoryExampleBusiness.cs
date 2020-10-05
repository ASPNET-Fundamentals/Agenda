using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entity;

namespace Agenda.BLL
{
    public class MemoryExampleBusiness : IExampleBusiness, IDisposable
    {
        private List<Example> lstExample;
        public void Dispose()
        {
        }

        public MemoryExampleBusiness(List<Example> lstExample)
        {
            this.lstExample = lstExample;
        }

        public Example GetExampleByID(Example example)
        {
            return this.lstExample.Single(p => p.id.Equals(example.id));
        }

        public List<Example> GetListExampleByFilter(ExampleFilter exampleFilter)
        {
            if (exampleFilter != null)
            {
                //return this.lstExample.Single(p => p.value.Equals(exampleFilter.value));
                return this.lstExample;
            }
            else 
            {
                return this.lstExample;
            }
        }

        public void Insert(Example example)
        {            
            int max = this.lstExample.OrderByDescending(x => x.id).First().id.Value;                        
            this.lstExample.Add(example);
        }

        public void Update(Example example)
        {
            this.lstExample.Remove(example);
            this.lstExample.Add(example);
        }

        public void Delete(Example example)
        {
            this.lstExample.Remove(example);
        }

    }
}
